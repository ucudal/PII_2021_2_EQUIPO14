using System;
using System.Collections;
using System.Collections.Generic;

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

        /* Como empresa, quiero aceptar una invitación a unirme en la plataforma y registrar mi nombre, 
        ubicación y rubro, para que de esa forma pueda comenzar a publicar ofertas. */
        public void AceptarInvitacion()
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
                Console.WriteLine("Ingrese el rubro de su empresa: ");
                string rubro = Console.ReadLine();

                // Deberia UserEmpresa ser la encargada de crear la empresa y el rubro? (Creator)
                Rubro newRubro = new Rubro(rubro);
                this.Empresa = new Empresa(nombre, ubicacion, newRubro);
                Console.WriteLine($"Empresa: {this.Empresa.Nombre} creada!.");
            }
            else
            {
                Console.WriteLine("Invitacion rechazada...");
            }
        }

        public void AgregarEspecializacion(string especializacion)
        {
            this.Empresa.AgregarEspecializacion(especializacion); // (Delegacion)
        }

        public void EliminarEspecializacion(string especializacion)
        {
            this.Empresa.EliminarEspecializacion(especializacion); // (Delegacion)
        }

        /* Como empresa, quiero indicar un conjunto de palabras claves asociadas a la publicación de los materiales, 
        para que de esa forma sea más fácil de encontrarlos en las búsquedas que hacen los emprendedores. */
        public void CrearMsjClave(Oferta oferta)
        {
            this.Empresa.AgregarMsjClave(oferta); // (Delegacion)
        }

        /* Como empresa, quiero publicar una oferta de materiales reciclables o residuos, 
        para que de esa forma los emprendedores que lo necesiten puedan reutilizarlos. */
        public void CrearOferta()
        {
            Console.WriteLine("Ingrese el nombre de su publicacion: ");
            string nombre = Console.ReadLine();
            Oferta newOferta = new Oferta(nombre);

            this.Empresa.Ofertas.Add(newOferta);
            Console.WriteLine($"Oferta {newOferta} publicada!.");
        }
    }
}