namespace ec.edu.monster.view
{
    partial class Celulares
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlLateral;
        private Panel pnlVolver;
        private Label lblVolver;
        private PictureBox pictureBoxLogo;
        private Label lblTitulo;
        private Button btnCatalogo;
        private Button btnMantenimiento;
        private Button btnVenta;
        private Button btnFacturas;
        private Button btnAmortizacion;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Celulares));
            pnlLateral = new Panel();
            pnlVolver = new Panel();
            lblVolver = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            btnCatalogo = new Button();
            btnMantenimiento = new Button();
            btnVenta = new Button();
            btnFacturas = new Button();
            btnAmortizacion = new Button();
            pnlLateral.SuspendLayout();
            pnlVolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlLateral
            // 
            pnlLateral.BackColor = Color.White;
            pnlLateral.Controls.Add(pnlVolver);
            pnlLateral.Controls.Add(pictureBoxLogo);
            pnlLateral.Dock = DockStyle.Left;
            pnlLateral.Location = new Point(0, 0);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(250, 809);
            pnlLateral.TabIndex = 6;
            // 
            // pnlVolver
            // 
            pnlVolver.BackColor = Color.Yellow;
            pnlVolver.Controls.Add(lblVolver);
            pnlVolver.Location = new Point(0, 150);
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
            lblVolver.Text = "Volver al Menú Principal";
            lblVolver.TextAlign = ContentAlignment.MiddleCenter;
            lblVolver.Click += BtnVolver_Click_MainView;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(12, 50);
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
            lblTitulo.Location = new Point(600, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(329, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Selecciona una opción";
            // 
            // btnCatalogo
            // 
            btnCatalogo.BackColor = Color.AliceBlue;
            btnCatalogo.FlatStyle = FlatStyle.Flat;
            btnCatalogo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCatalogo.ForeColor = Color.Navy;
            btnCatalogo.Image = (Image)resources.GetObject("btnCatalogo.Image");
            btnCatalogo.ImageAlign = ContentAlignment.TopCenter;
            btnCatalogo.Location = new Point(300, 164);
            btnCatalogo.Name = "btnCatalogo";
            btnCatalogo.Size = new Size(294, 255);
            btnCatalogo.TabIndex = 1;
            btnCatalogo.Text = "Catálogo\nConsulta el catálogo completo de celulares disponibles.";
            btnCatalogo.TextAlign = ContentAlignment.BottomCenter;
            btnCatalogo.UseVisualStyleBackColor = false;
            btnCatalogo.Click += BtnCatalogo_Click;
            // 
            // btnMantenimiento
            // 
            btnMantenimiento.BackColor = Color.AliceBlue;
            btnMantenimiento.FlatStyle = FlatStyle.Flat;
            btnMantenimiento.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMantenimiento.ForeColor = Color.Navy;
            btnMantenimiento.Image = (Image)resources.GetObject("btnMantenimiento.Image");
            btnMantenimiento.ImageAlign = ContentAlignment.TopCenter;
            btnMantenimiento.Location = new Point(631, 164);
            btnMantenimiento.Name = "btnMantenimiento";
            btnMantenimiento.Size = new Size(310, 255);
            btnMantenimiento.TabIndex = 2;
            btnMantenimiento.Text = "Mantenimiento del Catálogo\nGestiona los productos del catálogo de celulares.";
            btnMantenimiento.TextAlign = ContentAlignment.BottomCenter;
            btnMantenimiento.UseVisualStyleBackColor = false;
            btnMantenimiento.Click += BtnMantenimiento_Click;
            // 
            // btnVenta
            // 
            btnVenta.BackColor = Color.AliceBlue;
            btnVenta.FlatStyle = FlatStyle.Flat;
            btnVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVenta.ForeColor = Color.Navy;
            btnVenta.Image = CLIENTE_ESCRITORIO.Properties.Resources.venta;
            btnVenta.ImageAlign = ContentAlignment.TopCenter;
            btnVenta.Location = new Point(987, 164);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new Size(303, 255);
            btnVenta.TabIndex = 3;
            btnVenta.Text = "Registrar Venta\nRegistra la venta de celulares a clientes.";
            btnVenta.TextAlign = ContentAlignment.BottomCenter;
            btnVenta.UseVisualStyleBackColor = false;
            btnVenta.Click += BtnVenta_Click;
            // 
            // btnFacturas
            // 
            btnFacturas.BackColor = Color.AliceBlue;
            btnFacturas.FlatStyle = FlatStyle.Flat;
            btnFacturas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnFacturas.ForeColor = Color.Navy;
            btnFacturas.Image = CLIENTE_ESCRITORIO.Properties.Resources.factura;
            btnFacturas.ImageAlign = ContentAlignment.TopCenter;
            btnFacturas.Location = new Point(430, 460);
            btnFacturas.Name = "btnFacturas";
            btnFacturas.Size = new Size(324, 256);
            btnFacturas.TabIndex = 4;
            btnFacturas.Text = "Mostrar Facturas\nConsulta la factura de una venta realizada.";
            btnFacturas.TextAlign = ContentAlignment.BottomCenter;
            btnFacturas.UseVisualStyleBackColor = false;
            btnFacturas.Click += BtnFacturas_Click;
            // 
            // btnAmortizacion
            // 
            btnAmortizacion.BackColor = Color.AliceBlue;
            btnAmortizacion.FlatStyle = FlatStyle.Flat;
            btnAmortizacion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAmortizacion.ForeColor = Color.Navy;
            btnAmortizacion.Image = (Image)resources.GetObject("btnAmortizacion.Image");
            btnAmortizacion.ImageAlign = ContentAlignment.TopCenter;
            btnAmortizacion.Location = new Point(796, 460);
            btnAmortizacion.Name = "btnAmortizacion";
            btnAmortizacion.Size = new Size(326, 256);
            btnAmortizacion.TabIndex = 5;
            btnAmortizacion.Text = "Tabla de Amortización\nConsulta la tabla de amortización de un cliente.";
            btnAmortizacion.TextAlign = ContentAlignment.BottomCenter;
            btnAmortizacion.UseVisualStyleBackColor = false;
            btnAmortizacion.Click += BtnAmortizacion_Click;
            // 
            // Celulares
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1399, 809);
            Controls.Add(lblTitulo);
            Controls.Add(btnCatalogo);
            Controls.Add(btnMantenimiento);
            Controls.Add(btnVenta);
            Controls.Add(btnFacturas);
            Controls.Add(btnAmortizacion);
            Controls.Add(pnlLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Celulares";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comercializadora de Teléfonos";
            pnlLateral.ResumeLayout(false);
            pnlVolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Regresar al menú principal
            var mainView = new MainView();
            mainView.Show();
            this.Close();
        }
    }
}
