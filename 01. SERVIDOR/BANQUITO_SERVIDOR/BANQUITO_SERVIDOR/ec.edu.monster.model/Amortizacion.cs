using System;

namespace BANQUITO_SERVIDOR.ec.edu.monster.model;

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
}
