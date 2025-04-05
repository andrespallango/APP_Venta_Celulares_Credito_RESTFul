using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using CLIENTE_ESCRITORIO.ec.edu.monster.model;
using ec.edu.monster.model;

namespace ec.edu.monster.service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5182/api/") // Cambia esta URL si tu API tiene otra dirección
            };
        }

        // Clientes
        public async Task<bool> EsSujetoDeCredito(string cedula)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<bool>($"Cliente/esSujetoDeCredito/{cedula}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar crédito: {ex.Message}");
                return false;
            }
        }



        public async Task<int> ObtenerCodigoCliente(string cedula)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<int>($"Cliente/obtenerCodigoCliente/{cedula}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener código de cliente: {ex.Message}");
                return -1; // Indica un error
            }
        }

        public async Task<double> CalcularMontoMaximoCredito(int codCliente)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"Cliente/calcularMontoMaximoCredito/{codCliente}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular el monto máximo de crédito: {ex.Message}");
                return 0; // Indica un error
            }
        }

        // Teléfonos
        public async Task<List<Telefono>> ListarTelefonos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Telefono>>("Telefono/listar");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar teléfonos: {ex.Message}");
                return new List<Telefono>();
            }
        }

        public async Task<bool> CrearTelefono(Telefono telefono)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Telefono/crear", telefono);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear teléfono: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ActualizarTelefono(Telefono telefono)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("Telefono/actualizar", telefono);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar teléfono: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> EliminarTelefono(int codProducto)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Telefono/eliminar/{codProducto}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar teléfono: {ex.Message}");
                return false;
            }
        }
   


        // Ventas
        public async Task<bool> RealizarVenta(Factura factura, int numeroCuotas, string cedula)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"Venta/realizarVenta?numeroCuotas={numeroCuotas}&cedula={cedula}", factura);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la venta: {ex.Message}");
                return false;
            }
        }

        // Facturas
        public async Task<List<Factura>> ObtenerFacturas(string cedula)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Factura>>($"Factura/obtenerFacturas/{cedula}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las facturas: {ex.Message}");
                return new List<Factura>();
            }
        }

        public async Task<List<DetalleFactura>> ObtenerDetalleFactura(int codFactura)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<DetalleFactura>>($"Factura/obtenerDetalle/{codFactura}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el detalle de la factura: {ex.Message}");
                return new List<DetalleFactura>();
            }
        }

        // Amortización
        public async Task<List<Amortizacion>> ObtenerAmortizaciones(int codCredito)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Amortizacion>>($"Amortizacion/credito/{codCredito}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener amortizaciones: {ex.Message}");
                return new List<Amortizacion>();
            }
        }
        public async Task<FacturaCompleta> ObtenerFacturaCompleta(int codFactura)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"Factura/obtenerFacturaCompleta/{codFactura}");

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<FacturaCompleta>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el detalle de la factura: {ex.Message}");
                return null;
            }
        }




        public async Task<int> ObtenerUltimoCredito(int codCliente)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<int>($"Amortizacion/cliente/{codCliente}/ultimo-credito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el último crédito: {ex.Message}");
                return -1; // Indica un error
            }
        }
    }
}
