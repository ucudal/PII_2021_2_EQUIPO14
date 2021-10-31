using System.Collections;

namespace Proyecto_Final
{
    public class Oferta
    {
        public string Nombre { get; }

        public Producto Product {get;}

        private ArrayList palabrasClave = new ArrayList();
        public ArrayList PalabrasClave 
        {
            get
            {
                return this.palabrasClave;
            }
        }
        public Habilitaciones HabilitacionesOferta {get;}
        public Oferta(string nombre, Producto product, Habilitaciones habilitacionesOferta)
        {
            this.Nombre = nombre;
            this.Product = product;
            this.HabilitacionesOferta = habilitacionesOferta;
        }

        /// <summary>
        /// Agrega una palabra clave a la listas de palabras clave de la oferta.
        /// </summary>
        /// <param name="palabra"></param>
        public void AgregarMsjClave(string palabra)
        {
            this.palabrasClave.Add(palabra);
        }
    }
}