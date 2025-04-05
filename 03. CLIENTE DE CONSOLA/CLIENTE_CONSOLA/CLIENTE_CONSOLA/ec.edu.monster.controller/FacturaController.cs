using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ec.edu.monster.service;
using ec.edu.monster.model;

namespace ec.edu.monster.controller
{
    public class FacturaController
    {
        private readonly ApiService _apiService;

        public FacturaController()
        {
            _apiService = new ApiService();
        }

        // Consultar facturas por cédula
        public async Task ObtenerFacturas()
        {
            Console.Write("\nIngrese la cédula del cliente: ");
            string cedula = Console.ReadLine()?.Trim();

            // Obtener facturas del cliente
            List<Factura> facturas = await _apiService.ObtenerFacturas(cedula);

            if (facturas == null || facturas.Count == 0)
            {
                Console.WriteLine("\nNo se encontraron facturas para la cédula ingresada.");
                return;
            }

            Console.WriteLine("\nFacturas del Cliente:");
            foreach (var factura in facturas)
            {
                Console.WriteLine($"Factura #{factura.CodFactura} - Total: ${factura.Total:F2} - Pago: {factura.FormaPago}");
            }

            Console.Write("\n¿Desea consultar el detalle completo de alguna factura? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.Write("\nIngrese el código de la factura: ");
                if (!int.TryParse(Console.ReadLine(), out int codFactura))
                {
                    Console.WriteLine("Código inválido. Intente nuevamente.");
                    return;
                }

                await ConsultarFacturaCompleta(codFactura);
            }
        }

        // Consultar detalles completos de una factura específica
        private async Task ConsultarFacturaCompleta(int codFactura)
        {
            var facturaCompleta = await _apiService.ObtenerFacturaCompleta(codFactura);

            if (facturaCompleta == null)
            {
                Console.WriteLine("\nNo se encontró información para la factura ingresada.");
                return;
            }

            // Mostrar información general de la factura
            Console.WriteLine("\nDetalle Completo de la Factura:");
            Console.WriteLine($"Fecha: {facturaCompleta.Factura.Fecha}");
            Console.WriteLine($"Cliente: {facturaCompleta.Factura.Cliente.Nombre} (Cédula: {facturaCompleta.Factura.Cliente.Cedula})");
            Console.WriteLine($"Forma de Pago: {facturaCompleta.Factura.FormaPago}");
            Console.WriteLine($"Subtotal: ${facturaCompleta.Subtotal:F2}");
            Console.WriteLine($"IVA: ${facturaCompleta.IVA:F2}");
            Console.WriteLine($"Total: ${facturaCompleta.TotalConIVA:F2}");

            // Mostrar los detalles de la factura
            Console.WriteLine("\nDetalles de la Factura:");
            Console.WriteLine($"{"Producto",-20} {"Cantidad",-10} {"Precio Unitario",-15} {"Subtotal",-10}");
            foreach (var detalle in facturaCompleta.Detalles)
            {
                Console.WriteLine($"{detalle.NombreProducto,-20} {detalle.Cantidad,-10} ${detalle.PrecioUnitario,-15:F2} ${detalle.Subtotal,-10:F2}");
            }
        }

    }
}
