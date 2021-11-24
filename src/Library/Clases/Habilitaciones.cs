
using System;
using System.Collections;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa las habilitaciones necesarias para la tenencia de productos.
    /// Esta clase tiene una única responsabilidad que es diferenciar entre lo que es una habilitacion y lo que no, por lo cual sigue el SRP.
    /// </summary>
    public class Habilitaciones
    {
        /// <summary>
        /// Otorga el nombre de la Habilitación.
        /// </summary>
        /// <value>Nombre de la Habilitación.</value>
        public string Habilitacion { get;}

        /// <summary>
        /// Constructor vacio utilizado para la serializacion.
        /// </summary>
        public Habilitaciones() {}

        /// <summary>
        /// Inicializa la clase habilitaciones.
        /// </summary>
        /// <param name="habilitacion"></param>
        public Habilitaciones(string habilitacion)
        {
            this.Habilitacion = habilitacion;
        }
    }
}