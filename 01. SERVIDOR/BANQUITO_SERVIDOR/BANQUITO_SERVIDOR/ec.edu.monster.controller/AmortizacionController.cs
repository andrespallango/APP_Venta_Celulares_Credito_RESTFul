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
    public class AmortizacionController : ControllerBase
    {
        private readonly string _connectionString;

        public AmortizacionController(IConfiguration configuration)
        {
            // Obtiene la cadena de conexión desde appsettings.json
            _connectionString = configuration.GetConnectionString("CadenaSQL");
        }

        /// <summary>
        /// Obtiene la tabla de amortización por código de crédito.
        /// </summary>
        [HttpGet("credito/{codCredito}")]
        public async Task<ActionResult<List<Amortizacion>>> ObtenerAmortizacionPorCredito(int codCredito)
        {
            string sql = "SELECT * FROM banquito.Amortizacion WHERE cod_credito = @codCredito";
            var amortizaciones = new List<Amortizacion>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@codCredito", codCredito);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                amortizaciones.Add(new Amortizacion
                                {
                                    CodAmortizacion = reader.GetInt32(reader.GetOrdinal("cod_amortizacion")),
                                    CodCredito = reader.GetInt32(reader.GetOrdinal("cod_credito")),
                                    NumCuota = reader.GetInt32(reader.GetOrdinal("num_cuota")),
                                    ValorCuota = (double)reader.GetDecimal(reader.GetOrdinal("valor_cuota")),
                                    InteresPagado = (double)reader.GetDecimal(reader.GetOrdinal("interes_pagado")),
                                    CapitalPagado = (double)reader.GetDecimal(reader.GetOrdinal("capital_pagado")),
                                    Saldo = (double)reader.GetDecimal(reader.GetOrdinal("saldo")),
                                    FechaPago = reader.GetDateTime(reader.GetOrdinal("fecha_pago"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener amortizaciones: {ex.Message}");
            }

            return Ok(amortizaciones);
        }

        /// <summary>
        /// Obtiene el último código de crédito de un cliente por su código de cliente.
        /// </summary>
        [HttpGet("cliente/{codCliente}/ultimo-credito")]
        public async Task<ActionResult<int>> ObtenerUltimoCodCreditoPorCliente(int codCliente)
        {
            string sql = "SELECT cod_credito FROM banquito.Credito WHERE cod_cliente = @codCliente ORDER BY cod_credito DESC LIMIT 1";
            int codCredito = -1;

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
                                codCredito = reader.GetInt32(reader.GetOrdinal("cod_credito"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el último crédito: {ex.Message}");
            }

            if (codCredito == -1)
                return NotFound("No se encontró un crédito asociado al cliente.");

            return Ok(codCredito);
        }
    }
}
