using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ec.edu.monster.service;
using ec.edu.monster.model;

namespace ec.edu.monster.controller
{
    public class TelefonoController
    {
        private readonly ApiService _apiService;

        public TelefonoController()
        {
            _apiService = new ApiService();
        }

        // Listar teléfonos
        public async Task ListarTelefonos()
        {
            List<Telefono> telefonos = await _apiService.ListarTelefonos();

            Console.WriteLine("\nLista de Teléfonos Disponibles:");
            foreach (var telefono in telefonos)
            {
                Console.WriteLine($"Código: {telefono.CodProducto} | Nombre: {telefono.Nombre} | Precio: ${telefono.Precio}");
            }
        }

        // Crear teléfono
        public async Task CrearTelefono()
        {
            Console.Write("\nIngrese el nombre del teléfono: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el precio: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Ingrese la URL de la foto: ");
            string foto = Console.ReadLine();

            Telefono telefono = new Telefono
            {
                Nombre = nombre,
                Precio = precio,
                Foto = foto
            };

            bool resultado = await _apiService.CrearTelefono(telefono);

            if (resultado)
                Console.WriteLine("\nTeléfono agregado con éxito.");
            else
                Console.WriteLine("\nError al agregar el teléfono.");
        }

        // Actualizar teléfono
        public async Task ActualizarTelefono()
        {
            Console.Write("\nIngrese el código del teléfono a actualizar: ");
            int codProducto = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo nombre del teléfono: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo precio: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("Ingrese la nueva URL de la foto: ");
            string foto = Console.ReadLine();

            Telefono telefono = new Telefono
            {
                CodProducto = codProducto,
                Nombre = nombre,
                Precio = precio,
                Foto = foto
            };

            bool resultado = await _apiService.ActualizarTelefono(telefono);

            if (resultado)
                Console.WriteLine("\nTeléfono actualizado con éxito.");
            else
                Console.WriteLine("\nError al actualizar el teléfono.");
        }

        // Eliminar teléfono
        public async Task EliminarTelefono()
        {
            Console.Write("\nIngrese el código del teléfono a eliminar: ");
            int codProducto = int.Parse(Console.ReadLine());

            bool resultado = await _apiService.EliminarTelefono(codProducto);

            if (resultado)
                Console.WriteLine("\nTeléfono eliminado con éxito.");
            else
                Console.WriteLine("\nError al eliminar el teléfono.");
        }
    }
}
