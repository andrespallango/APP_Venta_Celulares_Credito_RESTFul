using System;
using System.Collections.Generic;

namespace ec.edu.monster.model
{
    public class Factura
    {
        public int CodFactura { get; set; }
        public int CodCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public Cliente Cliente { get; set; } // Agrega esta propiedad si no existe

        public string FormaPago { get; set; } // Campo que genera el error
        public List<DetalleFactura> Detalles { get; set; } // Lista de detalles de la factura

        public Factura()
        {
            Detalles = new List<DetalleFactura>();
        }
    }
}
