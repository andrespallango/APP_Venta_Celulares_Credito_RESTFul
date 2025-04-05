namespace BANQUITO_SERVIDOR.ec.edu.monster.model
{
    public class DetalleFactura
    {
        public int CodDetalle { get; set; }
        public int CodFactura { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(int codDetalle, int codFactura, int codProducto, int cantidad, double precioUnitario, double subtotal)
        {
            CodDetalle = codDetalle;
            CodFactura = codFactura;
            CodProducto = codProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Subtotal = subtotal;
        }
    }
}
