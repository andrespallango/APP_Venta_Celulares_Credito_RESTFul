namespace ec.edu.monster.view
{
    partial class Venta
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlLateral;
        private Panel pnlVolver;
        private Label lblVolver;
        private PictureBox pictureBoxLogo;
        private Label lblTitulo;
        private Label lblCedula;
        private TextBox txtCedula;
        private Button btnComprobar;
        private Label lblResultado;
        private ComboBox cmbTelefonos;
        private NumericUpDown numCantidad;
        private Button btnAgregar;
        private DataGridView dgvDetalleVenta;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblFormaPago;
        private ComboBox cmbFormaPago;
        private NumericUpDown numCuotas;
        private Label lblCuotas;
        private Button btnRealizarVenta;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venta));
            pnlLateral = new Panel();
            pnlVolver = new Panel();
            lblVolver = new Label();
            pictureBoxLogo = new PictureBox();
            lblTitulo = new Label();
            lblCedula = new Label();
            txtCedula = new TextBox();
            btnComprobar = new Button();
            lblResultado = new Label();
            cmbTelefonos = new ComboBox();
            numCantidad = new NumericUpDown();
            btnAgregar = new Button();
            dgvDetalleVenta = new DataGridView();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblFormaPago = new Label();
            cmbFormaPago = new ComboBox();
            lblCuotas = new Label();
            numCuotas = new NumericUpDown();
            btnRealizarVenta = new Button();
            label1 = new Label();
            pnlLateral.SuspendLayout();
            pnlVolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCuotas).BeginInit();
            SuspendLayout();

            // pnlLateral
            pnlLateral.BackColor = Color.White;
            pnlLateral.Controls.Add(pnlVolver);
            pnlLateral.Controls.Add(pictureBoxLogo);
            pnlLateral.Dock = DockStyle.Left;
            pnlLateral.Location = new Point(0, 0);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(250, 812);
            pnlLateral.TabIndex = 12;

            // pnlVolver
            pnlVolver.BackColor = Color.Yellow;
            pnlVolver.Controls.Add(lblVolver);
            pnlVolver.Location = new Point(0, 230);
            pnlVolver.Name = "pnlVolver";
            pnlVolver.Size = new Size(250, 50);
            pnlVolver.TabIndex = 0;

            // lblVolver
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

            // pictureBoxLogo
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(12, 31);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(220, 60);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.Navy;
            lblTitulo.Location = new Point(650, 50);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(403, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Realizar Venta de Teléfonos";

            // lblCedula
            lblCedula.AutoSize = true;
            lblCedula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCedula.Location = new Point(512, 142);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(76, 28);
            lblCedula.TabIndex = 1;
            lblCedula.Text = "Cédula:";

            // txtCedula
            txtCedula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCedula.Location = new Point(619, 139);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(434, 34);
            txtCedula.TabIndex = 2;

            // btnComprobar
            btnComprobar.BackColor = Color.Navy;
            btnComprobar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnComprobar.ForeColor = Color.White;
            btnComprobar.Location = new Point(1101, 131);
            btnComprobar.Name = "btnComprobar";
            btnComprobar.Size = new Size(150, 50);
            btnComprobar.TabIndex = 3;
            btnComprobar.Text = "Comprobar";
            btnComprobar.UseVisualStyleBackColor = false;
            btnComprobar.Click += btnComprobar_Click;

            // lblResultado
            lblResultado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultado.Location = new Point(613, 198);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(500, 45);
            lblResultado.TabIndex = 4;

            // cmbTelefonos
            cmbTelefonos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTelefonos.Location = new Point(543, 349);
            cmbTelefonos.Name = "cmbTelefonos";
            cmbTelefonos.Size = new Size(300, 36);
            cmbTelefonos.TabIndex = 5;

            // numCantidad
            numCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numCantidad.Location = new Point(863, 349);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(80, 34);
            numCantidad.TabIndex = 6;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnAgregar
            btnAgregar.BackColor = Color.Navy;
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(972, 348);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(279, 34);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;

            // dgvDetalleVenta
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.ColumnHeadersHeight = 29;
            dgvDetalleVenta.Location = new Point(543, 425);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.RowHeadersWidth = 51;
            dgvDetalleVenta.Size = new Size(708, 200);
            dgvDetalleVenta.TabIndex = 8;

            // lblFormaPago
            lblFormaPago.AutoSize = true;
            lblFormaPago.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFormaPago.Location = new Point(512, 650);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(130, 28);
            lblFormaPago.TabIndex = 9;
            lblFormaPago.Text = "Forma de Pago:";

            // cmbFormaPago
            cmbFormaPago.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFormaPago.Location = new Point(650, 647);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(250, 36);
            cmbFormaPago.TabIndex = 10;
            cmbFormaPago.SelectedIndexChanged += cmbFormaPago_SelectedIndexChanged;

            // lblCuotas
            lblCuotas.AutoSize = true;
            lblCuotas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCuotas.Location = new Point(925, 650);
            lblCuotas.Name = "lblCuotas";
            lblCuotas.Size = new Size(72, 28);
            lblCuotas.TabIndex = 11;
            lblCuotas.Text = "Cuotas:";
            lblCuotas.Visible = false;

            // numCuotas
            numCuotas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numCuotas.Location = new Point(1003, 647);
            numCuotas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCuotas.Name = "numCuotas";
            numCuotas.Size = new Size(80, 34);
            numCuotas.TabIndex = 12;
            numCuotas.Visible = false;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.Location = new Point(949, 700);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(58, 28);
            lblTotal.TabIndex = 13;
            lblTotal.Text = "Total:";

            // txtTotal
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTotal.Location = new Point(1003, 697);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(150, 34);
            txtTotal.TabIndex = 14;

            // btnRealizarVenta
            btnRealizarVenta.BackColor = Color.Navy;
            btnRealizarVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRealizarVenta.ForeColor = Color.White;
            btnRealizarVenta.Location = new Point(1200, 750);
            btnRealizarVenta.Name = "btnRealizarVenta";
            btnRealizarVenta.Size = new Size(200, 50);
            btnRealizarVenta.TabIndex = 15;
            btnRealizarVenta.Text = "Finalizar Venta";
            btnRealizarVenta.UseVisualStyleBackColor = false;
            btnRealizarVenta.Click += btnRealizarVenta_Click;

            // Venta
            ClientSize = new Size(1500, 850);
            Controls.Add(lblTitulo);
            Controls.Add(lblCedula);
            Controls.Add(txtCedula);
            Controls.Add(btnComprobar);
            Controls.Add(lblResultado);
            Controls.Add(cmbTelefonos);
            Controls.Add(numCantidad);
            Controls.Add(btnAgregar);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(lblFormaPago);
            Controls.Add(cmbFormaPago);
            Controls.Add(lblCuotas);
            Controls.Add(numCuotas);
            Controls.Add(lblTotal);
            Controls.Add(txtTotal);
            Controls.Add(btnRealizarVenta);
            Controls.Add(pnlLateral);
            Name = "Venta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Venta de Teléfonos";
            pnlLateral.ResumeLayout(false);
            pnlVolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCuotas).EndInit();
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

        private Label label1;
    }
}
