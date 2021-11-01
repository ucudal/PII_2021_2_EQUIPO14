
using System;
using System.Collections;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa las habilitaciones necesarias para la tenencia de productos.
    /// </summary>
    public class Habilitaciones
    {
        /// <summary>
        /// Otorga el nombre de la Habilitación.
        /// </summary>
        /// <value>Nombre de la Habilitación.</value>
        public string Habilitacion { get;}

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