
//using Ucu.Poo.Locations.Client;
using System.Text;
using System.Threading.Tasks;
using System;

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

        /*
        /// <summary>
        /// /// En base a la ubicación del Emprendedor, retorna una lista con todas las ofertas que se encuentren a una distancia de 10km o menos; utilizando el LocationApi <see cref="LocationApiClient"/>.
        /// </summary>
        /// <param name="direccion"></param>
        public async void VerOfertasUbicacion(string direccion)
        {
            ContentBuilder.Clear();
            
            LocationApiClient client = new LocationApiClient();
            var taskEmprendedor = client.GetLocationAsync(direccion);
            taskEmprendedor.Wait();
            Location ubicacionEmprendedor = taskEmprendedor.Result;
            foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                var taskLocation = client.GetLocationAsync(oferta.Product.Ubicacion);
                taskLocation.Wait();
                Location ubicacionOferta = taskLocation.Result;
                var taskDistance = client.GetDistanceAsync(ubicacionEmprendedor,ubicacionOferta);
                taskDistance.Wait();
                Distance distance = taskDistance.Result;
                
                if (distance.TravelDistance <= 100000.0)
                {
                    ContentBuilder.Append($"Esta oferta está a {distance.TravelDistance}m de su ubicación: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n");
                }
            }
            if(ContentBuilder.ToString() == "")
                {
                    ContentBuilder.Append("No se encontraron ofertas que estén en su cercanía.");
                }
        }
        */

        /// <summary>
        /// En base a una palabra clave recibida, otorga todas las ofertas que tengan la misma palabra clave
        /// </summary>
        /// <param name="palabraClave"></param>
        /// <returns></returns>
        public void VerOfertasPalabraClave(string palabraClave)
        {
            ContentBuilder.Clear();
            foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                foreach(string palabrasClave in oferta.PalabrasClave)
                {
                    if(palabraClave.ToLower() == palabrasClave.ToLower())
                    {
                        ContentBuilder.Append($"Esta oferta concuerda con la palabra clave que colocó: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n");
                    }
                }
                if(ContentBuilder.ToString() == "")
                {
                    ContentBuilder.Append("No se encontraron ofertas que concuerdan con esa palabra clave.");
                }
            }
        }

        /// <summary>
        /// En base a un tipo de producto recibido, otorga todas las ofertas que tengan el mismo tipo
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public void VerOfertasTipo(string tipo)
        {
            ContentBuilder.Clear();
            foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                if(tipo == oferta.Product.Tipo.Nombre)
                {
                    ContentBuilder.Append($"Esta oferta concuerda con el tipo que describió: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n");
                }
            }
            if(ContentBuilder.ToString() == "")
            {
                ContentBuilder.Append("No se encontraron ofertas que concuerden con el tipo de producto deseado.");
            }
        }     
    }
}