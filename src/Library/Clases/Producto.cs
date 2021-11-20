namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa al producto que se ofertará.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Otorga una moneda en base al valor booleano de este estado
        /// </summary>
        /// <value>Dólares estadounidenses si es falso, Pesos Uruguayos si es verdadero.</value>
        public bool IsPesos {get;set;}
        
        /// <summary>
        /// Otorga el nombre del producto.
        /// </summary>
        /// <value>Nombre del producto.</value>
        
        public string Nombre { get; set;}

        /// <summary>
        /// Otorga una descripción breve del producto.
        /// </summary>
        /// <value>Descripción del Producto.</value>
        public string Descripcion {get; set;}

        /// <summary>
        /// Otorga una ubicación en la que se encuentra el producto.
        /// </summary>
        /// <value>Ubicación del Producto</value>
        public string Ubicacion {get; set;}

        /// <summary>
        /// Otorga el valor monetario del producto.
        /// </summary>
        /// <value>Valor del producto.</value>
        public int Valor {get; set;}

        /// <summary>
        /// Otorga la cantidad ofertable del producto.
        /// </summary>
        /// <value>Cantidad del producto.</value>
        public int Cantidad {get; set;} 

        /// <summary>
        /// Otorga un objeto "TipoProducto" que representa el tipo de producto <see cref="TipoProducto"/>.
        /// </summary>
        /// <value>Objeto del tipo "TipoProducto".</value>
        public TipoProducto Tipo {get;set;}       

        /// <summary>
        /// Inicializa la clase Producto.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="tipo"></param>
        /// <param name="ubicacion"></param>
        /// <param name="valor"></param>
        /// <param name="isPesos"></param>
        /// <param name="cantidad"></param>
        public Producto(string nombre, string descripcion, string ubicacion, int valor, bool isPesos, int cantidad, TipoProducto tipo)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Ubicacion = ubicacion;
            this.Valor = valor;
            this.IsPesos = isPesos;
            this.Cantidad = cantidad;
            this.Tipo = tipo;
        }

        /// <summary>
        /// Método que retorna un string con el símbolo de la moneda que se utiliza para valorar un producto; en base al valor booleano de "IsPesos".
        /// </summary>
        /// <returns>Dólares Estadounidenses si es falso, Pesos Uruguayos si es verdadero.</returns>
        public string MonetaryValue()
        {
            if (this.IsPesos == false)
            {
                return "U$D";
            }
            else
            {
                return "$UYU";
            }
        }
    }
}