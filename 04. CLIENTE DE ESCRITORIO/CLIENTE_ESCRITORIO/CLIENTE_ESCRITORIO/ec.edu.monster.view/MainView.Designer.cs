namespace ec.edu.monster.view
{
    partial class MainView
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Panel pnlMenu;
        private Panel pnlLateral;
        private Button btnBanco;
        private Button btnCelulares;
        private Panel pnlInicio;
        private Label lblInicio;
        private PictureBox pictureBoxLogo;
        private PictureBox pictureBoxBanco;
        private PictureBox pictureBoxCelulares;

        /// <summary>
        /// Limpiar recursos.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Inicializar los componentes del formulario.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            lblTitulo = new Label();
            pnlLateral = new Panel();
            pnlInicio = new Panel();
            lblInicio = new Label();
            pictureBoxLogo = new PictureBox();
            btnBanco = new Button();
            btnCelulares = new Button();
            pictureBoxBanco = new PictureBox();
            pictureBoxCelulares = new PictureBox();
            pnlLateral.SuspendLayout();
            pnlInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBanco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCelulares).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.Navy;
            lblTitulo.Location = new Point(561, 131);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(329, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Selecciona una opción";
            // 
            // pnlLateral
            // 
            pnlLateral.BackColor = Color.White;
            pnlLateral.Controls.Add(pnlInicio);
            pnlLateral.Controls.Add(pictureBoxLogo);
            pnlLateral.Dock = DockStyle.Left;
            pnlLateral.Location = new Point(0, 0);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(250, 724);
            pnlLateral.TabIndex = 3;
            // 
            // pnlInicio
            // 
            pnlInicio.BackColor = Color.Yellow;
            pnlInicio.Controls.Add(lblInicio);
            pnlInicio.Location = new Point(0, 150);
            pnlInicio.Name = "pnlInicio";
            pnlInicio.Size = new Size(250, 50);
            pnlInicio.TabIndex = 0;
            // 
            // lblInicio
            // 
            lblInicio.BackColor = Color.Gold;
            lblInicio.Dock = DockStyle.Fill;
            lblInicio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblInicio.ForeColor = Color.Blue;
            lblInicio.Location = new Point(0, 0);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(250, 50);
            lblInicio.TabIndex = 0;
            lblInicio.Text = "Inicio";
            lblInicio.TextAlign = ContentAlignment.MiddleCenter;
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
            // btnBanco
            btnBanco.BackColor = Color.AliceBlue;
            btnBanco.FlatStyle = FlatStyle.Flat;
            btnBanco.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBanco.ForeColor = Color.Navy;
            btnBanco.Image = (Image)resources.GetObject("btnBanco.Image");
            btnBanco.ImageAlign = ContentAlignment.TopCenter;
            btnBanco.Location = new Point(411, 231);
            btnBanco.Name = "btnBanco";
            btnBanco.Size = new Size(300, 250);
            btnBanco.TabIndex = 1;
            btnBanco.Text = "Banco BanQuito\nConsulta de crédito y más opciones bancarias.";
            btnBanco.TextAlign = ContentAlignment.BottomCenter;
            btnBanco.UseVisualStyleBackColor = false;
            btnBanco.Click += BtnBanco_Click; // <-- Aquí se asigna el evento

            // btnCelulares
            btnCelulares.BackColor = Color.AliceBlue;
            btnCelulares.FlatStyle = FlatStyle.Flat;
            btnCelulares.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCelulares.ForeColor = Color.Navy;
            btnCelulares.Image = (Image)resources.GetObject("btnCelulares.Image");
            btnCelulares.ImageAlign = ContentAlignment.TopCenter;
            btnCelulares.Location = new Point(761, 231);
            btnCelulares.Name = "btnCelulares";
            btnCelulares.Size = new Size(300, 250);
            btnCelulares.TabIndex = 2;
            btnCelulares.Text = "Comercializadora de Celulares\nGestiona tu catálogo y realiza ventas.";
            btnCelulares.TextAlign = ContentAlignment.BottomCenter;
            btnCelulares.UseVisualStyleBackColor = false;
            btnCelulares.Click += BtnCelulares_Click; // <-- Aquí se asigna el evento

            // 
            // pictureBoxBanco
            // 
            pictureBoxBanco.Location = new Point(350, 180);
            pictureBoxBanco.Name = "pictureBoxBanco";
            pictureBoxBanco.Size = new Size(100, 100);
            pictureBoxBanco.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBanco.TabIndex = 0;
            pictureBoxBanco.TabStop = false;
            // 
            // pictureBoxCelulares
            // 
            pictureBoxCelulares.Location = new Point(700, 180);
            pictureBoxCelulares.Name = "pictureBoxCelulares";
            pictureBoxCelulares.Size = new Size(100, 100);
            pictureBoxCelulares.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCelulares.TabIndex = 0;
            pictureBoxCelulares.TabStop = false;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1250, 724);
            Controls.Add(lblTitulo);
            Controls.Add(btnBanco);
            Controls.Add(btnCelulares);
            Controls.Add(pnlLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            pnlLateral.ResumeLayout(false);
            pnlInicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBanco).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCelulares).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
