using ec.edu.monster.view;

namespace CLIENTE_ESCRITORIO
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuraci�n inicial de la aplicaci�n
            ApplicationConfiguration.Initialize();

            // Inicia la ventana principal
            Application.Run(new MainView());
        }
    }
}
