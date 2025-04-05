namespace ec.edu.monster.view
{
    partial class Mantenimiento
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlLateral;
        private Panel pnlVolver;
        private Label lblVolver;
        private PictureBox pictureBoxLogo;
        private Label lblTitulo;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtFoto;
        private TextBox txtCodigo;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblFoto;
        private Label lblCodigo;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mantenimiento));
            pnlLateral = new Panel();
            pnlVolver = new Panel();
            lblVolver = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtFoto = new TextBox();
            txtCodigo = new TextBox();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblFoto = new Label();
            lblCodigo = new Label();
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
            pnlLateral.Size = new Size(250, 782);
            pnlLateral.TabIndex = 12;
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
            lblTitulo.Location = new Point(692, 62);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(423, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Mantenimiento del Catálogo";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Navy;
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(514, 534);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 50);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += BtnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Navy;
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(783, 534);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(150, 50);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Navy;
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(1069, 534);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 50);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(756, 274);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 34);
            txtNombre.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrecio.Location = new Point(756, 339);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(300, 34);
            txtPrecio.TabIndex = 6;
            // 
            // txtFoto
            // 
            txtFoto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFoto.Location = new Point(756, 398);
            txtFoto.Name = "txtFoto";
            txtFoto.Size = new Size(300, 34);
            txtFoto.TabIndex = 8;
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigo.Location = new Point(756, 152);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(300, 34);
            txtCodigo.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(585, 277);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 34);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // lblPrecio
            // 
            lblPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrecio.Location = new Point(585, 339);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(100, 34);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio:";
            // 
            // lblFoto
            // 
            lblFoto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFoto.Location = new Point(585, 398);
            lblFoto.Name = "lblFoto";
            lblFoto.Size = new Size(100, 33);
            lblFoto.TabIndex = 7;
            lblFoto.Text = "Foto (URL):";
            // 
            // lblCodigo
            // 
            lblCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCodigo.Location = new Point(585, 152);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(100, 34);
            lblCodigo.TabIndex = 1;
            lblCodigo.Text = "Código:";
            // 
            // Mantenimiento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1462, 782);
            Controls.Add(lblTitulo);
            Controls.Add(lblCodigo);
            Controls.Add(txtCodigo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblPrecio);
            Controls.Add(txtPrecio);
            Controls.Add(lblFoto);
            Controls.Add(txtFoto);
            Controls.Add(btnAgregar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(pnlLateral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Mantenimiento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenimiento del Catálogo";
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
