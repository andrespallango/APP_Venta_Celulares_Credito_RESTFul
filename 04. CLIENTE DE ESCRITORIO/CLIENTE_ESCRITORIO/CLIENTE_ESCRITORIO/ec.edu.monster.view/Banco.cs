using System;
using System.Windows.Forms;
using ec.edu.monster.controller;

namespace ec.edu.monster.view
{
    public partial class Banco : Form
    {
        private readonly ClienteController _clienteController;

        public Banco()
        {
            InitializeComponent();
            _clienteController = new ClienteController();
        }

        private async void BtnConsultar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            if (string.IsNullOrEmpty(cedula))
            {
                lblResultado.Text = "Ingrese una cédula válida.";
                return;
            }

            await _clienteController.ConsultarCreditoCliente(cedula);
        }
    }
}
