using System;
using System.Threading.Tasks;
using ec.edu.monster.controller;

namespace CLIENTE_CONSOLA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Banco Banquito");
                Console.WriteLine("2. Comercializadora de Teléfonos");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        await BancoBanquito();
                        break;
                    case "2":
                        await Comercializadora();
                        break;
                    case "3":
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        private static async Task BancoBanquito()
        {
            ClienteController clienteController = new ClienteController();

            while (true)
            {
                Console.WriteLine("\n=== BANCO BANQUITO ===");
                Console.WriteLine("1. Verificar sujeto de crédito");
                Console.WriteLine("2. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        await clienteController.ConsultarCreditoCliente();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }


        private static async Task Comercializadora()
        {
            VentaController ventaController = new VentaController();
            FacturaController facturaController = new FacturaController();
            TelefonoController telefonoController = new TelefonoController();
            AmortizacionController amortizacionController = new AmortizacionController();

            while (true)
            {
                Console.WriteLine("\n=== COMERCIALIZADORA DE TELÉFONOS ===");
                Console.WriteLine("1. Ver Catálogo de Teléfonos");
                Console.WriteLine("2. Mantenimiento del Catálogo");
                Console.WriteLine("3. Registrar Venta");
                Console.WriteLine("4. Consultar Facturas");
                Console.WriteLine("5. Consultar Tabla de Amortización");
                Console.WriteLine("6. Salir al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        await telefonoController.ListarTelefonos();
                        break;
                    case "2":
                        await MantenimientoCatalogo(telefonoController);
                        break;
                    case "3":
                        await ventaController.RegistrarVentaAsync();
                        break;
                    case "4":
                        await facturaController.ObtenerFacturas();
                        break;
                    case "5":
                        await amortizacionController.ConsultarAmortizacionesPorCedula();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        private static async Task MantenimientoCatalogo(TelefonoController telefonoController)
        {
            while (true)
            {
                Console.WriteLine("\n=== MANTENIMIENTO DEL CATÁLOGO ===");
                Console.WriteLine("1. Agregar Teléfono");
                Console.WriteLine("2. Editar Teléfono");
                Console.WriteLine("3. Eliminar Teléfono");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        await telefonoController.CrearTelefono();
                        break;
                    case "2":
                        await telefonoController.ActualizarTelefono();
                        break;
                    case "3":
                        await telefonoController.EliminarTelefono();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
