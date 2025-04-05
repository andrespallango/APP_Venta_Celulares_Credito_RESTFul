namespace ec.edu.monster.view
{
    partial class Banco
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlLateral;
        private Panel pnlVolver;
        private Label lblVolver;
        private PictureBox pictureBoxLogo;
        private Label lblTitulo;
        private TextBox txtCedula;
        private Button btnConsultar;
        private Label lblResultado;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Banco));
            pnlLateral = new Panel();
            pnlVolver = new Panel();
            lblVolver = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            txtCedula = new TextBox();
            btnConsultar = new Button();
            lblResultado = new Label();
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
            pnlLateral.Size = new Size(252, 740);
            pnlLateral.TabIndex = 4;
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
            pictureBoxLogo.Location = new Point(12, 47);
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
            lblTitulo.Location = new Point(572, 137);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(390, 41);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Verificar Sujeto de Crédito";
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCedula.Location = new Point(618, 238);
            txtCedula.Name = "txtCedula";
            txtCedula.PlaceholderText = "Ingrese su cédula";
            txtCedula.Size = new Size(300, 34);
            txtCedula.TabIndex = 2;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.Navy;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(618, 309);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(300, 50);
            btnConsultar.TabIndex = 1;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += BtnConsultar_Click;
            // 
            // lblResultado
            // 
            lblResultado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultado.ForeColor = Color.Black;
            lblResultado.Location = new Point(618, 414);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(300, 50);
            lblResultado.TabIndex = 0;
            lblResultado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Banco
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1270, 740);
            Controls.Add(lblResultado);
            Controls.Add(btnConsultar);
            Controls.Add(txtCedula);
            Controls.Add(lblTitulo);
            Controls.Add(pnlLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Banco";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Banco BanQuito";
            pnlLateral.ResumeLayout(false);
            pnlVolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Crear una instancia de MainView
            var mainView = new MainView();

            // Mostrar MainView
            mainView.Show();

            // Cerrar la ventana actual (Banco)
            this.Close();
        }

    }
}
