//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

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
            (string, string, string) tuplaDatos = ConsoleInteraction.AceptarInvitacion();
            userE1.AceptarInvitacion(tuplaDatos);
            string nombre = ConsoleInteraction.CrearOferta();
            userE1.CrearOferta(nombre);
        }
    }
}