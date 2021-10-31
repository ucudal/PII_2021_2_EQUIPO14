using System;
using System.Collections;

namespace Proyecto_Final
{
    public class ConsoleInteraction : IUserInterface
    {
        public ConsoleInteraction()
        {

        }
        public string CrearOferta() // (SRP)
        {
            Console.WriteLine("Ingrese el nombre de su publicacion: ");
            string nombre = Console.ReadLine();
            return nombre;
        }

        public (string, string, string) AceptarInvitacion() // (SRP)
        {
            Console.WriteLine("Aceptar invitacion? Y/N");
            string input = Console.ReadLine().ToUpper();   
            if (input == "Y")
            {
                Console.WriteLine("Invitacion aceptada...");
                Console.WriteLine("Ingrese el nombre de su empresa: ");
                string nombre = Console.ReadLine(); 
                Console.WriteLine("Ingrese la direccion de su empresa: ");
                string ubicacion = Console.ReadLine();
                Console.WriteLine("Ingrese el rubro de su empresa (podra agregar mas rubros luego si lo necesita): ");
                string rubro = Console.ReadLine();

                (string, string, string) auxTuple = (nombre, ubicacion, rubro);
                return auxTuple;
            }
            else
            {
                Console.WriteLine("Invitacion rechazada...");
                (string, string, string) auxTuple = ("", "", "");
                return auxTuple;
            }
        }

        public void AgregarEspecializacion(Empresa empresa) // (SRP)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ingrese la especializacion a agregar: ");
                string esp = Console.ReadLine();
                empresa.AgregarEspecializacion(esp);
                Console.WriteLine("Quiere agregar otra especializacion? Y/N");
                string input = Console.ReadLine().ToUpper();
                if (input != "Y")
                {
                    loop = false;
                }
            }   
        }
    }
}