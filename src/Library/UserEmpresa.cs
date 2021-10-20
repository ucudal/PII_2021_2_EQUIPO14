using System;

namespace Proyecto_Final
{
    public class UserEmpresa
    {
        public string Nombre { get; }
        public Empresa Empresa { get; private set; }
        public UserEmpresa(string nombre)
        {
            this.Nombre = nombre;
        }

        public void AceptarInvitacion()
        {
            Console.WriteLine("Aceptar invitacion? Y/N");
            string input = Console.ReadLine();   
            if (input == "Y")
            {
                Console.WriteLine("Invitacion aceptada...");
                Console.WriteLine("Ingrese el nombre de su empresa: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la direccion de su empresa: ");
                string ubicacion = Console.ReadLine();
                Console.WriteLine("Ingrese el rubro de su empresa: ");
                string rubro = Console.ReadLine();

                this.Empresa = new Empresa(nombre, ubicacion, rubro);
                Console.WriteLine($"Empresa {this.Empresa.Nombre} creada!.");
            }
            else
            {
                Console.WriteLine("Invitacion rechazada...");
            }
        }

        public void AgregarEspecializacion(string especializacion)
        {
            this.Empresa.Especializaciones.Add(especializacion);
        }


    }
}