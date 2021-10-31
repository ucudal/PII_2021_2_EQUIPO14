using System;
using System.Collections;

namespace Proyecto_Final
{
    public class Emprendedor
    {
        private ArrayList especializaciones = new ArrayList();
        public string Ubicacion {get; set;}
        public Rubro Rubro {get; set;}
        public ArrayList Especializaciones 
        { 
            get 
            {
                return this.especializaciones;
            } 
        }
        //Falta habilitaciones
        public Emprendedor(string ubicacion, Rubro rubro)
        {
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
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
            ArrayList esp = this.Especializaciones;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ingrese la especialización a eliminar: ");
                string especializacion = Console.ReadLine();

                for (int i = 0; i < esp.Count - 1; i++)
                {
                    if ((string)esp[i] == especializacion)
                    {
                        esp.RemoveAt(i);
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
        public void ConsumoxTiempo()
        {
            
        }
    }
}