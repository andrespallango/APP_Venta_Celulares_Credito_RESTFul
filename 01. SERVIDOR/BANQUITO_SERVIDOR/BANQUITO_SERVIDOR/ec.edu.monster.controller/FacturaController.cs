using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BANQUITO_SERVIDOR.ec.edu.monster.model;
using MySql.Data.MySqlClient;

namespace BANQUITO_SERVIDOR.ec.edu.monster.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly string _connectionString;

        public FacturaController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaSQL");
        }

        [HttpPost("crear")]
        public async Task<ActionResult<bool>> CrearFactura([FromBody] Factura factura)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Calcular subtotal, IVA y total
                        double subtotal = 0;
                        foreach (var detalle in factura.Detalles)
                        {
                            subtotal += detalle.Subtotal;
                        }
                        double iva = subtotal * 0.12; // IVA del 12%
                        double totalConIva = subtotal + iva;

                        // Insertar la factura
                        string sqlFactura = @"
                            INSERT INTO banquito.Factura (cod_cliente, fecha, total, forma_pago) 
                            VALUES (@codCliente, NOW(), @total, @formaPago);
                            SELECT LAST_INSERT_ID();";

                        int codFactura;
                        using (var commandFactura = new MySqlCommand(sqlFactura, connection, transaction))
                        {
                            commandFactura.Parameters.AddWithValue("@codCliente", factura.CodCliente);
                            commandFactura.Parameters.AddWithValue("@total", totalConIva);
                            commandFactura.Parameters.AddWithValue("@formaPago", factura.FormaPago);

                            codFactura = Convert.ToInt32(await commandFactura.ExecuteScalarAsync());
                        }

                        // Insertar los detalles de la factura
                        string sqlDetalle = @"
                            INSERT INTO banquito.DetalleFactura (cod_factura, cod_producto, cantidad, precio_unitario, subtotal) 
                            VALUES (@codFactura, @codProducto, @cantidad, @precioUnitario, @subtotal);";

                        using (var commandDetalle = new MySqlCommand(sqlDetalle, connection, transaction))
                        {
                            foreach (var detalle in factura.Detalles)
                            {
                                commandDetalle.Parameters.Clear();
                                commandDetalle.Parameters.AddWithValue("@codFactura", codFactura);
                                commandDetalle.Parameters.AddWithValue("@codProducto", detalle.CodProducto);
                                commandDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                                commandDetalle.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                                commandDetalle.Parameters.AddWithValue("@subtotal", detalle.Subtotal);

                                await commandDetalle.ExecuteNonQueryAsync();
                            }
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                        return Ok(true);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(500, $"Error al crear la factura: {ex.Message}");
                    }
                }
            }
        }

        [HttpGet("obtenerFacturaCompleta/{codFactura}")]
        public async Task<ActionResult<object>> ObtenerFacturaCompleta(int codFactura)
        {
            string sqlFactura = @"
                SELECT f.fecha, f.total, f.forma_pago, 
                       c.nombre AS nombre_cliente, c.cedula AS cedula_cliente 
                FROM banquito.Factura f 
                JOIN banquito.Cliente c ON f.cod_cliente = c.cod_cliente 
                WHERE f.cod_factura = @codFactura";

            string sqlDetalles = @"
                SELECT df.cod_producto, p.nombre AS nombre_producto, 
                       df.cantidad, df.precio_unitario, df.subtotal 
                FROM banquito.DetalleFactura df 
                JOIN banquito.Producto p ON df.cod_producto = p.cod_producto 
                WHERE df.cod_factura = @codFactura";

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Obtener información general de la factura
                    object facturaInfo = null;
                    using (var command = new MySqlCommand(sqlFactura, connection))
                    {
                        command.Parameters.AddWithValue("@codFactura", codFactura);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                facturaInfo = new
                                {
                                    Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                                    Total = (double)reader.GetDecimal(reader.GetOrdinal("total")),
                                    FormaPago = reader.GetString(reader.GetOrdinal("forma_pago")),
                                    Cliente = new
                                    {
                                        Nombre = reader.GetString(reader.GetOrdinal("nombre_cliente")),
                                        Cedula = reader.GetString(reader.GetOrdinal("cedula_cliente"))
                                    }
                                };
                            }
                        }
                    }

                    if (facturaInfo == null)
                    {
                        return NotFound("No se encontró la factura.");
                    }

                    // Obtener los detalles de la factura
                    List<object> detalles = new List<object>();
                    using (var command = new MySqlCommand(sqlDetalles, connection))
                    {
                        command.Parameters.AddWithValue("@codFactura", codFactura);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                detalles.Add(new
                                {
                                    CodProducto = reader.GetInt32(reader.GetOrdinal("cod_producto")),
                                    NombreProducto = reader.GetString(reader.GetOrdinal("nombre_producto")),
                                    Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                                    PrecioUnitario = (double)reader.GetDecimal(reader.GetOrdinal("precio_unitario")),
                                    Subtotal = (double)reader.GetDecimal(reader.GetOrdinal("subtotal"))
                                });
                            }
                        }
                    }

                    // Calcular subtotal e IVA
                    double subtotal = 0;
                    foreach (var detalle in detalles)
                    {
                        subtotal += ((dynamic)detalle).Subtotal;
                    }
                    double iva = subtotal * 0.12;
                    double totalConIva = subtotal + iva;

                    // Combinar la información de la factura con sus detalles
                    var facturaCompleta = new
                    {
                        Factura = facturaInfo,
                        Detalles = detalles,
                        Subtotal = subtotal,
                        IVA = iva,
                        TotalConIVA = totalConIva
                    };

                    return Ok(facturaCompleta);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la factura completa: {ex.Message}");
            }
        }

        [HttpGet("obtenerFacturas/{cedula}")]
        public async Task<ActionResult<List<Factura>>> ObtenerFacturasPorCedula(string cedula)
        {
            string sql = @"
                SELECT f.*, c.nombre AS nombre_cliente, c.cedula AS cedula_cliente 
                FROM banquito.Factura f 
                JOIN banquito.Cliente c ON f.cod_cliente = c.cod_cliente 
                WHERE c.cedula = @cedula";

            List<Factura> facturas = new List<Factura>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cedula", cedula);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                facturas.Add(new Factura
                                {
                                    CodFactura = reader.GetInt32(reader.GetOrdinal("cod_factura")),
                                    CodCliente = reader.GetInt32(reader.GetOrdinal("cod_cliente")),
                                    Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                                    Total = (double)reader.GetDecimal(reader.GetOrdinal("total")),
                                    FormaPago = reader.GetString(reader.GetOrdinal("forma_pago"))
                                });
                            }
                        }
                    }
                }
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener facturas: {ex.Message}");
            }
        }
    }
}
