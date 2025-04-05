namespace BANQUITO_SERVIDOR.ec.edu.monster.model
{
    public class Telefono
    {
        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Foto { get; set; } // URL de la imagen

        public Telefono() { }

        public Telefono(int codProducto, string nombre, double precio, string foto)
        {
            CodProducto = codProducto;
            Nombre = nombre;
            Precio = precio;
            Foto = foto;
        }
    }
}
