using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ec.edu.monster.service;
using ec.edu.monster.model;

namespace ec.edu.monster.controller
{
    public class TelefonoController
    {
        private readonly ApiService _apiService;

        public TelefonoController()
        {
            _apiService = new ApiService();
        }

        /// <summary>
        /// Obtiene la lista de teléfonos disponibles en el catálogo.
        /// </summary>
        public async Task<List<Telefono>> ListarTelefonos()
        {
            try
            {
                return await _apiService.ListarTelefonos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al obtener el catálogo de teléfonos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Telefono>();
            }
        }

        /// <summary>
        /// Crea un nuevo teléfono en el sistema.
        /// </summary>
        public async Task<bool> CrearTelefono(Telefono telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono.Nombre) || telefono.Precio <= 0)
            {
                MessageBox.Show("Los datos del teléfono son inválidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                bool resultado = await _apiService.CrearTelefono(telefono);
                if (resultado)
                {
                    MessageBox.Show("Teléfono agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al registrar el teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Actualiza la información de un teléfono existente.
        /// </summary>
        public async Task<bool> ActualizarTelefono(Telefono telefono)
        {
            if (telefono.CodProducto <= 0 || string.IsNullOrWhiteSpace(telefono.Nombre) || telefono.Precio <= 0)
            {
                MessageBox.Show("Los datos del teléfono son inválidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                bool resultado = await _apiService.ActualizarTelefono(telefono);
                if (resultado)
                {
                    MessageBox.Show("Teléfono actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar el teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Elimina un teléfono del catálogo.
        /// </summary>
        public async Task<bool> EliminarTelefono(int codProducto)
        {
            if (codProducto <= 0)
            {
                MessageBox.Show("Código de producto inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                bool resultado = await _apiService.EliminarTelefono(codProducto);
                if (resultado)
                {
                    MessageBox.Show("Teléfono eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el teléfono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
