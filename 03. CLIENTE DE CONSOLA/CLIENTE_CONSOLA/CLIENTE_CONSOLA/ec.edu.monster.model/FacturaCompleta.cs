namespace ec.edu.monster.model
{
    public class FacturaCompleta
    {
        public FacturaInfo Factura { get; set; }
        public List<DetalleFactura> Detalles { get; set; }
        public double Subtotal { get; set; }
        public double IVA { get; set; }
        public double TotalConIVA { get; set; }
    }

    public class FacturaInfo
    {
        public DateTime Fecha { get; set; }
        public string FormaPago { get; set; }
        public double Total { get; set; }
        public ClienteInfo Cliente { get; set; }
    }

    public class ClienteInfo
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
    }
}
