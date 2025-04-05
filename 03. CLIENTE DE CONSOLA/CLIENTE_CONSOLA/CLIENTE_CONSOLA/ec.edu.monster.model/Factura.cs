namespace ec.edu.monster.model
{
    public class Factura
    {
        public int CodFactura { get; set; }
        public int CodCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string FormaPago { get; set; }

        // Nueva propiedad: Lista de detalles de la factura
        public List<DetalleFactura> Detalles { get; set; }

        public Factura()
        {
            // Inicializar la lista de detalles en el constructor
            Detalles = new List<DetalleFactura>();
        }
    }
}
