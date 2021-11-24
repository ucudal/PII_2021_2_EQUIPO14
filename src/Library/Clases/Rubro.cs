using System;
using System.Collections;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa el rubro de una empresa.
    /// La única función de existencia de esta clase es para discernir entre lo que es un rubro y lo que no es un rubro, por lo cual es una clase que cumple el SRP.
    /// </summary>
    public class Rubro
    {
        /// <summary>
        /// Retorna el nombre del rubro de una empresa.
        /// </summary>
        /// <value>Nombre del rubro de la empresa.</value>
        public string Rubros { get; set; }

        /// <summary>
        /// Constructor vacio utilizado para la serializacion.
        /// </summary>
        public Rubro(){}

        /// <summary>
        /// Inicializa la clase rubro.
        /// </summary>
        /// <param name="rubro"></param>
        public Rubro(string rubro)
        {
            this.Rubros = rubro;
        }
    }
}