using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ec.edu.monster.service; // Servicio para realizar solicitudes HTTP
using ec.edu.monster.model;  // Modelos compartidos entre el cliente y el servidor

namespace ec.edu.monster.controller
{
    public class VentaController
    {
        private readonly ApiService _apiService;

        public VentaController()
        {
            // Inicializa el servicio para realizar solicitudes HTTP
            _apiService = new ApiService();
        }

        // Registrar una nueva venta
        public async Task RegistrarVentaAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Registrar Nueva Venta ===");

                // Solicitar la cédula del cliente
                Console.Write("Ingrese la cédula del cliente: ");
                string cedula = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(cedula))
                {
                    Console.WriteLine("La cédula es obligatoria.");
                    PausarYLimpiar();
                    return;
                }

                // Verificar si el cliente es sujeto de crédito y obtener el monto máximo
                bool esSujetoDeCredito = await _apiService.EsSujetoDeCredito(cedula);
                double montoMaximo = 0;

                if (!esSujetoDeCredito)
                {
                    Console.WriteLine("\nEl cliente no es sujeto de crédito. Solo se permitirá el pago en efectivo.");
                }
                else
                {
                    int codCliente = await _apiService.ObtenerCodigoCliente(cedula);
                    if (codCliente == -1)
                    {
                        Console.WriteLine("\nNo se encontró un cliente con la cédula ingresada.");
                        PausarYLimpiar();
                        return;
                    }

                    montoMaximo = await _apiService.CalcularMontoMaximoCredito(codCliente);
                    Console.WriteLine($"\nEl cliente es sujeto de crédito.");
                    Console.WriteLine($"Monto máximo de crédito: ${montoMaximo:F2}");
                }

                // Seleccionar forma de pago
                string formaPago;
                int numeroCuotas = 0;

                if (esSujetoDeCredito)
                {
                    Console.WriteLine("\nSeleccione la forma de pago:");
                    Console.WriteLine("1. Efectivo");
                    Console.WriteLine("2. Crédito");
                    Console.Write("Opción: ");
                    string opcionFormaPago = Console.ReadLine()?.Trim();

                    switch (opcionFormaPago)
                    {
                        case "1":
                            formaPago = "Efectivo";
                            break;

                        case "2":
                            formaPago = "Crédito";
                            Console.Write("Ingrese el número de cuotas (entre 3 y 18): ");
                            if (!int.TryParse(Console.ReadLine(), out numeroCuotas) || numeroCuotas < 3 || numeroCuotas > 18)
                            {
                                Console.WriteLine("Número de cuotas no válido. Debe estar entre 3 y 18.");
                                PausarYLimpiar();
                                return;
                            }
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            PausarYLimpiar();
                            return;
                    }
                }
                else
                {
                    // Si no es sujeto de crédito, solo permitir efectivo
                    formaPago = "Efectivo";
                    Console.WriteLine("\nForma de pago seleccionada: Efectivo.");
                }

                // Crear la factura con detalles
                Factura factura = new Factura
                {
                    Detalles = new List<DetalleFactura>(),
                    FormaPago = formaPago
                };

                Console.WriteLine("\nAgregue los productos a la factura:");
                while (true)
                {
                    Console.Write("Código del producto: ");
                    if (!int.TryParse(Console.ReadLine(), out int codProducto))
                    {
                        Console.WriteLine("Código inválido. Intente nuevamente.");
                        continue;
                    }

                    Console.Write("Cantidad: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                    {
                        Console.WriteLine("Cantidad inválida. Intente nuevamente.");
                        continue;
                    }

                    factura.Detalles.Add(new DetalleFactura
                    {
                        CodProducto = codProducto,
                        Cantidad = cantidad
                    });

                    Console.Write("¿Desea agregar otro producto? (s/n): ");
                    if (Console.ReadLine()?.ToLower() != "s")
                    {
                        break;
                    }
                }

                if (factura.Detalles.Count == 0)
                {
                    Console.WriteLine("La factura debe contener al menos un producto.");
                    PausarYLimpiar();
                    return;
                }

                // Calcular el monto total de la factura
                double montoTotal = 0;
                foreach (var detalle in factura.Detalles)
                {
                    montoTotal += detalle.PrecioUnitario * detalle.Cantidad;
                }

                // Validar si el monto total supera el monto máximo de crédito
                if (formaPago == "Crédito" && montoTotal > montoMaximo)
                {
                    Console.WriteLine($"\nError: El monto total de la factura (${montoTotal:F2}) supera el monto máximo de crédito permitido (${montoMaximo:F2}).");
                    PausarYLimpiar();
                    return;
                }

                Console.WriteLine("\nProcesando la venta...");
                bool resultado = await _apiService.RealizarVenta(factura, numeroCuotas, cedula);

                if (resultado)
                {
                    Console.WriteLine("\nVenta registrada exitosamente.");
                }
                else
                {
                    Console.WriteLine("\nError al registrar la venta. Verifique los datos ingresados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al procesar la venta: ");
            }
            finally
            {
                PausarYLimpiar();
            }
        }

        // Método para pausar y limpiar pantalla
        private void PausarYLimpiar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
