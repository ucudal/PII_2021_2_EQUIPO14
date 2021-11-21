using System.Collections;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa a los usuarios emprendedores en el sistema.
    /// </summary>
    public class UserEmprendedor : IUser
    {

        /// <summary>
        /// Otorga el id del usuario.
        /// </summary>
        /// <value>Id del usuario.</value>
        public string Id { get; set; }

        /// <summary>
        /// Otorga el nombre del Emprendedor.
        /// </summary>
        /// <value>Nombre del Emprendedor.</value>
        public string Nombre { get; set;}

        /// <summary>
        /// Otorga los datos existentes en el objeto Emprendedor <see cref="Emprendedor"/>.
        /// </summary>
        /// <value></value>
        
        public Emprendedor Emprendedor { get; set; }

        /// <summary>
        /// Inicializa la clase UserEmprendedor.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="id"></param>
        public UserEmprendedor(string id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Agrega una habilitacion.
        /// </summary>
        /// <param name="habilitacion"></param>
        public void AgregarHabilitacion(string habilitacion)
        {
            this.Emprendedor.AgregarHabilitacion(habilitacion);
        }

        /// <summary>
        /// Agrega un rubro.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(string rubro)
        {
            this.Emprendedor.AgregarRubro(rubro);
        }

        /// <summary>
        /// Agrega a la lista de especializaciones que contiene la clase "Emprendedor" una especialización.
        /// </summary>
        public void AgregarEspecializacion(string especializacion)
        {
            this.Emprendedor.AgregarEspecializacion(especializacion);
        }
        
        /// <summary>
        /// Elimina de la lista de especializaciones que contiene la clase "Emprendedor una especialización.
        /// </summary>
        public void EliminarEspecializacion(string especializacion)
        {
            this.Emprendedor.EliminarEspecializacion(especializacion);
        }

        /// <summary>
        /// Como emprendedor, quiero saber cuántos materiales o residuos consumí en un período de tiempo, para de esa forma tener un control de mis insumos.
        /// </summary>
        /// <return></return>
        public string ConsumoXTiempo()
        {
            return this.Emprendedor.ConsumoXTiempo(this);
        }
        
        /*
        /// <summary>
        /// En base a una palabra clave, busca todas las ofertas que la contengan.
        /// </summary>
        /// <return></return>
        
        public string VerOfertasPalabraClave(string palabraClave)
        {
            Buscador buscador = new Buscador();
            buscador.VerOfertasPalabraClave(palabraClave);
            return buscador.Content;
        }
        /// <summary>
        /// En base a la ubicación del Emprendedor, retorna una lista con todas las ofertas que se encuentren a una distancia de 10km o menos; utilizando el LocationApi.
        /// </summary>
        public string VerOfertasUbicacion()
        {
            Buscador buscador = new Buscador();
            buscador.VerOfertasUbicacion(this.Emprendedor.Ubicacion);
            return buscador.Content;
        }

        /// <summary>
        /// En base a un tipo de producto recibido, otorga todas las ofertas que tengan el mismo tipo.
        /// </summary>
        /// <param name="tipo"></param>
        public string VerOfertasTipo(string tipo)
        {
            Buscador buscador = new Buscador();
            buscador.VerOfertasTipo(tipo);
            return buscador.Content;
        }
        */
    }
}