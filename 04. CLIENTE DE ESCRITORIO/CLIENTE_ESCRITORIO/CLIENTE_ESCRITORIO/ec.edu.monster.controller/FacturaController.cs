using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ec.edu.monster.service;
using ec.edu.monster.model;
using ec.edu.monster.view;
using System.Windows.Forms.Design;

namespace ec.edu.monster.controller
{
    public class FacturaController
    {
        private readonly ApiService _apiService;

        public FacturaController()
        {
            _apiService = new ApiService();
        }

        public async Task<List<model.Factura>> ObtenerFacturasPorCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("La cédula es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<model.Factura>();
            }

            try
            {
                return await _apiService.ObtenerFacturas(cedula);
            }
            catch
            {
                MessageBox.Show("Error al obtener las facturas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<model.Factura>();
            }
        }


        public async Task<string> ObtenerDetalleFactura(int codFactura)
        {
            try
            {
                // Obtén el objeto FacturaCompleta desde el servicio
                var facturaCompleta = await _apiService.ObtenerFacturaCompleta(codFactura);

                // Verifica si la factura es nula
                if (facturaCompleta == null)
                {
                    return "No se encontró el detalle de la factura.";
                }

                // Extrae datos de la factura y el cliente
                var cliente = facturaCompleta.Factura.Cliente;
                string nombreCliente = cliente.Nombre;
                string cedulaCliente = cliente.Cedula;

                // Construye el detalle de la factura
                string detalleTexto = new string('-', 50) + Environment.NewLine;
                detalleTexto += "                 FACTURA DE COMPRA          " + Environment.NewLine;
                detalleTexto += new string('-', 50) + Environment.NewLine;
                detalleTexto += $"Fecha: {facturaCompleta.Factura.Fecha:dd/MM/yyyy}" + Environment.NewLine;
                detalleTexto += $"Cliente: {nombreCliente}" + Environment.NewLine;
                detalleTexto += $"Cédula: {cedulaCliente}" + Environment.NewLine;
                detalleTexto += $"Forma de Pago: {facturaCompleta.Factura.FormaPago}" + Environment.NewLine;
                detalleTexto += new string('-', 50) + Environment.NewLine;
                detalleTexto += $"{"Cant.",-6}{"Producto",-20}{"P. Unit",-10}{"Subtotal",-10}" + Environment.NewLine;
                detalleTexto += new string('-', 50) + Environment.NewLine;

                double totalConIva = facturaCompleta.Factura.Total; // El total desde la factura
                double subtotalSinIva = totalConIva / 1.12; // Subtotal antes del IVA
                double iva = totalConIva - subtotalSinIva;  // IVA es la diferencia

                foreach (var item in facturaCompleta.Detalles)
                {
                    detalleTexto += $"{item.Cantidad,-6}{item.CodProducto,-20}${item.PrecioUnitario,-10:F2}${item.Subtotal,-10:F2}" + Environment.NewLine;
                }

                detalleTexto += new string('-', 50) + Environment.NewLine;
                detalleTexto += $"{"Subtotal antes de IVA:",-35}${subtotalSinIva,10:F2}" + Environment.NewLine;
                detalleTexto += $"{"IVA (12%):",-35}${iva,10:F2}" + Environment.NewLine;
                detalleTexto += $"{"Total a Pagar:",-35}${totalConIva,10:F2}" + Environment.NewLine;
                detalleTexto += new string('-', 50) + Environment.NewLine;

                return detalleTexto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el detalle de la factura: {ex.Message}");
                return "Error al obtener el detalle de la factura.";
            }
        }



    }
}
