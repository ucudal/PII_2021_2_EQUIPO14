using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa a la Empresa.
    /// Se utiliza el patrón Expert debido a que la clase contiene los datos personales del usuario Empresa, 
    /// y por ende es experta en la modificación de estos datos; además de ser experta en evaluar las ventas del usuario Empresa, 
    /// ya que las ofertas personales se contienen en esta clase. 
    /// También se utiliza el patrón de Delegación para delegar la modificación de los atributos de una oferta a la clase que almacena esos atributos, 
    /// que es la clase "Oferta".
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
        public string Ubicacion { get; set; }

        /// <summary>
        /// Obtiene un valor del Rubro de la empresa.
        /// </summary>
        /// <value>Objeto del tipo Rubro.</value>
        public Rubro Rubro { get; set; }

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
        /// Constructor vacio utilizado para la serializacion.
        /// </summary>
        public Empresa() {}

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
        /// Agrega un rubro.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(string rubro) //(Expert)
        {
            Rubro newRubro = new Rubro(rubro);
            this.Rubro = newRubro;
        }

        /// <summary>
        /// Agrega una palabra clave a una publicacion determinada.
        /// </summary>
        /// <param name="palabra"></param>
        /// <param name="oferId"></param>
        public void AgregarMsjClave(string oferId, string palabra) //(Expert)
        {
            foreach (Oferta oferta in this.Ofertas)
            {
                if (oferta.Id == oferId)
                {
                    oferta.AgregarMsjClave(palabra); // (Delegacion)
                }
            }
        }

        /// <summary>
        /// Agrega una especializacion a la empresa y la guarda en un array.
        /// </summary>
        /// <param name="especializacion"></param>
        public void AgregarEspecializacion(string especializacion) //(Expert)
        {            
            ArrayList especializaciones = this.Especializaciones;
            especializaciones.Add(especializacion);
        }

        /// <summary>
        /// Como empresa, quiero saber todos los materiales o residuos entregados en un período de tiempo, para de esa forma tener un seguimiento de su reutilización.
        /// </summary>
        /// <returns>Retorna un diccionario con los datos de las ventas</returns>
        public Dictionary<string, int> VerificarVentas() //(Expert)
        {
            Dictionary<string, int> info = new Dictionary<string, int>();

            foreach (Oferta oferta in this.Ofertas)
            {
                if (oferta.IsVendido == true)
                {
                    if (info.ContainsKey(oferta.Product.Tipo.Nombre))
                    {
                        info[oferta.Product.Tipo.Nombre] += oferta.Product.Cantidad;
                    }
                    else
                    {
                        info.Add(oferta.Product.Tipo.Nombre, oferta.Product.Cantidad);
                    }
                }
            }
            return info;
        }
    }
}