using System;
using System.Windows.Forms;
using ec.edu.monster.controller;

namespace ec.edu.monster.view
{
    public partial class Amortizacion : Form
    {
        private readonly AmortizacionController _amortizacionController;

        public Amortizacion()
        {
            InitializeComponent();
            _amortizacionController = new AmortizacionController();
        }

        // Método renombrado para evitar ambigüedad
        private async void Amortizacion_BtnConsultar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.");
                return;
            }

            var amortizaciones = await _amortizacionController.ConsultarAmortizacionesPorCedula(cedula);

            if (amortizaciones == null || amortizaciones.Count == 0)
            {
                MessageBox.Show("No se encontraron amortizaciones para la cédula ingresada.");
                return;
            }

            dgvAmortizaciones.DataSource = amortizaciones;
        }
    }
}
