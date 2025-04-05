using System;
using System.Windows.Forms;

namespace ec.edu.monster.view
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void BtnBanco_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ocultar la ventana principal
            var bancoForm = new Banco();
            bancoForm.ShowDialog(); // Mostrar la ventana Banco como modal
            this.Show(); // Mostrar la ventana principal nuevamente al cerrar Banco
        }

        private void BtnCelulares_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ocultar la ventana principal
            var celularesForm = new Celulares();
            celularesForm.ShowDialog(); // Mostrar la ventana Celulares como modal
            this.Show(); // Mostrar la ventana principal nuevamente al cerrar Celulares
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
