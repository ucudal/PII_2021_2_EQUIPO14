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
                Console.WriteLine("Ingrese el rubro de su empresa (podra agregar mas rubros luego si lo necesita): ");
                string rubro = Console.ReadLine();
                ArrayList rubros = new ArrayList();
                rubros.Add(rubro);

                // Deberia UserEmpresa ser la encargada de crear la empresa y el rubro? (Creator)
                Rubro newRubro = new Rubro(rubros);
                this.Empresa = new Empresa(nombre, ubicacion, newRubro);
                Console.WriteLine($"Empresa: {this.Empresa.Nombre} creada!.");
            }
            else
            {
                Console.WriteLine("Invitacion rechazada...");
            }
        }

        public void AgregarRubro()
        {
            this.Empresa.AgregarRubro(); // (Delegacion)
        }

        public void EliminarRubro()
        {
            this.Empresa.EliminarRubro(); // (Delegacion)
        }

        public void AgregarEspecializacion()
        {
            this.Empresa.AgregarEspecializacion(); // (Delegacion)
        }

        public void EliminarEspecializacion()
        {
            this.Empresa.EliminarEspecializacion(); // (Delegacion)
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
            // Setup del nombre de la oferta.

            Console.WriteLine("Ingrese el nombre de su publicacion: ");
            string nombre = Console.ReadLine();

            //Setup del producto

            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese una descripción del producto: ");
            string ubicacionProducto = Console.ReadLine();
            Console.WriteLine("Ingrese la ubicación en la que el prodcuto se encuentra almacenado: ");
            string descripcionProducto = Console.ReadLine();
            Console.WriteLine("Ingrese el valor del producto: ");
            int valorProducto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad del producto: ");
            int cantidadProducto = Convert.ToInt32(Console.ReadLine());
            Producto newProducto = new Producto(nombreProducto,descripcionProducto,ubicacionProducto,valorProducto,cantidadProducto);

            //Setup de las habilitaciones necesarias para obtener el producto

            bool agregarMas = true;
            ArrayList habilitaciones = new ArrayList();
            while(agregarMas)
            {
                Console.WriteLine("Agregue una habilitación necesaria para hacer usufructo del producto: ");
                string habilitacion = Console.ReadLine();
                habilitaciones.Add(habilitacion);
                Console.WriteLine("¿Agregó todas las habilitaciones requeridas? Y/N ");
                string check = Console.ReadLine();
                if(check == "N")
                {
                    agregarMas = false;
                }
            }
            Habilitaciones habilitacionesOferta = new Habilitaciones(habilitaciones);
            Oferta newOferta = new Oferta(nombre, newProducto, habilitacionesOferta);

            this.Empresa.Ofertas.Add(newOferta);
            Console.WriteLine($"Oferta {newOferta} publicada!.");
        }
    }
}