using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase tiene como función almacenar datos de distintas clases y revisar que los datos ingresados sean los permitidos por el programa.
    /// </summary>
    public class Datos
    {   
        private string[] listaAdmins = {
                                        "2051203726",
                                       };
        private ArrayList listaRubros = new ArrayList() {
                                        "Rubro-1",
                                        "Rubro-2",
                                        "Rubro-3"
                                        };
        private ArrayList listaTipos = new ArrayList() {
                                        "Tipo-1",
                                        "Tipo-2",
                                        "Tipo-3"
                                        };
        private ArrayList listaHabilitaciones = new ArrayList() {
                                        "Hab-1",
                                        "Hab-2",
                                        "Hab-3"
                                        };
        private ArrayList listaTokens = new ArrayList();
        private ArrayList listaOfertas = new ArrayList();
        private ArrayList listaUsuarioEmpresa = new ArrayList();
        private ArrayList listaUsuarioEmprendedor = new ArrayList();
        private ArrayList listaEmpresa = new ArrayList();
        private ArrayList listaUsuariosRegistrados = new ArrayList();
        
        /// <summary>
        /// Lista de usuarios registrados mediante el handler "RegisterHandler"
        /// </summary>
        /// <returns>Lista con los usuarios registrados.</returns>
        public ArrayList ListaUsuariosRegistrados()
        {
            return this.listaUsuariosRegistrados;
        }
      
        public bool IsRegistered(string id)
        {
            foreach (IUser user in this.listaUsuariosRegistrados)
            {
                if (id == user.Id)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public string[] ListaAdmins()
        {
            return this.listaAdmins;
        }
        public bool IsAdmin(string token)
        {
            return this.listaAdmins.Contains(token);
        }

        public ArrayList ListaTokens()
        {
            return this.listaTokens;
        }

        public void AgregarToken(string token)
        {
            this.listaTokens.Add(token);
        }

        public void EliminarToken(string token)
        {
            this.listaTokens.Remove(token);
        }

        public bool IsTokenValid(string token)
        {
            return this.listaTokens.Contains(token);
        }

        /// <summary>
        /// Otorga una lista con todas las publicaciones realizadas.
        /// </summary>
        /// <returns>Lista con Oferta.</returns>
        public ArrayList ListaOfertas()
        {
            return this.listaOfertas;
        }

        /// <summary>
        /// Agrega una oferta a la lista de publicaciones.
        /// </summary>
        /// <param name="oferta"></param>
        public void AgregarOferta(Oferta oferta)
        {
            this.listaOfertas.Add(oferta);
        }

        /// <summary>
        /// Otorga una lista con todos los UserEmpresa registrados en la aplicacion.
        /// </summary>
        /// <returns>Lista con UserEmpresa</returns>
        public ArrayList ListaUsuarioEmpresa()
        {
            return this.listaUsuarioEmpresa;
        }

        /// <summary>
        /// Agrega un UserEmpresa a la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        public void AgregarUsuarioEmpresa(UserEmpresa user)
        {
            this.listaUsuarioEmpresa.Add(user);
        }

        /// <summary>
        /// Otorga una lista con todos los UserEmprendedor registrados.
        /// </summary>
        /// <returns>Lista con UserEmprendedor</returns>
        public ArrayList ListaUsuarioEmprendedor()
        {
            return this.listaUsuarioEmprendedor;
        }

        /// <summary>
        /// Agrega un UserEmprendedor a la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        public void AgregarUsuarioEmprendedor(UserEmprendedor user)
        {
            this.listaUsuarioEmprendedor.Add(user);
        }

        /// <summary>
        /// Lista con todas las Empresa registradas.
        /// </summary>
        /// <returns>Lista con Empresa</returns>
        public ArrayList ListaEmpresa()
        {
            return this.listaEmpresa;
        }

        /// <summary>
        /// Agrega una empresa a la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        public void AgregarEmpresa(Empresa user)
        {
            this.listaEmpresa.Add(user);
        }

        ///<summary>
        /// Otorga una lista de habilitaciones registradas por el programa <see cref="Habilitaciones"/>.
        /// </summary>
        /// <returns>Retorna la lista "listaHabilitaciones" de la clase "Datos".</returns>  
        public ArrayList ListaHabilitaciones()
        {
            return this.listaHabilitaciones;
        }

        /// <summary>
        /// Otorga una lista de tipos de producto (plástico, tela, etc...) registradas por el programa <see cref="TipoProducto"/>.
        /// </summary>
        /// <returns>Retorna la lista "listaTipos" de la clase "Datos".</returns>
        public ArrayList ListaTipos()
        {
            return this.listaTipos;
        }

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
        /// Agrega una oferta de la lista de ofertas.
        /// </summary>
        /// <param name="oferta"></param>
        public void AgregarOfertas(Oferta oferta)
        {
            listaOfertas.Add(oferta);
        }

        /// <summary>
        /// Elimina una oferta de la lista de ofertas.
        /// </summary>
        /// <param name="oferta"></param>
        public void EliminarOfertas(Oferta oferta)
        {
            listaOfertas.Remove(oferta);
        }

        /// <summary>
        /// Revisa si la habilitación que el usuario quiere asignarse existe dentro de las habilitaciones permitidas por el programa.
        /// </summary>
        /// <param name="habilitacion"></param>
        /// <returns><c>true</c>Si la habilitación a agregar concuerda con las existentes en el programa,<c>false</c> en caso contrario.</returns>
        public bool CheckHabilitaciones(string habilitacion)
        {
            if (this.listaHabilitaciones.Contains(habilitacion))
            {
                return true;
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
            if (this.listaTipos.Contains(tipoProducto))
            {
                return true;
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
            if (this.listaRubros.Contains(rubro))
            {
                return true;
            }
            return false; 
        }
    }
}