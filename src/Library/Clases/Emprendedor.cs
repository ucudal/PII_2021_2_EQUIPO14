using System;
using System.Collections;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa los datos adicionales del emprendedor.
    /// Se utiliza el patrón Expert debido a que la clase contiene los datos personales del usuario Emprendedor, 
    /// y por ende es experta en la modificación de estos datos; además de ser experta en evaluar el consumo por tiempo del usuario emprendedor,
    /// ya que los datos de las compras realizadas se contienen en esta clase.
    /// </summary>
    public class Emprendedor
    {
        private List<Oferta> compras = new List<Oferta>();

        private ArrayList especializaciones = new ArrayList();

        /// <summary>
        /// Otorga la ubicación del Emprendedor
        /// </summary>
        /// <value>Ubicación del Emprendedor</value>
        public string Ubicacion {get; set;}

        /// <summary>
        /// Otorga una instancia de objeto "Rubro" del Emprendedor
        /// </summary>
        /// <value>Objeto de tipo "Rubro".</value>
        public Rubro Rubro {get; set;}

        /// <summary>
        /// Otorga una instancia de objeto "Habilitaciones" del Emprendedor
        /// </summary>
        /// <value>Objeto de tipo "Habilitaciones".</value>
        public Habilitaciones Habilitacion {get; set;}

        /// <summary>
        /// Otorga una lista de strings que representan las especializaciones del Emprendedor.
        /// </summary>
        /// <value></value>
        [JsonInclude]
        public ArrayList Especializaciones {get{return this.especializaciones;} set{this.especializaciones = value;}}

        /// <summary>
        /// Otorga una lista de strings que representan las compras del Emprendedor.
        /// </summary>
        /// <value></value>
        [JsonInclude]
        public List<Oferta> Compras {get{return this.compras;} set {this.compras = value;}}

        /// <summary>
        /// Constructor vacio utilizado para la serializacion.
        /// </summary>
        [JsonConstructor]
        public Emprendedor() {}

        /// <summary>
        /// Inicializa la clase Emprendedor
        /// </summary>
        /// <param name="ubicacion"></param>
        /// <param name="rubro"></param>
        /// <param name="habilitacion"></param>
        public Emprendedor(string ubicacion, Rubro rubro, Habilitaciones habilitacion)
        {
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
            this.Habilitacion = habilitacion;
        }

        /// <summary>
        /// Agrega una habilitacion.
        /// </summary>
        /// <param name="habilitacion"></param>
        public void AgregarHabilitacion(string habilitacion) //(Expert)
        {
            Habilitaciones newHab = new Habilitaciones(habilitacion);
            this.Habilitacion = newHab;
        }

        /// <summary>
        /// Agrega un rubro.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(string rubro) //(Expert)
        {
            Rubro newRubro = new Rubro(rubro);
            this.Rubro = newRubro;
        }

        /// <summary>
        /// Agrega una Especialización al Emprendedor.
        /// </summary>
        public void AgregarEspecializacion(string especializacion) //(Expert)
        {
            ArrayList especializaciones = this.Especializaciones;
            especializaciones.Add(especializacion);
        }
        /// <summary>
        /// Elimina una Especialización al Emprendedor.
        /// </summary>
        public void EliminarEspecializacion(string especializacion) //(Expert)
        {
            ArrayList especializaciones = this.Especializaciones;
            especializaciones.Remove(especializacion);
        }

        /// <summary>
        /// Como emprendedor, quiero saber cuántos materiales o residuos consumí en un período de tiempo, para de esa forma tener un control de mis insumos.
        /// </summary>
        public string VerificarConsumo(string date) //(Expert)
        {
            Dictionary<string, int> info = new Dictionary<string, int>();
            StringBuilder str = new StringBuilder();

            foreach (Oferta oferta in this.Compras)
            {
                if (oferta.IsVendido == true && oferta.SoldDate.Month == Int32.Parse(date))
                {
                    if (info.ContainsKey(oferta.Product.Tipo.Nombre))
                    {
                        info[oferta.Product.Tipo.Nombre] += oferta.Product.Cantidad;
                    }
                    else
                    {
                        info.Add(oferta.Product.Tipo.Nombre, oferta.Product.Cantidad);
                    }
                }
            }

            foreach (KeyValuePair<string, int> item in info)
            {
                str.Append($"{item.Key} = {item.Value}{Singleton<Datos>.Instance.GetUnidadMedida(item.Key)}");
            }
            return str.ToString();
        }
    }
}
