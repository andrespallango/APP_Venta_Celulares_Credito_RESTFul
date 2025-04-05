namespace ec.edu.monster.model
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }

        public Cliente() { }

        public Cliente(int codCliente, string nombre, string cedula)
        {
            CodCliente = codCliente;
            Nombre = nombre;
            Cedula = cedula;
        }
    }
}
