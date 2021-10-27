using System.Collections;

namespace Proyecto_Final
{
    public class Datos
    {
        private ArrayList listaHabilitaciones = new ArrayList(); 

        public ArrayList ListaHabilitaciones
        {
            get
            {
                return this.listaHabilitaciones;
            }
        }

        public void AgregarHabilitacion(Habilitaciones habilitacion)
        {
            ListaHabilitaciones.Add(habilitacion);
        }

        public void EliminarHabilitacion(Habilitaciones habilitacion)
        {
            ListaHabilitaciones.Remove(habilitacion);
        }
        
        
        public Datos()
        {

        }

    }
}