namespace ec.edu.monster.view
{
    partial class Catalogo
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlLateral;
        private Panel pnlVolver;
        private Label lblVolver;
        private PictureBox pictureBoxLogo;
        private Label lblTitulo;
        private DataGridView dgvCatalogo;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Catalogo));
            pnlLateral = new Panel();
            pnlVolver = new Panel();
            lblVolver = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            dgvCatalogo = new DataGridView();
            pnlLateral.SuspendLayout();
            pnlVolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
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
            pnlLateral.TabIndex = 2;
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
            lblTitulo.Location = new Point(589, 50);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(324, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Catálogo de Celulares";
            // 
            // dgvCatalogo
            // 
            dgvCatalogo.AllowUserToAddRows = false;
            dgvCatalogo.AllowUserToDeleteRows = false;
            dgvCatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCatalogo.BackgroundColor = Color.White;
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalogo.Location = new Point(398, 168);
            dgvCatalogo.Name = "dgvCatalogo";
            dgvCatalogo.RowHeadersWidth = 51;
            dgvCatalogo.RowTemplate.Height = 25;
            dgvCatalogo.Size = new Size(700, 400);
            dgvCatalogo.TabIndex = 1;
            // 
            // Catalogo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1250, 724);
            Controls.Add(lblTitulo);
            Controls.Add(dgvCatalogo);
            Controls.Add(pnlLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Catalogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo de Celulares";
            pnlLateral.ResumeLayout(false);
            pnlVolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            // Crear una instancia de MainView
            var mainView = new MainView();

            // Mostrar MainView
            mainView.Show();

            // Cerrar la ventana actual (Catalogo)
            this.Close();
        }
    }
}
