using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ec.edu.monster.model;

namespace ec.edu.monster.service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5182/api/") }; // URL base del servidor
        }

        // 📌 AMORTIZACIÓN

        public async Task<List<Amortizacion>> ObtenerAmortizaciones(int codCredito)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Amortizacion>>($"Amortizacion/credito/{codCredito}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener amortizaciones: ");
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
                Console.WriteLine($"Error al obtener último crédito: ");
                return -1;
            }
        }

        // 📌 CLIENTE

        public async Task<bool> EsSujetoDeCredito(string cedula)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<bool>($"Cliente/esSujetoDeCredito/{cedula}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar sujeto de crédito: ");
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
                Console.WriteLine($"Error al obtener código de cliente: ");
                return -1;
            }
        }

        // 📌 FACTURAS

        public async Task<List<Factura>> ObtenerFacturas(string cedula)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Factura>>($"Factura/obtenerFacturas/{cedula}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener facturas: ");
                return null;
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
                Console.WriteLine($"Error al obtener detalles de factura: ");
                return null;
            }
        }

        public async Task<bool> CrearFactura(Factura factura)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Factura/crear", factura);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear factura: ");
                return false;
            }
        }

        // 📌 TELÉFONOS

        public async Task<List<Telefono>> ListarTelefonos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Telefono>>("Telefono/listar");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar teléfonos: ");
                return null;
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
                Console.WriteLine($"Error al crear teléfono: ");
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
                Console.WriteLine($"Error al actualizar teléfono: ");
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
                Console.WriteLine($"Error al eliminar teléfono: ");
                return false;
            }
        }

        // 📌 CRÉDITO

        public async Task<double> CalcularMontoMaximoCredito(int codCliente)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"Cliente/calcularMontoMaximoCredito/{codCliente}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular monto máximo de crédito: ");
                return 0;
            }
        }

        // 📌 VENTA

        public async Task<bool> RealizarVenta(Factura factura, int numeroCuotas, string cedula)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"Venta/realizarVenta?numeroCuotas={numeroCuotas}&cedula={cedula}", factura);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar venta: ");
                return false;
            }
        }

        public async Task<FacturaCompleta> ObtenerFacturaCompleta(int codFactura)
        {
            return await _httpClient.GetFromJsonAsync<FacturaCompleta>($"Factura/obtenerFacturaCompleta/{codFactura}");
        }


    }
}
