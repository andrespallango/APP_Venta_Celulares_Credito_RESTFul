using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BANQUITO_SERVIDOR.ec.edu.monster.model;
using MySql.Data.MySqlClient;

namespace BANQUITO_SERVIDOR.ec.edu.monster.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly string _connectionString;

        public VentaController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaSQL");
        }

        [HttpPost("realizarVenta")]
        public async Task<ActionResult<bool>> RealizarVenta([FromBody] Factura factura, [FromQuery] int numeroCuotas, [FromQuery] string cedula)
        {
            if (factura == null || factura.Detalles.Count == 0)
                return BadRequest("La factura debe contener al menos un producto.");

            if (string.IsNullOrEmpty(cedula))
                return BadRequest("La cédula del cliente es requerida.");

            if (factura.FormaPago == "Crédito" && (numeroCuotas < 3 || numeroCuotas > 18))
                return BadRequest("El número de cuotas debe estar entre 3 y 18 para ventas a crédito.");

            double total = 0;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        // Obtener el código del cliente
                        int codCliente = await ObtenerCodigoCliente(cedula, connection, transaction);
                        if (codCliente == -1)
                            return NotFound("No se encontró un cliente con la cédula proporcionada.");

                        factura.CodCliente = codCliente;

                        // Calcular el total de la factura
                        foreach (var detalle in factura.Detalles)
                        {
                            detalle.PrecioUnitario = await ObtenerPrecioProducto(detalle.CodProducto, connection, transaction);
                            detalle.Subtotal = detalle.PrecioUnitario * detalle.Cantidad;
                            total += detalle.Subtotal;
                        }

                        if (factura.FormaPago == "Efectivo")
                        {
                            total *= 0.58; // Aplicar descuento del 42%
                        }
                        else if (factura.FormaPago == "Crédito")
                        {
                            if (!await EsSujetoCredito(codCliente, connection, transaction))
                                return BadRequest("El cliente no es sujeto de crédito.");

                            double montoMaximo = await ObtenerMontoMaximoCredito(codCliente, connection, transaction);
                            if (total > montoMaximo)
                                return BadRequest("El monto excede el crédito aprobado.");

                            await GenerarTablaAmortizacion(codCliente, total, numeroCuotas, connection, transaction);
                        }
                        else
                        {
                            return BadRequest("Forma de pago no válida.");
                        }

                        // Crear factura
                        int codFactura = await CrearFactura(factura, total, connection, transaction);

                        // Insertar detalles de factura
                        await InsertarDetallesFactura(codFactura, factura.Detalles, connection, transaction);

                        await transaction.CommitAsync();
                        return Ok(true);
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return StatusCode(500, $"Error al realizar la venta: {ex.Message}");
                    }
                }
            }
        }

        private async Task<int> ObtenerCodigoCliente(string cedula, MySqlConnection connection, MySqlTransaction transaction)
        {
            string sql = "SELECT cod_cliente FROM banquito.Cliente WHERE cedula = @cedula";
            using (var command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@cedula", cedula);
                object result = await command.ExecuteScalarAsync();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private async Task<double> ObtenerPrecioProducto(int codProducto, MySqlConnection connection, MySqlTransaction transaction)
        {
            string sql = "SELECT precio FROM banquito.Producto WHERE cod_producto = @codProducto";
            using (var command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@codProducto", codProducto);
                object result = await command.ExecuteScalarAsync();
                return result != null ? Convert.ToDouble(result) : throw new Exception("Producto no encontrado.");
            }
        }

        private async Task<bool> EsSujetoCredito(int codCliente, MySqlConnection connection, MySqlTransaction transaction)
        {
            string sqlDepositos = "SELECT COUNT(*) FROM banquito.Movimiento WHERE num_cuenta IN (SELECT num_cuenta FROM banquito.Cuenta WHERE cod_cliente = @codCliente) AND tipo = 'DEP' AND fecha > NOW() - INTERVAL 1 MONTH";
            string sqlCreditoActivo = "SELECT COUNT(*) FROM banquito.Credito WHERE cod_cliente = @codCliente AND estado = 'Activo'";
            string sqlEdad = "SELECT TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) AS edad, genero FROM banquito.Cliente WHERE cod_cliente = @codCliente";

            // Verificar depósitos recientes
            using (var command = new MySqlCommand(sqlDepositos, connection, transaction))
            {
                command.Parameters.AddWithValue("@codCliente", codCliente);
                if (Convert.ToInt32(await command.ExecuteScalarAsync()) == 0)
                    return false;
            }

            // Verificar créditos activos
            using (var command = new MySqlCommand(sqlCreditoActivo, connection, transaction))
            {
                command.Parameters.AddWithValue("@codCliente", codCliente);
                if (Convert.ToInt32(await command.ExecuteScalarAsync()) > 0)
                    return false;
            }

            // Verificar edad y género
            using (var command = new MySqlCommand(sqlEdad, connection, transaction))
            {
                command.Parameters.AddWithValue("@codCliente", codCliente);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        int edad = reader.GetInt32(reader.GetOrdinal("edad"));
                        string genero = reader.GetString(reader.GetOrdinal("genero"));
                        if (genero == "M" && edad < 25)
                            return false;
                    }
                }
            }

            return true;
        }

        private async Task<double> ObtenerMontoMaximoCredito(int codCliente, MySqlConnection connection, MySqlTransaction transaction)
        {
            string sqlPromedios = @"
                SELECT 
                    (SELECT COALESCE(AVG(valor), 0) FROM banquito.Movimiento WHERE num_cuenta IN (SELECT num_cuenta FROM banquito.Cuenta WHERE cod_cliente = @codCliente) AND tipo = 'DEP' AND fecha > NOW() - INTERVAL 3 MONTH) AS promedioDepositos,
                    (SELECT COALESCE(AVG(valor), 0) FROM banquito.Movimiento WHERE num_cuenta IN (SELECT num_cuenta FROM banquito.Cuenta WHERE cod_cliente = @codCliente) AND tipo = 'RET' AND fecha > NOW() - INTERVAL 3 MONTH) AS promedioRetiros";

            using (var command = new MySqlCommand(sqlPromedios, connection, transaction))
            {
                command.Parameters.AddWithValue("@codCliente", codCliente);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        double promedioDepositos = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("promedioDepositos")));
                        double promedioRetiros = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("promedioRetiros")));
                        return Math.Max(0, (promedioDepositos - promedioRetiros) * 0.35 * 6);
                    }
                }
            }

            return 0;
        }

        private async Task GenerarTablaAmortizacion(int codCliente, double total, int numeroCuotas, MySqlConnection connection, MySqlTransaction transaction)
        {
            string sqlCrearCredito = "INSERT INTO banquito.Credito (cod_cliente, monto_aprobado, plazo, tasa_interes, fecha_inicio, saldo_actual, estado) VALUES (@codCliente, @monto, @plazo, 16.5, NOW(), @monto, 'Activo'); SELECT LAST_INSERT_ID();";
            int codCredito;
            using (var command = new MySqlCommand(sqlCrearCredito, connection, transaction))
            {
                command.Parameters.AddWithValue("@codCliente", codCliente);
                command.Parameters.AddWithValue("@monto", total);
                command.Parameters.AddWithValue("@plazo", numeroCuotas);
                codCredito = Convert.ToInt32(await command.ExecuteScalarAsync());
            }

            double tasaMensual = 16.5 / 12 / 100;
            double cuota = (total * tasaMensual) / (1 - Math.Pow(1 + tasaMensual, -numeroCuotas));
            string sqlInsertAmortizacion = "INSERT INTO banquito.Amortizacion (cod_credito, num_cuota, valor_cuota, interes_pagado, capital_pagado, saldo, fecha_pago) VALUES (@codCredito, @numCuota, @valorCuota, @interes, @capital, @saldo, @fechaPago)";
            using (var command = new MySqlCommand(sqlInsertAmortizacion, connection, transaction))
            {
                double saldoPendiente = total;
                for (int i = 1; i <= numeroCuotas; i++)
                {
                    double interesPagado = saldoPendiente * tasaMensual;
                    double capitalPagado = cuota - interesPagado;
                    saldoPendiente -= capitalPagado;

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codCredito", codCredito);
                    command.Parameters.AddWithValue("@numCuota", i);
                    command.Parameters.AddWithValue("@valorCuota", cuota);
                    command.Parameters.AddWithValue("@interes", interesPagado);
                    command.Parameters.AddWithValue("@capital", capitalPagado);
                    command.Parameters.AddWithValue("@saldo", saldoPendiente);
                    command.Parameters.AddWithValue("@fechaPago", DateTime.Now.AddMonths(i));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task<int> CrearFactura(Factura factura, double total, MySqlConnection connection, MySqlTransaction transaction)
        {
            string sql = "INSERT INTO banquito.Factura (cod_cliente, fecha, total, forma_pago) VALUES (@codCliente, NOW(), @total, @formaPago); SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@codCliente", factura.CodCliente);
                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@formaPago", factura.FormaPago);
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
        }

        private async Task InsertarDetallesFactura(int codFactura, List<DetalleFactura> detalles, MySqlConnection connection, MySqlTransaction transaction)
        {
            string sql = "INSERT INTO banquito.DetalleFactura (cod_factura, cod_producto, cantidad, precio_unitario, subtotal) VALUES (@codFactura, @codProducto, @cantidad, @precioUnitario, @subtotal)";
            using (var command = new MySqlCommand(sql, connection, transaction))
            {
                foreach (var detalle in detalles)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@codFactura", codFactura);
                    command.Parameters.AddWithValue("@codProducto", detalle.CodProducto);
                    command.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    command.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                    command.Parameters.AddWithValue("@subtotal", detalle.Subtotal);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
