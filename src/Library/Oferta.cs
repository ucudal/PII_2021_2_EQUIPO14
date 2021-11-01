using System.Collections;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa las ofertas creadas por un empresario.
    /// </summary>
    public class Oferta
    {
        private bool isVendido = false;

        /// <summary>
        /// Otorga el nombre de la Oferta
        /// </summary>
        /// <value></value>
        public string Nombre { get; }

        /// <summary>
        /// Otorga un objeto del Producto que se está ofertando <see cref="Producto"/>.
        /// </summary>
        /// <value>Objeto del tipo "Producto".</value>
        public Producto Product {get;}
        private ArrayList palabrasClave = new ArrayList();
        
        /// <summary>
        /// Otorga una lista de strings "Palabras Clave" que pueden utilizarse para buscar la oferta.
        /// </summary>
        /// <value>Retorna la lista "palabrasClave".</value>
        public ArrayList PalabrasClave 
        {
            get
            {
                return this.palabrasClave;
            }
        }
        
        /// <summary>
        /// Otorga las habilitaciones requeridas para que un emprendedor pueda aceptar la oferta <see cref="Habilitaciones"/>.
        /// </summary>
        /// <value>Objeto del tipo Habilitaciones.</value>
        public Habilitaciones HabilitacionesOferta {get;}

        public bool IsVendido { get { return isVendido; } set { this.isVendido = value;} }

        /// <summary>
        /// Inicializa la clase Oferta.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="product"></param>
        /// <param name="habilitacionesOferta"></param>
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