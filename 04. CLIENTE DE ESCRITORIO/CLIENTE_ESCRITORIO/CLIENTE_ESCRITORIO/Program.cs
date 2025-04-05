using ec.edu.monster.view;

namespace CLIENTE_ESCRITORIO
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración inicial de la aplicación
            ApplicationConfiguration.Initialize();

            // Inicia la ventana principal
            Application.Run(new MainView());
        }
    }
}
