namespace Proyecto_Final
{
    public class Oferta
    {
        public string Nombre { get; }

        public Producto Product {get;}

        public Habilitaciones HabilitacionesOferta {get;}
        public Oferta(string nombre, Producto product, Habilitaciones habilitacionesOferta)
        {
            this.Nombre = nombre;
            this.Product = product;
            this.HabilitacionesOferta = habilitacionesOferta;
        }
    }
}