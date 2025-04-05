namespace BANQUITO_SERVIDOR.ec.edu.monster.model
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public char Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Cliente() { }

        public Cliente(int codCliente, string cedula, string nombre, char genero, DateTime fechaNacimiento)
        {
            CodCliente = codCliente;
            Cedula = cedula;
            Nombre = nombre;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
