using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ec.edu.monster.service;
using ec.edu.monster.model;

namespace ec.edu.monster.controller
{
    public class AmortizacionController
    {
        private readonly ApiService _apiService;

        public AmortizacionController()
        {
            _apiService = new ApiService();
        }

        // Consultar amortización utilizando la cédula para obtener el código del crédito
        public async Task ConsultarAmortizacionesPorCedula()
        {
            Console.Write("\nIngrese la cédula del cliente: ");
            string cedula = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                Console.WriteLine("La cédula es obligatoria.");
                return;
            }

            // Obtener el código del cliente asociado a la cédula
            int codCliente = await _apiService.ObtenerCodigoCliente(cedula);

            if (codCliente == -1)
            {
                Console.WriteLine("No se encontró un cliente con la cédula ingresada.");
                return;
            }

            // Obtener el código del último crédito asociado al cliente
            int codCredito = await _apiService.ObtenerUltimoCredito(codCliente);

            if (codCredito == -1)
            {
                Console.WriteLine("No se encontró un crédito activo para el cliente.");
                return;
            }

            // Consultar la tabla de amortización usando el código del crédito
            List<Amortizacion> amortizaciones = await _apiService.ObtenerAmortizaciones(codCredito);

            if (amortizaciones == null || amortizaciones.Count == 0)
            {
                Console.WriteLine("No se encontraron amortizaciones para el crédito.");
                return;
            }

            Console.WriteLine("\n=== Tabla de Amortización ===");
            Console.WriteLine($"{"Cuota",-6} {"Pago",-10} {"Interés",-10} {"Capital Pagado",-15} {"Saldo",-10}");
            foreach (var amortizacion in amortizaciones)
            {
                Console.WriteLine($"{amortizacion.NumCuota,-6} ${amortizacion.ValorCuota,-10:F2} ${amortizacion.InteresPagado,-10:F2} ${amortizacion.CapitalPagado,-15:F2} ${amortizacion.Saldo,-10:F2}");
            }
        }
    }
}
