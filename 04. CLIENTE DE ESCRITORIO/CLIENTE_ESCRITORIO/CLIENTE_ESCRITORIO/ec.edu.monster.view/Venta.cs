using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using ec.edu.monster.controller;
using ec.edu.monster.model;

namespace ec.edu.monster.view
{
    public partial class Venta : Form
    {
        private readonly VentaController _ventaController;
        private readonly CatalogoController _catalogoController;
        private readonly ClienteController _clienteController;
        private List<Telefono> _telefonos;
        private List<DetalleFactura> _detallesFactura;

        public Venta()
        {
            InitializeComponent();
            _ventaController = new VentaController();
            _catalogoController = new CatalogoController();
            _clienteController = new ClienteController();
            _telefonos = new List<Telefono>();
            _detallesFactura = new List<DetalleFactura>();

            ConfigurarDataGridView();
            CargarCatalogo();
            ConfigurarFormaPago();
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalleVenta.AutoGenerateColumns = false;
            dgvDetalleVenta.Columns.Clear();

            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "CodProducto",
                DataPropertyName = "CodProducto",
                Name = "CodProducto"
            });
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Name = "Cantidad"
            });
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnitario",
                Name = "PrecioUnitario"
            });
            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                Name = "Subtotal"
            });
        }

        private async void CargarCatalogo()
        {
            try
            {
                _telefonos = await _catalogoController.ObtenerCatalogo();
                cmbTelefonos.DataSource = _telefonos;
                cmbTelefonos.DisplayMember = "Nombre";
                cmbTelefonos.ValueMember = "CodProducto";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarFormaPago()
        {
            cmbFormaPago.SelectedIndexChanged += cmbFormaPago_SelectedIndexChanged;
            cmbFormaPago.Items.Add("Efectivo");
        }

        private async void btnComprobar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            if (string.IsNullOrEmpty(cedula))
            {
                lblResultado.Text = "Ingrese una cédula válida.";
                return;
            }

            try
            {
                int codCliente = await _clienteController.ObtenerCodigoCliente(cedula);
                if (codCliente == -1)
                {
                    lblResultado.Text = "No se encontró un cliente con la cédula ingresada.";
                    return;
                }

                bool esSujetoDeCredito = await _clienteController.EsSujetoDeCredito(cedula);
                if (esSujetoDeCredito)
                {
                    double montoMaximo = await _clienteController.CalcularMontoMaximoCredito(codCliente);
                    lblResultado.Text = $"El cliente es sujeto de crédito. Monto máximo: ${montoMaximo:F2}";
                    cmbFormaPago.Items.Clear();
                    cmbFormaPago.Items.AddRange(new object[] { "Efectivo", "Crédito" });
                }
                else
                {
                    lblResultado.Text = "El cliente no es sujeto de crédito.";
                    cmbFormaPago.Items.Clear();
                    cmbFormaPago.Items.Add("Efectivo");
                }

                cmbFormaPago.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error al procesar la cédula: {ex.Message}";
            }
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esCredito = cmbFormaPago.SelectedItem.ToString() == "Crédito";
            lblCuotas.Visible = esCredito;
            numCuotas.Visible = esCredito;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbTelefonos.SelectedItem is Telefono telefono)
            {
                int cantidad = (int)numCantidad.Value;
                if (cantidad > 0)
                {
                    double subtotal = telefono.Precio * cantidad;

                    _detallesFactura.Add(new DetalleFactura
                    {
                        CodProducto = telefono.CodProducto,
                        Cantidad = cantidad,
                        PrecioUnitario = telefono.Precio,
                        Subtotal = subtotal
                    });

                    ActualizarListaDetalles();
                    ActualizarTotal();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar al menos una unidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ActualizarListaDetalles()
        {
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.DataSource = _detallesFactura;
        }

        private void ActualizarTotal()
        {
            double total = 0;
            foreach (var detalle in _detallesFactura)
            {
                total += detalle.Subtotal;
            }

            txtTotal.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }

        private async void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Ingrese la cédula del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_detallesFactura.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al carrito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formaPago = cmbFormaPago.SelectedItem.ToString();
            int numeroCuotas = formaPago == "Crédito" ? (int)numCuotas.Value : 0;

            double totalFactura = CalcularTotal();

            if (formaPago == "Crédito")
            {
                try
                {
                    double montoMaximoCredito = await _clienteController.CalcularMontoMaximoCredito(await _clienteController.ObtenerCodigoCliente(txtCedula.Text));

                    if (totalFactura > montoMaximoCredito)
                    {
                        MessageBox.Show($"El total de la factura (${totalFactura:F2}) excede el monto máximo de crédito permitido (${montoMaximoCredito:F2}).",
                            "Límite de Crédito Excedido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al verificar el monto máximo de crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ec.edu.monster.model.Factura factura = new ec.edu.monster.model.Factura
            {
                CodCliente = 0,
                Fecha = DateTime.Now,
                Total = totalFactura,
                FormaPago = formaPago,
                Detalles = _detallesFactura
            };

            try
            {
                bool ventaExitosa = await _ventaController.RealizarVenta(factura, numeroCuotas, txtCedula.Text);
                if (ventaExitosa)
                {
                    _detallesFactura.Clear();
                    ActualizarListaDetalles();
                    lblResultado.Text = "Venta realizada con éxito.";
                }
                else
                {
                    lblResultado.Text = "No se pudo realizar la venta.";
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error al realizar la venta: {ex.Message}";
            }
        }

        private double CalcularTotal()
        {
            double total = 0;
            foreach (var detalle in _detallesFactura)
            {
                total += detalle.Subtotal;
            }
            return total;
        }
    }

}
