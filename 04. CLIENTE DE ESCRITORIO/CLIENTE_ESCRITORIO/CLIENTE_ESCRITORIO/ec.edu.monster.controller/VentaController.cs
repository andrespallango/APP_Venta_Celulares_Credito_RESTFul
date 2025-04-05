using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ec.edu.monster.service;
using ec.edu.monster.model;

namespace ec.edu.monster.controller
{
    public class VentaController
    {
        private readonly ApiService _apiService;

        public VentaController()
        {
            _apiService = new ApiService();
        }

        public async Task<bool> RealizarVenta(Factura factura, int numeroCuotas, string cedula)
        {
            if (factura == null || factura.Detalles.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("Debe ingresar la cédula del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (factura.FormaPago == "Crédito" && (numeroCuotas < 3 || numeroCuotas > 18))
            {
                MessageBox.Show("El número de cuotas debe estar entre 3 y 18 para crédito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                bool resultado = await _apiService.RealizarVenta(factura, numeroCuotas, cedula);
                if (resultado)
                {
                    MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
