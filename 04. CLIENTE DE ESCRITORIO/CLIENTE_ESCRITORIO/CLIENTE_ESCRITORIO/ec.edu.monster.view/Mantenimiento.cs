using System;
using System.Windows.Forms;
using ec.edu.monster.controller;
using ec.edu.monster.model;

namespace ec.edu.monster.view
{
    public partial class Mantenimiento : Form
    {
        private readonly TelefonoController _telefonoController;

        public Mantenimiento()
        {
            InitializeComponent();
            _telefonoController = new TelefonoController();
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            var telefono = new Telefono
            {
                Nombre = txtNombre.Text.Trim(),
                Precio = double.TryParse(txtPrecio.Text.Trim(), out var precio) ? precio : 0,
                Foto = txtFoto.Text.Trim()
            };

            var result = await _telefonoController.CrearTelefono(telefono);
            MessageBox.Show(result ? "Teléfono agregado correctamente." : "Error al agregar teléfono.");
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            var telefono = new Telefono
            {
                CodProducto = int.TryParse(txtCodigo.Text.Trim(), out var cod) ? cod : 0,
                Nombre = txtNombre.Text.Trim(),
                Precio = double.TryParse(txtPrecio.Text.Trim(), out var precio) ? precio : 0,
                Foto = txtFoto.Text.Trim()
            };

            var result = await _telefonoController.ActualizarTelefono(telefono);
            MessageBox.Show(result ? "Teléfono actualizado correctamente." : "Error al actualizar teléfono.");
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigo.Text.Trim(), out var codProducto))
            {
                var result = await _telefonoController.EliminarTelefono(codProducto);
                MessageBox.Show(result ? "Teléfono eliminado correctamente." : "Error al eliminar teléfono.");
            }
            else
            {
                MessageBox.Show("Ingrese un código válido para eliminar.");
            }
        }
    }
}
