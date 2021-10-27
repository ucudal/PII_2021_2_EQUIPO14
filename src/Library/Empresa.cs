using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Final
{
    public class Empresa
    {
        private ArrayList especializaciones = new ArrayList();
        private ArrayList ofertas = new ArrayList();
        private ArrayList habilitacionesRequeridas = new ArrayList();
        public string Nombre { get; }
        public string Ubicacion { get; }
        public Rubro Rubro { get; }
        public ArrayList Especializaciones 
        { 
            get 
            {
                return this.especializaciones;
            } 
        }
        public ArrayList Ofertas 
        { 
            get 
            {
                return this.ofertas;
            } 
        }
        public Empresa(string nombre, string ubicacion, Rubro rubro)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }

        public void AgregarRubro()
        {
            ArrayList rubros = this.Rubro.Rubros;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ingrese el rubro a agregar: ");
                string rubro = Console.ReadLine();
                rubros.Add(rubro);
                Console.WriteLine("Quiere agregar otro rubro? Y/N");
                string input = Console.ReadLine().ToUpper();
                if (input != "Y")
                {
                    loop = false;
                }
            }
        }

        public void EliminarRubro()
        {
            ArrayList rubros = this.Rubro.Rubros;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ingrese el rubro a eliminar: ");
                string rubro = Console.ReadLine();

                for (int i = 0; i < rubros.Count - 1; i++)
                {
                    if ((string)rubros[i] == rubro)
                    {
                        rubros.RemoveAt(i);
                    }
                }
                Console.WriteLine("Quiere eliminar otro rubro? Y/N");
                string input = Console.ReadLine().ToUpper();
                if (input != "Y")
                {
                    loop = false;
                }
            }
        }

        public void AgregarEspecializacion()
        {
            ArrayList especializaciones = this.Especializaciones;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ingrese la especializacion a agregar: ");
                string esp = Console.ReadLine();
                especializaciones.Add(esp);
                Console.WriteLine("Quiere agregar otra especializacion? Y/N");
                string input = Console.ReadLine().ToUpper();
                if (input != "Y")
                {
                    loop = false;
                }
            }
        }
        public void EliminarEspecializacion()
        {
            ArrayList arrayEmpresa = this.Especializaciones;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ingrese el rubro a eliminar: ");
                string especializacion = Console.ReadLine();

                for (int i = 0; i < arrayEmpresa.Count - 1; i++)
                {
                    if ((string)arrayEmpresa[i] == especializacion)
                    {
                        arrayEmpresa.RemoveAt(i);
                    }
                }
                Console.WriteLine("Quiere eliminar otra especializacion? Y/N");
                string input = Console.ReadLine().ToUpper();
                if (input != "Y")
                {
                    loop = false;
                }
            }
        }

        public void AgregarMsjClave(Oferta oferta)
        {
            Console.WriteLine("Ingrese palabra clave a agregar: ");
            string palabra = Console.ReadLine();

            for (int i = 0; i < this.Ofertas.Count - 1; i++)
            {
                if (this.Ofertas[i] == oferta)
                {
                    //this.Ofertas[i].PalabraClave.Add(palabra);
                    Console.WriteLine($"Palabra clave: {palabra} agregada.");
                }
            }
        }
    }
}