using ec.edu.monster.controller;

namespace ec.edu.monster.view
{
    partial class Factura
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvFacturas;
        private TextBox txtCedula;
        private Button btnConsultar;
        private Panel pnlLateral;
        private Panel pnlVolver;
        private Label lblVolver;
        private PictureBox pictureBoxLogo;
        private TextBox txtDetalleFactura;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            dgvFacturas = new DataGridView();
            txtCedula = new TextBox();
            txtDetalleFactura = new TextBox();
            btnConsultar = new Button();
            pnlLateral = new Panel();
            pnlVolver = new Panel();
            lblVolver = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            pnlLateral.SuspendLayout();
            pnlVolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(429, 314);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.RowHeadersWidth = 51;
            dgvFacturas.Size = new Size(700, 175);
            dgvFacturas.TabIndex = 0;
            dgvFacturas.CellClick += dgvFacturas_CellClick;
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCedula.Location = new Point(637, 170);
            txtCedula.Name = "txtCedula";
            txtCedula.PlaceholderText = "Ingrese la cédula";
            txtCedula.Size = new Size(300, 34);
            txtCedula.TabIndex = 2;
            // 
            // txtDetalleFactura
            // 
            txtDetalleFactura.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDetalleFactura.Location = new Point(429, 527);
            txtDetalleFactura.Multiline = true;
            txtDetalleFactura.Name = "txtDetalleFactura";
            txtDetalleFactura.ReadOnly = true;
            txtDetalleFactura.ScrollBars = ScrollBars.Vertical;
            txtDetalleFactura.Size = new Size(700, 293);
            txtDetalleFactura.TabIndex = 5;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.Navy;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(637, 230);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(300, 50);
            btnConsultar.TabIndex = 1;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += Factura_BtnConsultar_Click;
            // 
            // pnlLateral
            // 
            pnlLateral.BackColor = Color.White;
            pnlLateral.Controls.Add(pnlVolver);
            pnlLateral.Controls.Add(pictureBoxLogo);
            pnlLateral.Dock = DockStyle.Left;
            pnlLateral.Location = new Point(0, 0);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(250, 835);
            pnlLateral.TabIndex = 3;
            // 
            // pnlVolver
            // 
            pnlVolver.BackColor = Color.Yellow;
            pnlVolver.Controls.Add(lblVolver);
            pnlVolver.Location = new Point(0, 230);
            pnlVolver.Name = "pnlVolver";
            pnlVolver.Size = new Size(250, 50);
            pnlVolver.TabIndex = 0;
            // 
            // lblVolver
            // 
            lblVolver.BackColor = Color.Gold;
            lblVolver.Dock = DockStyle.Fill;
            lblVolver.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblVolver.ForeColor = Color.Blue;
            lblVolver.Location = new Point(0, 0);
            lblVolver.Name = "lblVolver";
            lblVolver.Size = new Size(250, 50);
            lblVolver.TabIndex = 0;
            lblVolver.Text = "Volver";
            lblVolver.TextAlign = ContentAlignment.MiddleCenter;
            lblVolver.Click += BtnVolver_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(12, 31);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(220, 60);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.Navy;
            lblTitulo.Location = new Point(642, 78);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(295, 41);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Consulta de Factura";
            // 
            // Factura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1250, 835);
            Controls.Add(txtDetalleFactura);
            Controls.Add(lblTitulo);
            Controls.Add(dgvFacturas);
            Controls.Add(btnConsultar);
            Controls.Add(txtCedula);
            Controls.Add(pnlLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Factura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar Facturas";
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            pnlLateral.ResumeLayout(false);
            pnlVolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Retornar al menú principal
            var mainView = new MainView();
            mainView.Show();
            this.Close();
        }

        private async void Factura_BtnConsultar_Click(object sender, EventArgs e)
        {
            // Obtener la cédula ingresada por el usuario
            string cedula = txtCedula.Text.Trim();

            // Validar si el campo de cédula está vacío
            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instancia del controlador de facturas
            FacturaController facturaController = new FacturaController();

            try
            {
                // Consultar las facturas asociadas a la cédula
                var facturas = await facturaController.ObtenerFacturasPorCedula(cedula);

                // Validar si se encontraron facturas
                if (facturas == null || facturas.Count == 0)
                {
                    MessageBox.Show("No se encontraron facturas para la cédula ingresada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvFacturas.DataSource = null; // Limpiar la tabla si no hay resultados
                }
                else
                {
                    // Mostrar las facturas en el DataGridView
                    dgvFacturas.DataSource = facturas;

                    // Ajustar el ancho de las columnas para que se ajusten automáticamente al contenido
                    dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al realizar la consulta
                MessageBox.Show($"Ocurrió un error al consultar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Label lblTitulo;
    }
}
