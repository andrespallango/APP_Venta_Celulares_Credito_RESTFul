using System;
using System.Threading.Tasks;
using ec.edu.monster.service;

namespace ec.edu.monster.controller
{
    public class ClienteController
    {
        private readonly ApiService _apiService;

        public ClienteController()
        {
            _apiService = new ApiService();
        }

        // Consultar si el cliente es sujeto de crédito y su monto máximo
        public async Task ConsultarCreditoCliente()
        {
            Console.Write("\nIngrese la cédula del cliente: ");
            string cedula = Console.ReadLine();

            // Consultar si el cliente es sujeto de crédito
            bool esSujetoDeCredito = await _apiService.EsSujetoDeCredito(cedula);

            if (esSujetoDeCredito)
            {
                // Si es sujeto de crédito, consultar el código del cliente
                int codCliente = await _apiService.ObtenerCodigoCliente(cedula);

                if (codCliente == -1)
                {
                    Console.WriteLine("\nNo se encontró un cliente con la cédula ingresada.");
                    return;
                }

                // Consultar el monto máximo de crédito
                double montoMaximo = await _apiService.CalcularMontoMaximoCredito(codCliente);
                Console.WriteLine($"\nResultado: El cliente es sujeto de crédito.");
                Console.WriteLine($"Monto máximo de crédito: ${montoMaximo:F2}");
            }
            else
            {
                Console.WriteLine("\nResultado: El cliente no es sujeto de crédito.");
            }
        }
    }
}
