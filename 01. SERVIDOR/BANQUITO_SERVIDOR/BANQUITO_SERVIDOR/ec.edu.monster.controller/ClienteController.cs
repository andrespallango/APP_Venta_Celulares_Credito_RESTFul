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
    public class ClienteController : ControllerBase
    {
        private readonly string _connectionString;

        public ClienteController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaSQL");
        }

        [HttpGet("esSujetoDeCredito/{cedula}")]
        public async Task<ActionResult<bool>> EsSujetoDeCredito(string cedula)
        {
            string sql = @"
            SELECT 
                c.cod_cliente, 
                c.genero, 
                c.fecha_nacimiento,
                CASE 
                    WHEN EXISTS (
                        SELECT 1 
                        FROM banquito.Cuenta cu
                        INNER JOIN banquito.Movimiento m ON cu.num_cuenta = m.num_cuenta
                        WHERE cu.cod_cliente = c.cod_cliente AND m.tipo = 'DEP' 
                        AND m.fecha > DATE_SUB(CURDATE(), INTERVAL 1 MONTH)
                    ) THEN 1 ELSE 0 
                END AS tieneDeposito,
                CASE 
                    WHEN EXISTS (
                        SELECT 1 
                        FROM banquito.Credito cr 
                        WHERE cr.cod_cliente = c.cod_cliente AND cr.estado = 'Activo'
                    ) THEN 1 ELSE 0 
                END AS tieneCreditoActivo
            FROM banquito.Cliente c
            WHERE c.cedula = @cedula";

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
                            if (await reader.ReadAsync())
                            {
                                bool tieneDeposito = reader.GetInt32(reader.GetOrdinal("tieneDeposito")) == 1;
                                bool tieneCreditoActivo = reader.GetInt32(reader.GetOrdinal("tieneCreditoActivo")) == 1;
                                string genero = reader.GetString(reader.GetOrdinal("genero"));
                                DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"));

                                int edad = CalcularEdad(fechaNacimiento);

                                return Ok(tieneDeposito && !tieneCreditoActivo && (genero == "F" || edad >= 25));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al verificar sujeto de crédito: {ex.Message}");
            }
            return Ok(false);
        }

        [HttpGet("calcularMontoMaximoCredito/{codCliente}")]
        public async Task<ActionResult<double>> CalcularMontoMaximoCredito(int codCliente)
        {
            string sql = @"
            SELECT 
                (SELECT COALESCE(AVG(m.valor), 0) 
                 FROM banquito.Cuenta cu 
                 INNER JOIN banquito.Movimiento m ON cu.num_cuenta = m.num_cuenta
                 WHERE cu.cod_cliente = @codCliente AND m.tipo = 'DEP' 
                 AND m.fecha > DATE_SUB(CURDATE(), INTERVAL 3 MONTH)) AS promedioDepositos,
                (SELECT COALESCE(AVG(m.valor), 0) 
                 FROM banquito.Cuenta cu 
                 INNER JOIN banquito.Movimiento m ON cu.num_cuenta = m.num_cuenta
                 WHERE cu.cod_cliente = @codCliente AND m.tipo = 'RET' 
                 AND m.fecha > DATE_SUB(CURDATE(), INTERVAL 3 MONTH)) AS promedioRetiros";

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@codCliente", codCliente);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                decimal promedioDepositos = reader.GetDecimal(reader.GetOrdinal("promedioDepositos"));
                                decimal promedioRetiros = reader.GetDecimal(reader.GetOrdinal("promedioRetiros"));
                                decimal diferencia = promedioDepositos - promedioRetiros;

                                // Convertir a double para la respuesta
                                double montoMaximo = Math.Max(0, (double)(diferencia * 0.35m) * 6);
                                return Ok(montoMaximo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al calcular monto máximo: {ex.Message}");
            }
            return StatusCode(400, "No se encontró información para el cliente proporcionado.");
        }

        [HttpGet("obtenerCodigoCliente/{cedula}")]
        public async Task<ActionResult<int>> ObtenerCodigoCliente(string cedula)
        {
            string sql = "SELECT cod_cliente FROM banquito.Cliente WHERE cedula = @cedula";
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
                            if (await reader.ReadAsync())
                            {
                                return Ok(reader.GetInt32(reader.GetOrdinal("cod_cliente")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener código de cliente: {ex.Message}");
            }
            return NotFound("No se encontró el cliente con la cédula proporcionada.");
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime ahora = DateTime.Now;
            int edad = ahora.Year - fechaNacimiento.Year;
            if (fechaNacimiento > ahora.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
