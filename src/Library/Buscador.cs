using Ucu.Poo.Locations.Client;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// 
    /// </summary>
    public class Buscador
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Content
        {
            get
            {
                return this.ContentBuilder.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private StringBuilder ContentBuilder { get; } = new StringBuilder();

        /// <summary>
        /// En base a la ubicación del Emprendedor, retorna una lista con todas las ofertas que se encuentren a una distancia de 10km o menos; utilizando el LocationApi <see cref="LocationApiClient"/>.
        /// </summary>
        public async Task<StringBuilder> VerOfertasUbicacion(string direccion)
        {
            LocationApiClient client = new LocationApiClient();
            Location ubicacionEmprendedor = await client.GetLocationAsync(direccion);
            foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                Location ubicacionOferta = await client.GetLocationAsync(oferta.Product.Ubicacion);
                Distance distance = await client.GetDistanceAsync(ubicacionEmprendedor,ubicacionOferta);
                if (distance.TravelDistance <= 10)
                {
                    ContentBuilder.Append($"{oferta} \n");
                }
            }
            return ContentBuilder;
        }

        /// <summary>
        /// En base a una palabra clave recibida, otorga todas las ofertas que tengan la misma palabra clave
        /// </summary>
        /// <param name="palabraClave"></param>
        /// <returns></returns>
        public string VerOfertasPalabraClave(string palabraClave)
        {
            StringBuilder result = new StringBuilder();
            foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                foreach(string palabrasClave in oferta.PalabrasClave)
                {
                    if(palabraClave == palabrasClave)
                    {
                        result.Append($"{oferta} \n");
                    }
                }
                if(result.ToString() == "")
                {
                    result.Append("No se encontraron ofertas que concuerdan con esa palabra clave.");
                }
            }
            return result.ToString();
        }
        /// <summary>
        /// En base a un tipo de producto recibido, otorga todas las ofertas que tengan el mismo tipo
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public string VerOfertasTipo(string tipo)
        {
            StringBuilder result = new StringBuilder();
            foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                foreach(string tipoproduct in oferta.Product.Tipo)
                {
                    if(tipo == tipoproduct)
                    {
                        result.Append($"{oferta} \n");
                    }
                }
                if(result.ToString() == "")
                {
                    result.Append("No se encontraron ofertas que concuerden con el tipo de producto deseado.");
                }
            }
            return result.ToString();
        }
    }
}