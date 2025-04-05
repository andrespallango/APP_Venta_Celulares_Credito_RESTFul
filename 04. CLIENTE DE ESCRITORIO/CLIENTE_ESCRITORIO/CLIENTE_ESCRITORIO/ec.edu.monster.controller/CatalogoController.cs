using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ec.edu.monster.service;
using ec.edu.monster.model;
using System.Windows.Forms.Design;

namespace ec.edu.monster.controller
{
    public class CatalogoController
    {
        private readonly ApiService _apiService;

        public CatalogoController()
        {
            _apiService = new ApiService();
        }

        public async Task<List<Telefono>> ObtenerCatalogo()
        {
            try
            {
                return await _apiService.ListarTelefonos();
            }
            catch
            {
                MessageBox.Show("Error al obtener el catálogo de teléfonos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Telefono>();
            }
        }
    }
}
