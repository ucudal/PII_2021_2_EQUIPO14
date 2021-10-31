namespace Proyecto_Final
{
    public class Producto
    {
        public string Nombre { get; }
        public string Descripcion {get;}
    
        public string Ubicacion {get;}

        public int Valor {get;}

        public int Cantidad {get;}        
        public Producto(string nombre, string descripcion, string ubicacion, int valor, int cantidad)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Ubicacion = ubicacion;
            this.Valor = valor;
            this.Cantidad = cantidad;
        }
    }
}