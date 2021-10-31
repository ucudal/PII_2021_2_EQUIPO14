using System;
using System.Collections;

namespace Proyecto_Final
{   
    /// <summary>
    /// Clase encargada de interactuar con el usuario a travez de la consola.
    /// </summary>
    public class ConsoleInteraction : IUserInterface
    {
        /// <summary>
        /// Inicializa la clase ConsoleInteraction.
        /// </summary>
        public ConsoleInteraction()
        {
            // Constructor.
        }

        /// <summary>
        /// Interactua con el usuario para crear una oferta.
        /// </summary>
        /// <returns>Datos para crear la oferta/publicacion.</returns>
        public string CrearOferta() // (SRP)
        {
            Console.WriteLine("Ingrese el nombre de su publicacion: ");
            string nombre = Console.ReadLine();
            return nombre;
        }

        /// <summary>
        /// Interactua con el usuario para aceptar la invitacion.
        /// </summary>
        /// <returns>Si se acepta la invitacion, devuelve una tupla con los datos de la empresa, si no, devuelve una tupla con strings vacios.</returns>
        public bool AceptarInvitacion() // (SRP)
        {
            Console.WriteLine("Aceptar invitacion? Y/N");
            string input = Console.ReadLine().ToUpper();   
            if (input == "Y")
            {
                Console.WriteLine("Invitacion aceptada!");
                return true;
            }
            else
            {
                Console.WriteLine("Invitacion rechazada...");
                return false;
            }
        }

        /// <summary>
        /// Interactua con el usuario para crear los datos respectivos de la empresa.
        /// </summary>
        /// <returns>Tupla de strings con los datos de la empresa.</returns>
        public (string, string, string) CrearDatosEmpresa() // (SRP)
        {
            Console.WriteLine("Ingrese el nombre de su empresa: ");
            string nombre = Console.ReadLine(); 
            Console.WriteLine("Ingrese la direccion de su empresa: ");
            string ubicacion = Console.ReadLine();
            Console.WriteLine("Ingrese el rubro de su empresa (podra agregar mas rubros luego si lo necesita): ");
            string rubro = Console.ReadLine();

            (string, string, string) auxTuple = (nombre, ubicacion, rubro);
            return auxTuple;
        }

        /// <summary>
        /// Interactua con el usuario para poder crear los datos de la habilitacion.
        /// </summary>
        /// <returns>Habilitacion.</returns>
        public string CrearDatosHabilitacion() // (SRP)
        {
            Console.WriteLine("Ingrese la habilitacion necesaria para el retiro de su producto: ");
            string habilitacion = Console.ReadLine();
            return habilitacion;
        }

        /// <summary>
        /// Interactua con el usuario para poder crear los datos del producto.
        /// </summary>
        /// <returns>Nombre, descripcion, ubicacion, valor y cantidad del producto.</returns>
        public (string, string, string, int, int) CrearDatosProducto() // (SRP)
        {
            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine(); 
            Console.WriteLine("Ingrese la descripcion de su producto: ");
            string descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese la ubicacion de su producto: ");
            string ubicacion = Console.ReadLine();
            Console.WriteLine("Ingrese el valor unitario de su producto: ");
            string valor = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad de su producto: ");
            string cantidad = Console.ReadLine();

            (string, string, string, int, int) auxTuple = (nombre, descripcion, ubicacion, Convert.ToInt32(valor), Convert.ToInt32(cantidad));
            return auxTuple;
        }

        /// <summary>
        /// Interactua con el usuario para crear los datos de la publicacion.
        /// </summary>
        /// <returns>Nombre de la publicacion</returns>
        public string CrearDatosOferta()
        {
            Console.WriteLine("Ingrese el nombre de su publicacion: ");
            string nombre = Console.ReadLine();
            return nombre;
        }

        /// <summary>
        /// Interactua con el usuario Empresa para agregar una especializacion.
        /// </summary>
        /// <param name="empresa"></param>
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

        /// <summary>
        /// Interactua con el usuario y le envia un mensaje de aviso que la empresa ya fue invitada y aceptada.
        /// </summary>
        public void AlreadyInvitedMsg()
        {
            Console.WriteLine("Esta empresa ya fue invitada y aceptada.");
        }

        /// <summary>
        /// Interactua con el usuario para crear un mensaje clave en una oferta especifica.
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="oferta"></param>
        public void AgregarMsjClave(Empresa empresa, Oferta oferta)
        {
            /*
            Console.WriteLine("Ingrese palabra clave a agregar: ");
            string palabra = Console.ReadLine();

            for (int i = 0; i < empresa.Ofertas.Count - 1; i++)
            {
                if (empresa.Ofertas[i] == oferta)
                {
                    //this.Ofertas[i].PalabraClave.Add(palabra);
                    Console.WriteLine(empresa.Ofertas[i]);
                    Console.WriteLine($"Palabra clave: {palabra} agregada.");
                }
            }
            */
        }
    }
}