using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ec.edu.monster.service;

namespace ec.edu.monster.controller
{
    public class ClienteController
    {
        private readonly ApiService _apiService;

        public ClienteController()
        {
            _apiService = new ApiService();
        }

        /// <summary>
        /// Consulta si el cliente es sujeto de crédito y su monto máximo.
        /// </summary>
        public async Task<int> ObtenerCodigoCliente(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("La cédula es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1; // Código de error
            }

            try
            {
                return await _apiService.ObtenerCodigoCliente(cedula);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el código del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Código de error
            }
        }

        /// <summary>
        /// Verifica si el cliente es sujeto de crédito.
        /// </summary>
        public async Task<bool> EsSujetoDeCredito(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("La cédula es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                return await _apiService.EsSujetoDeCredito(cedula);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Calcula el monto máximo de crédito para un cliente.
        /// </summary>
        public async Task<double> CalcularMontoMaximoCredito(int codCliente)
        {
            try
            {
                return await _apiService.CalcularMontoMaximoCredito(codCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular monto máximo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public async Task ConsultarCreditoCliente(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("La cédula es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Verificar si el cliente es sujeto de crédito
                bool esSujetoDeCredito = await _apiService.EsSujetoDeCredito(cedula);

                if (esSujetoDeCredito)
                {
                    // Obtener el código del cliente
                    int codCliente = await _apiService.ObtenerCodigoCliente(cedula);
                    if (codCliente == -1)
                    {
                        MessageBox.Show("No se encontró un cliente con la cédula ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Obtener el monto máximo de crédito
                    double montoMaximo = await _apiService.CalcularMontoMaximoCredito(codCliente);
                    MessageBox.Show($"El cliente es sujeto de crédito.\nMonto máximo de crédito: ${montoMaximo:F2}",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El cliente no es sujeto de crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar el crédito del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
