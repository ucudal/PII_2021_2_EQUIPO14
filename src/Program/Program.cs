using System;
using ClassLibrary;

namespace Proyecto_Final
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            UserEmpresa userE1 = new UserEmpresa("Pepito");
            UserAdmin userA1 = new UserAdmin("Admin-1");
            ConsoleInteraction consoleInteraction = new ConsoleInteraction();

            userA1.InvitarEmpresa(userE1, consoleInteraction);
            
            userE1.CrearOferta(consoleInteraction);
        }
    }
}