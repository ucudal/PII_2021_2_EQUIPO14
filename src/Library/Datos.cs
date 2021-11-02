using System;
using System.Collections;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase tiene como función almacenar datos de distintas clases y revisar que los datos ingresados sean los permitidos por el programa.
    /// </summary>
    public class Datos
    {
        private ArrayList listaOfertas = new ArrayList();

        public ArrayList ListaOfertas()
        {
            return this.listaOfertas;
        }

        public void AgregarOferta(Oferta oferta)
        {
            this.listaOfertas.Add(oferta);
        }
        private ArrayList listaUsuarioEmpresa = new ArrayList();

        public ArrayList ListaUsuarioEmpresa()
        {
            return this.listaUsuarioEmpresa;
        }

        public void AgregarUsuarioEmpresa(UserEmpresa user)
        {
            this.listaUsuarioEmpresa.Add(user);
        }

        private ArrayList listaUsuarioEmprendedor = new ArrayList();

        public ArrayList ListaUsuarioEmprendedor()
        {
            return this.listaUsuarioEmprendedor;
        }

        public void AgregarUsuarioEmprendedor(UserEmprendedor user)
        {
            this.listaUsuarioEmprendedor.Add(user);
        }

        private ArrayList listaEmpresa = new ArrayList();

        public ArrayList ListaEmpresa()
        {
            return this.listaEmpresa;
        }

        public void AgregarEmpresa(Empresa user)
        {
            this.listaEmpresa.Add(user);
        }
        private ArrayList listaHabilitaciones = new ArrayList();

        ///<summary>
        /// Otorga una lista de habilitaciones registradas por el programa <see cref="Habilitaciones"/>.
        /// </summary>
        /// <returns>Retorna la lista "listaHabilitaciones" de la clase "Datos".</returns>  
        public ArrayList ListaHabilitaciones()
        {
            return this.listaHabilitaciones;
        }
        private ArrayList listaTipos = new ArrayList();

        /// <summary>
        /// Otorga una lista de tipos de producto (plástico, tela, etc...) registradas por el programa <see cref="TipoProducto"/>.
        /// </summary>
        /// <returns>Retorna la lista "listaTipos" de la clase "Datos".</returns>
        public ArrayList ListaTipos()
        {
            return this.listaTipos;
        }

        private ArrayList listaRubros = new ArrayList();

        ///<summary>
        /// Otorga una lista de rubros disponibles para asignarle a una empresa <see cref="Rubro"/>.
        /// </summary>
        /// <returns>Retorna una lista "listaRubros" de la clase "Datos".</returns>//  
        public ArrayList ListaRubros()
        {
            return this.listaRubros;
        }

        /// <summary>
        /// Agrega una habilitación a la lista de habilitaciones permitidas por el programa.
        /// </summary>
        /// <param name="habilitacion"></param>
        public void AgregarHabilitacion(Habilitaciones habilitacion)
        {
            listaHabilitaciones.Add(habilitacion);
        }

        /// <summary>
        /// Elimina una habilitación de la lista de habilitaciones permitidas por el programa.
        /// </summary>
        /// <param name="habilitacion"></param>
        public void EliminarHabilitacion(Habilitaciones habilitacion)
        {
            listaHabilitaciones.Remove(habilitacion);
        }

        /// <summary>
        /// Agrega un rubro a la lista de rubros permitidos por el programa.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(Rubro rubro)
        {
            listaRubros.Add(rubro);
        }

        /// <summary>
        /// Elimina un rubro de la lista de rubros permitidos por el programa.
        /// </summary>
        /// <param name="rubro"></param>
        public void EliminarRubro(Rubro rubro)
        {
            listaRubros.Remove(rubro);
        }

        /// <summary>
        /// Agrega un tipo de producto a la lista de tipos de productos permitidos por el programa.
        /// </summary>
        /// <param name="tipo"></param>
    
        public void AgregarTipo(TipoProducto tipo)
        {
            listaTipos.Add(tipo);
        }

        /// <summary>
        /// Elimina un tipo de producto de la lista de tipos de productos permitidos por el programa.
        /// </summary>
        /// <param name="tipo"></param>
        public void EliminarTipo(TipoProducto tipo)
        {
            listaTipos.Remove(tipo);
        }

        /// <summary>
        /// Revisa si la habilitación que el usuario quiere asignarse existe dentro de las habilitaciones permitidas por el programa.
        /// </summary>
        /// <param name="habilitacion"></param>
        /// <returns><c>true</c>Si la habilitación a agregar concuerda con las existentes en el programa,<c>false</c> en caso contrario.</returns>
        public bool CheckHabilitaciones(string habilitacion)
        {
            foreach(Habilitaciones habilitacionAlmacenada in Singleton<Datos>.Instance.ListaHabilitaciones())
            {
                if(habilitacion == habilitacionAlmacenada.Habilitacion)
                {
                    return true;
                }
            }
            return false; 
        }

        /// <summary>
        /// Revisa si el tipo de producto que el usuario quiere asignar al producto existe dentro de los tipos de productos permitidos por el programa.
        /// </summary>
        /// <param name="tipoProducto"></param>
        /// <returns><c>true</c>Si el tipo de producto a agregar concuerda con los existentes en el programa,<c>false</c> en caso contrario.</returns>
        public bool CheckTipos(string tipoProducto)
        {
            foreach(TipoProducto tiposAlmacenados in Singleton<Datos>.Instance.ListaTipos())
            {
                if(tipoProducto == tiposAlmacenados.Nombre)
                {
                    return true;
                }
            }
            return false; 
        }
        /// <summary>
        /// Revisa si el rubro que el usuario quiere asignar a una empresa existe dentro de los rubros permitidos por el programa.
        /// </summary>
        /// <param name="rubro"></param>
        /// <returns><c>true</c>Si el rubro a agregar concuerda con los existentes en el programa,<c>false</c> en caso contrario.</returns>
        public bool CheckRubros(string rubro)
        {
            foreach(Rubro rubroAlmacenado in Singleton<Datos>.Instance.ListaRubros())
            {
                if(rubro == rubroAlmacenado.Rubros)
                {
                    return true;
                }
            }
            return false; 
        }
    }
}