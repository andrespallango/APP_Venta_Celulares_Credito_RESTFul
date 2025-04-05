using ec.edu.monster.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIENTE_ESCRITORIO.ec.edu.monster.model
{
    public class FacturaCompleta
    {
        public Factura Factura { get; set; } // Información principal de la factura
        public List<DetalleFactura> Detalles { get; set; } // Lista de detalles de la factura
        public double Subtotal { get; set; }
        public double IVA { get; set; }
        public double TotalConIVA { get; set; }
    }
}
