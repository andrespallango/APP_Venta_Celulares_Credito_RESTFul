namespace BANQUITO_SERVIDOR.ec.edu.monster.model
{
    public class Factura
    {
        public int CodFactura { get; set; }
        public int CodCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string FormaPago { get; set; }
        public List<DetalleFactura> Detalles { get; set; }

        public Factura() { }

        public Factura(int codFactura, int codCliente, DateTime fecha, double total, string formaPago, List<DetalleFactura> detalles)
        {
            CodFactura = codFactura;
            CodCliente = codCliente;
            Fecha = fecha;
            Total = total;
            FormaPago = formaPago;
            Detalles = detalles;
        }
    }
}
