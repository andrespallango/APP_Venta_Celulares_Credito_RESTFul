namespace ec.edu.monster.model
{
    public class Amortizacion
    {
        public int CodAmortizacion { get; set; } // Código único de la amortización
        public int CodCredito { get; set; } // Código del crédito asociado
        public int NumCuota { get; set; } // Número de la cuota
        public double ValorCuota { get; set; } // Valor de la cuota
        public double InteresPagado { get; set; } // Monto del interés pagado
        public double CapitalPagado { get; set; } // Monto del capital pagado
        public double Saldo { get; set; } // Saldo restante después del pago
        public DateTime FechaPago { get; set; } // Fecha en que se debe realizar el pago

        public Amortizacion() { }

        public Amortizacion(int codAmortizacion, int codCredito, int numCuota, double valorCuota,
                            double interesPagado, double capitalPagado, double saldo, DateTime fechaPago)
        {
            CodAmortizacion = codAmortizacion;
            CodCredito = codCredito;
            NumCuota = numCuota;
            ValorCuota = valorCuota;
            InteresPagado = interesPagado;
            CapitalPagado = capitalPagado;
            Saldo = saldo;
            FechaPago = fechaPago;
        }

        public override string ToString()
        {
            return $"Cuota #{NumCuota}: Pago ${ValorCuota:F2}, Interés ${InteresPagado:F2}, Capital ${CapitalPagado:F2}, Saldo ${Saldo:F2}, Fecha {FechaPago:dd/MM/yyyy}";
        }
    }
}
