namespace ec.edu.monster.model
{
    public class Amortizacion
    {
        public int CodAmortizacion { get; set; }
        public int CodCredito { get; set; }
        public int NumCuota { get; set; }
        public double ValorCuota { get; set; }
        public double InteresPagado { get; set; }
        public double CapitalPagado { get; set; }
        public double Saldo { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
