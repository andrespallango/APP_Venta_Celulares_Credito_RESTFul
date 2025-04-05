using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ec.edu.monster.service;

namespace ec.edu.monster.controller
{
    public class BancoController
    {
        private readonly ApiService _apiService;

        public BancoController()
        {
            _apiService = new ApiService();
        }

        public async Task ConsultarCreditoCliente(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("La cédula es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si es sujeto de crédito
            bool esSujetoDeCredito = await _apiService.EsSujetoDeCredito(cedula);

            if (esSujetoDeCredito)
            {
                int codCliente = await _apiService.ObtenerCodigoCliente(cedula);
                if (codCliente == -1)
                {
                    MessageBox.Show("No se encontró un cliente con la cédula ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double montoMaximo = await _apiService.CalcularMontoMaximoCredito(codCliente);
                MessageBox.Show($"El cliente es sujeto de crédito.\nMonto máximo de crédito: ${montoMaximo:F2}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El cliente no es sujeto de crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
