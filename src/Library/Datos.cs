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
            listaHabilitaciones.Add(habilitacion);
        }

        public void EliminarHabilitacion(Habilitaciones habilitacion)
        {
            listaHabilitaciones.Remove(habilitacion);
        }

        public void AgregarRubro(Rubro rubro)
        {
            listaRubros.Add(rubro);
        }

        public void EliminarRubro(Rubro rubro)
        {
            listaRubros.Remove(rubro);
        }

        public void AgregarTipo(TipoProducto tipo)
        {
            listaTipos.Add(tipo);
        }

        public void EliminarTipo(TipoProducto tipo)
        {
            listaTipos.Remove(tipo);
        
        }

        public bool CheckHabilitaciones(string habilitacion)
        {
            Habilitaciones habilitacionACheckear = new Habilitaciones(habilitacion);
            foreach(Habilitaciones habilitacionAlmacenada in Singleton<Datos>.Instance.ListaHabilitaciones())
            {
                if(habilitacionACheckear == habilitacionAlmacenada)
                {
                    return true;
                }
            }
            return false; 
        }

        public bool CheckTipos(string tipoProducto)
        {
            TipoProducto tipoACheckear = new TipoProducto(tipoProducto);
            foreach(TipoProducto tiposAlmacenados in Singleton<Datos>.Instance.ListaTipos())
            {
                if(tipoACheckear == tiposAlmacenados)
                {
                    return true;
                }
            }
            return false; 
        }

        public bool CheckRubros(string rubro)
        {
            Rubro rubroACheckear = new Rubro(rubro);
            foreach(Rubro rubroAlmacenado in Singleton<Datos>.Instance.ListaRubros())
            {
                if(rubroACheckear == rubroAlmacenado)
                {
                    return true;
                }
            }
            return false; 
        }
    }
}