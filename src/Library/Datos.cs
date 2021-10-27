using System.Collections;

namespace Proyecto_Final
{
    public class Datos
    {
        private ArrayList listaHabilitaciones = new ArrayList(); 
        public ArrayList ListaHabilitaciones()
        {
            return this.listaHabilitaciones;
        }

        private ArrayList listaTipos = new ArrayList(); 
        public ArrayList ListaTipos()
        {
            return this.listaTipos;
        }

        private ArrayList listaRubros = new ArrayList(); 
        public ArrayList ListaRubros()
        {
            return this.listaRubros;
        }

        public void AgregarHabilitacion(Habilitaciones habilitacion)
        {
            ListaHabilitaciones.Add(habilitacion);
        }

        public void EliminarHabilitacion(Habilitaciones habilitacion)
        {
            ListaHabilitaciones.Remove(habilitacion);
        }

        public void AgregarRubro(Rubro rubro)
        {
            ListaRubros.Add(rubro);
        }

        public void EliminarRubro(Rubro rubro)
        {
            ListaRubros.Remove(rubro);
        }

        public void AgregarTipo(TipoProducto tipo)
        {
            ListaTipos.Add(tipo);
        }

        public void EliminarTipo(TipoProducto tipo)
        {
            ListaTipos.Remove(tipo);
        
        }

        public bool CheckHabilitaciones(string habilitacion)
        {
            //Singleton<Datos>.Instance.ListaHabilitaciones(); 

        }

        public bool CheckTipos(string habilitacion)
        {
            
        }

        public bool CheckRubros(string habilitacion)
        {
            
        }
    }
}