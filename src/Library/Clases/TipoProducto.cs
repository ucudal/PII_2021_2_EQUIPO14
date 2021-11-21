using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa una clasificación general de un producto.
    /// La única función de existencia de esta clase es para discernir entre lo que es un Tipo de producto y lo que no es, por lo cual es una clase que cumple el SRP.
    /// </summary>
    public class TipoProducto
    {
        /// <summary>
        /// Otorga el nombre del tipo de clasificación del producto.
        /// </summary>
        /// <value>Nombre del tipo de producto.</value>
        public string Nombre { get; set;}

        /// <summary>
        /// Inicializa la clase TipoProducto.
        /// </summary>
        /// <param name="tipo"></param>
        public TipoProducto(string tipo)
        {
            this.Nombre = tipo;
        }
    }
}