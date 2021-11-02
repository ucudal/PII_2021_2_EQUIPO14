using Ucu.Poo.Locations.Client;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa al producto que se ofertará.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Otorga el nombre del producto.
        /// </summary>
        /// <value>Nombre del producto.</value>
        public string Nombre { get; }

        /// <summary>
        /// Otorga una descripción breve del producto.
        /// </summary>
        /// <value>Descripción del Producto.</value>
        public string Descripcion {get;}

        /// <summary>
        /// Otorga una ubicación en la que se encuentra el producto.
        /// </summary>
        /// <value>Ubicación del Producto</value>
        public string Ubicacion {get;}

        /// <summary>
        /// Otorga el valor monetario del producto.
        /// </summary>
        /// <value>Valor del producto.</value>
        public int Valor {get;}

        /// <summary>
        /// Otorga la cantidad ofertable del producto.
        /// </summary>
        /// <value>Cantidad del producto.</value>
        public int Cantidad {get;} 

        /// <summary>
        /// Otorga un objeto "TipoProducto" que representa el tipo de producto <see cref="TipoProducto"/>.
        /// </summary>
        /// <value>Objeto del tipo "TipoProducto".</value>
        public TipoProducto Tipo {get;}       

        /// <summary>
        /// Inicializa la clase Producto.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="tipo"></param>
        /// <param name="ubicacion"></param>
        /// <param name="valor"></param>
        /// <param name="cantidad"></param>
        public Producto(string nombre, string descripcion, string ubicacion, int valor, int cantidad, TipoProducto tipo)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Ubicacion = ubicacion;
            this.Valor = valor;
            this.Cantidad = cantidad;
            this.Tipo = tipo;
        }
    }
}