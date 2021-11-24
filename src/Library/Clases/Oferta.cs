using System.Collections;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa las ofertas creadas por un empresario.
    /// Esta clase tiene como función ser una representación de una publicación de oferta, además de ser experta en modificar los atributos utilizados para representar tal oferta, por lo cual 
    /// </summary>
    public class Oferta
    {
        private string id;
        private bool isVendido = false;
        private ArrayList palabrasClave = new ArrayList();
        private UserEmprendedor comprador = null;

        /// <summary>
        /// Otorga el ID de la Oferta.
        /// </summary>
        /// <returns>Retorna el ID.</returns>
        public string Id { get; set; }

        /// <summary>
        /// Otorga el nombre de la Oferta
        /// </summary>
        /// <value>Retorna el nombre.</value>
        public string Nombre { get; }

        /// <summary>
        /// Otorga un objeto del Producto que se está ofertando <see cref="Producto"/>.
        /// </summary>
        /// <value>Objeto del tipo "Producto".</value>
        public Producto Product {get;}

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

        /// <summary>
        /// Otorga un valor booleano dependiendo de si la oferta fue vendida o no.
        /// </summary>
        /// <value>Retorna un valor booleano</value>
        public bool IsVendido { get { return isVendido; } set { this.isVendido = value;} }

        /// <summary>
        /// Otorga un valor booleano dependiendo de si la oferta es recurrente o no.
        /// </summary>
        /// <value>Verdadero si es recurrente, falso si no.</value>
        public bool IsRecurrente {get;set;}
        /// <summary>
        /// Otorga un valor que representa al comprador de la oferta.
        /// </summary>
        /// <value></value>
        public UserEmprendedor Comprador { get { return comprador; } set { this.comprador = value;} }

        /// <summary>
        /// Constructor vacio utilizado para la serializacion.
        /// </summary>
        public Oferta() {}

        /// <summary>
        /// Inicializa la clase Oferta.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="product"></param>
        /// <param name="isRecurrente"></param>
        /// <param name="habilitacionesOferta"></param>
        public Oferta(string nombre, Producto product, bool isRecurrente, Habilitaciones habilitacionesOferta)
        {
            this.Nombre = nombre;
            this.Product = product;
            this.IsRecurrente = isRecurrente;
            this.HabilitacionesOferta = habilitacionesOferta;

            this.Id = IdGenerator.GenerateNumericId();
        }

        /// <summary>
        /// Agrega una palabra clave a la listas de palabras clave de la oferta.
        /// </summary>
        /// <param name="palabra"></param>
        public void AgregarMsjClave(string palabra) //(Expert)
        {
            this.palabrasClave.Add(palabra);
        }
    }
}