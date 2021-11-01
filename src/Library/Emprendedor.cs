using System;
using System.Collections;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa los datos adicionales del emprendedor.
    /// </summary>
    public class Emprendedor
    {
        
        private ArrayList especializaciones = new ArrayList();

        /// <summary>
        /// Otorga la ubicación del Emprendedor
        /// </summary>
        /// <value>Ubicación del Emprendedor</value>
        public string Ubicacion {get; set;}

        /// <summary>
        /// Otorga una instancia de objeto "Rubro" del Emprendedor
        /// </summary>
        /// <value>Objeto de tipo "Rubro".</value>
        public Rubro Rubro {get; set;}

        /// <summary>
        /// Otorga una lista de strings que representan las especializaciones del Emprendedor.
        /// </summary>
        /// <value></value>
        public ArrayList Especializaciones 
        { 
            get 
            {
                return this.especializaciones;
            } 
        }
        //Falta habilitaciones

        /// <summary>
        /// Inicializa la clase Emprendedor
        /// </summary>
        /// <param name="ubicacion"></param>
        /// <param name="rubro"></param>
        public Emprendedor(string ubicacion, Rubro rubro)
        {
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }

        /// <summary>
        /// Agrega una Especialización al Emprendedor.
        /// </summary>
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
        /// <summary>
        /// Elimina una Especialización al Emprendedor.
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public void ConsumoxTiempo()
        {
            
        }
    }
}