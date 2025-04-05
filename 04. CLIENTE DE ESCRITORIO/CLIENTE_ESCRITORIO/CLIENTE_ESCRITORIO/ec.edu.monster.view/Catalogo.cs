using System;
using System.Windows.Forms;
using ec.edu.monster.controller;

namespace ec.edu.monster.view
{
    public partial class Catalogo : Form
    {
        private readonly TelefonoController _telefonoController;

        public Catalogo()
        {
            InitializeComponent();
            _telefonoController = new TelefonoController();
            LoadCatalogo();
        }

        private async void LoadCatalogo()
        {
            var telefonos = await _telefonoController.ListarTelefonos();
            dgvCatalogo.DataSource = telefonos;
        }
    }
}
