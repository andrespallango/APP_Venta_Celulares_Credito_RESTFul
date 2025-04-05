namespace ec.edu.monster.view
{
    partial class Amortizacion
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlLateral;
        private Panel pnlVolver;
        private Label lblVolver;
        private PictureBox pictureBoxLogo;
        private Label lblTitulo;
        private TextBox txtCedula;
        private Button btnConsultar;
        private DataGridView dgvAmortizaciones;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Amortizacion));
            pnlLateral = new Panel();
            pnlVolver = new Panel();
            lblVolver = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            txtCedula = new TextBox();
            btnConsultar = new Button();
            dgvAmortizaciones = new DataGridView();
            pnlLateral.SuspendLayout();
            pnlVolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAmortizaciones).BeginInit();
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
            pnlLateral.Size = new Size(250, 724);
            pnlLateral.TabIndex = 4;
            // 
            // pnlVolver
            // 
            pnlVolver.BackColor = Color.Yellow;
            pnlVolver.Controls.Add(lblVolver);
            pnlVolver.Location = new Point(0, 200);
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
            lblTitulo.Location = new Point(505, 77);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(476, 41);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Consultar Tabla de Amortización";
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCedula.Location = new Point(505, 200);
            txtCedula.Name = "txtCedula";
            txtCedula.PlaceholderText = "Ingrese la cédula del cliente";
            txtCedula.Size = new Size(300, 34);
            txtCedula.TabIndex = 2;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.Navy;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(863, 192);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(100, 50);
            btnConsultar.TabIndex = 1;
            btnConsultar.Text = "Buscar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += Amortizacion_BtnConsultar_Click;
            // 
            // dgvAmortizaciones
            // 
            dgvAmortizaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAmortizaciones.Location = new Point(362, 276);
            dgvAmortizaciones.Name = "dgvAmortizaciones";
            dgvAmortizaciones.RowHeadersWidth = 51;
            dgvAmortizaciones.Size = new Size(769, 300);
            dgvAmortizaciones.TabIndex = 0;
            // 
            // Amortizacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1250, 724);
            Controls.Add(dgvAmortizaciones);
            Controls.Add(btnConsultar);
            Controls.Add(txtCedula);
            Controls.Add(lblTitulo);
            Controls.Add(pnlLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Amortizacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar Tabla de Amortización";
            pnlLateral.ResumeLayout(false);
            pnlVolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAmortizaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            var mainView = new MainView();
            mainView.Show();
            this.Close();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            // Lógica para consultar la tabla de amortización
        }
    }
}
