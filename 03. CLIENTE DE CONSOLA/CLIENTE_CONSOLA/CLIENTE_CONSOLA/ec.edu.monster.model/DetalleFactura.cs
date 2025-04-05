namespace ec.edu.monster.model
{
    public class DetalleFactura
    {
        public int CodDetalle { get; set; }
        public int CodFactura { get; set; }
        public int CodProducto { get; set; }
        public string NombreProducto { get; set; } // Agregado para reflejar el campo del servidor
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
    }
}
