using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ec.edu.monster.service;
using ec.edu.monster.model;
using ec.edu.monster.view;
using System.Windows.Forms.Design;

namespace ec.edu.monster.controller
{
    public class AmortizacionController
    {
        private readonly ApiService _apiService;

        public AmortizacionController()
        {
            _apiService = new ApiService();
        }

        public async Task<List<model.Amortizacion>> ConsultarAmortizacionesPorCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("La cédula es obligatoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<model.Amortizacion>();
            }

            try
            {
                int codCliente = await _apiService.ObtenerCodigoCliente(cedula);
                if (codCliente == -1)
                {
                    MessageBox.Show("No se encontró un cliente con la cédula ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<model.Amortizacion>();
                }

                int codCredito = await _apiService.ObtenerUltimoCredito(codCliente);
                if (codCredito == -1)
                {
                    MessageBox.Show("El cliente no tiene créditos activos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return new List<model.Amortizacion>();
                }

                return await _apiService.ObtenerAmortizaciones(codCredito);
            }
            catch
            {
                MessageBox.Show("Error al obtener la tabla de amortización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<model.Amortizacion>();
            }
        }
    }
}
