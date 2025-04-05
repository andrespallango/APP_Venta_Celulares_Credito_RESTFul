namespace ec.edu.monster.model
{
    public class Telefono
    {
        public int CodProducto { get; set; } // Código del producto
        public string Nombre { get; set; } // Nombre del teléfono
        public double Precio { get; set; } // Precio del teléfono
        public string Foto { get; set; } // Ruta o URL de la imagen del teléfono

        public Telefono() { }

        public Telefono(int codProducto, string nombre, double precio, string foto)
        {
            CodProducto = codProducto;
            Nombre = nombre;
            Precio = precio;
            Foto = foto;
        }

        public override string ToString()
        {
            return $"{CodProducto} - {Nombre} (${Precio:F2})";
        }
    }
}
