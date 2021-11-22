using System.Collections;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa a los usuarios emprendedores en el sistema.
    /// La función de esta clase es la de representar a un usuario que interactúa con el sistema que se identifica como emprendedor. 
    /// Debido a esto, la única responsabilidad de esta clase es la de proveer con un nexo entre las interacciones de usuario y los datos de este usuario, 
    /// los cuales se almacenan en la clase "Emprendedor" y los accede mediante el patrón de Delegación. Por lo cual, esta clase sigue con el patrón de SRP.
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
            this.Emprendedor.AgregarHabilitacion(habilitacion); //(Delegación)
        }

        /// <summary>
        /// Agrega un rubro.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(string rubro)
        {
            this.Emprendedor.AgregarRubro(rubro); //(Delegación)
        }

        /// <summary>
        /// Agrega a la lista de especializaciones que contiene la clase "Emprendedor" una especialización.
        /// </summary>
        public void AgregarEspecializacion(string especializacion) 
        {
            this.Emprendedor.AgregarEspecializacion(especializacion); //(Delegación)
        }
        
        /// <summary>
        /// Elimina de la lista de especializaciones que contiene la clase "Emprendedor una especialización.
        /// </summary>
        public void EliminarEspecializacion(string especializacion) 
        {
            this.Emprendedor.EliminarEspecializacion(especializacion); //(Delegacion)
        }

        /// <summary>
        /// Como emprendedor, quiero saber cuántos materiales o residuos consumí en un período de tiempo, para de esa forma tener un control de mis insumos.
        /// </summary>
        /// <return></return>
        public string ConsumoXTiempo()
        {
            return this.Emprendedor.ConsumoXTiempo(this); //(Delegación)
        }
        
        
        /// <summary>
        /// En base a una palabra clave, busca todas las ofertas que la contengan.
        /// </summary>
        /// <return></return>
        
        public string VerOfertasPalabraClave(string palabraClave)
        {
            Buscador buscador = new Buscador();
            buscador.VerOfertasPalabraClave(palabraClave); //(Delegación)
            return buscador.Content;
        }
        /// <summary>
        /// En base a la ubicación del Emprendedor, retorna una lista con todas las ofertas que se encuentren a una distancia de 10km o menos; utilizando el LocationApi.
        /// </summary>
        public string VerOfertasUbicacion()
        {
            Buscador buscador = new Buscador(); //(Delegación)
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
            buscador.VerOfertasTipo(tipo); //(Delegación)
            return buscador.Content;
        }
        
    }
}