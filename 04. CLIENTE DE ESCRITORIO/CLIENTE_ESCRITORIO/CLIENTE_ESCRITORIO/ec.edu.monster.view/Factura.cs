using System;
using System.Windows.Forms;
using ec.edu.monster.controller;

namespace ec.edu.monster.view
{
    public partial class Factura : Form
    {
        private readonly FacturaController _facturaController;

        public Factura()
        {
            InitializeComponent();
            _facturaController = new FacturaController();
        }

        private async void BtnConsultar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.");
                return;
            }

            var facturas = await _facturaController.ObtenerFacturasPorCedula(cedula);

            if (facturas == null || facturas.Count == 0)
            {
                MessageBox.Show("No se encontraron facturas para la cédula ingresada.");
                return;
            }

            dgvFacturas.DataSource = facturas;
        }

        private async void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int codFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells["CodFactura"].Value);

                // Obtener detalle de la factura
                string detalleFactura = await _facturaController.ObtenerDetalleFactura(codFactura);

                // Mostrar en el TextBox
                txtDetalleFactura.Text = detalleFactura;
            }
        }

    }
}
