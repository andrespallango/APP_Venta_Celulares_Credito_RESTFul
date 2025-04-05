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
    public class TelefonoController : ControllerBase
    {
        private readonly string _connectionString;

        public TelefonoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CadenaSQL");
        }

        // Crear un teléfono
        [HttpPost("crear")]
        public async Task<ActionResult<bool>> CrearTelefono([FromBody] Telefono telefono)
        {
            string sql = "INSERT INTO banquito.Producto (nombre, precio, foto) VALUES (@nombre, @precio, @foto)";
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", telefono.Nombre);
                        command.Parameters.AddWithValue("@precio", telefono.Precio);
                        command.Parameters.AddWithValue("@foto", telefono.Foto);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return Ok(rowsAffected > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el teléfono: {ex.Message}");
            }
        }

        // Listar todos los teléfonos
        [HttpGet("listar")]
        public async Task<ActionResult<List<Telefono>>> ListarTelefonos()
        {
            string sql = "SELECT * FROM banquito.Producto";
            var telefonos = new List<Telefono>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                telefonos.Add(new Telefono
                                {
                                    CodProducto = reader.GetInt32(reader.GetOrdinal("cod_producto")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Precio = (double)reader.GetDecimal(reader.GetOrdinal("precio")), // Conversión explícita
                                    Foto = reader.GetString(reader.GetOrdinal("foto"))
                                });
                            }
                        }
                    }
                }
                return Ok(telefonos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los teléfonos: {ex.Message}");
            }
        }

        // Actualizar un teléfono
        [HttpPut("actualizar")]
        public async Task<ActionResult<bool>> ActualizarTelefono([FromBody] Telefono telefono)
        {
            string sql = "UPDATE banquito.Producto SET nombre = @nombre, precio = @precio, foto = @foto WHERE cod_producto = @codProducto";
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", telefono.Nombre);
                        command.Parameters.AddWithValue("@precio", telefono.Precio);
                        command.Parameters.AddWithValue("@foto", telefono.Foto);
                        command.Parameters.AddWithValue("@codProducto", telefono.CodProducto);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return Ok(rowsAffected > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el teléfono: {ex.Message}");
            }
        }

        // Eliminar un teléfono
        [HttpDelete("eliminar/{codProducto}")]
        public async Task<ActionResult<bool>> EliminarTelefono(int codProducto)
        {
            string sql = "DELETE FROM banquito.Producto WHERE cod_producto = @codProducto";
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@codProducto", codProducto);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return Ok(rowsAffected > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el teléfono: {ex.Message}");
            }
        }
    }
}
