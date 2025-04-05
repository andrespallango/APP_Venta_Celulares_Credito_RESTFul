using ec.edu.monster.model;
using System;
using System.Windows.Forms;

namespace ec.edu.monster.view
{
    public partial class Celulares : Form
    {
        public Celulares()
        {
            InitializeComponent();
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            var catalogoForm = new Catalogo();
            catalogoForm.ShowDialog();
        }

        private void BtnMantenimiento_Click(object sender, EventArgs e)
        {
            var mantenimientoForm = new Mantenimiento();
            mantenimientoForm.ShowDialog();
        }

        private void BtnVenta_Click(object sender, EventArgs e)
        {
            var ventaForm = new Venta();
            ventaForm.ShowDialog();
        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            var facturasForm = new Factura();
            facturasForm.ShowDialog();
        }

        private void BtnAmortizacion_Click(object sender, EventArgs e)
        {
            var amortizacionForm = new Amortizacion();
            amortizacionForm.ShowDialog();
        }
        private void BtnVolver_Click_MainView(object sender, EventArgs e)
        {
            var mainView = new MainView();
            mainView.Show();
            this.Close();
        }

    }
}
