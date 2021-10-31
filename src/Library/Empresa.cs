using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa a la Empresa.
    /// </summary>
    public class Empresa
    {
        private ArrayList especializaciones = new ArrayList();
        private ArrayList ofertas = new ArrayList();

        /// <summary>
        /// Obtiene un valor del nombre de la Empresa.
        /// </summary>
        /// <value>Nombre de la empresa.</value>
        public string Nombre { get; }

        /// <summary>
        /// Obtiene un valor de la ubocacion de la Empresa.
        /// </summary>
        /// <value>Ubicacion de la empresa.</value>
        public string Ubicacion { get; }

        /// <summary>
        /// Obtiene un valor del Rubro de la empresa.
        /// </summary>
        /// <value>Objeto del tipo Rubro.</value>
        public Rubro Rubro { get; }

        /// <summary>
        /// Obtiene un valor de las especializaciones de la empresa.
        /// </summary>
        /// <value>Lista de especializaciones.</value>
        public ArrayList Especializaciones { get { return this.especializaciones; } }

        /// <summary>
        /// Obtiene un valor de las ofertaas publicadas de la empresa.
        /// </summary>
        /// <value>Lista con ofertas publicadas por la empresa.</value>
        public ArrayList Ofertas { get { return this.ofertas; } }

        /// <summary>
        /// Inicializa la clase Empresa.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        /// <param name="rubro"></param>
        public Empresa(string nombre, string ubicacion, Rubro rubro)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }   

        /// <summary>
        /// Agrega una especializacion a la empresa y la guarda en un array.
        /// </summary>
        /// <param name="especializacion"></param>
        public void AgregarEspecializacion(string especializacion)
        {            
            ArrayList especializaciones = this.Especializaciones;
            especializaciones.Add(especializacion);
        }


        /// <summary>
        /// Agrega una palabra clave a la oferta que se le envia como argumento.
        /// </summary>
        /// <param name="oferta"></param>
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