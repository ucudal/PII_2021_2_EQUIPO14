namespace Proyecto_Final
{
    public class Producto
    {
        public string Nombre { get; }
        public string Descripcion {get;}
    
        public string Ubicacion {get;}

        public int Valor {get;}

        public int Cantidad {get;}  

        /// <summary>
        /// Obtiene un valor del tipo del producto.
        /// </summary>
        /// <value>Tipo del producto.</value>
        public TipoProducto Tipo { get; }
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