using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase tiene como función almacenar datos de distintas clases y revisar que los datos ingresados sean los permitidos por el programa.
    /// Se utilizan los patrones Expert y Singleton, ya que es necesario que exista una sola instancia de esta clase datos, 
    /// lo cual implica que la manera de retornar las listas es en base a un método de instancia. 
    /// Además, debido a que esta almacena las listas, es experta para modificar los datos existentes.
    /// </summary>
    public sealed class Datos
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
        private ArrayList listaTokens = new ArrayList() {
                                        "TOKEN"
                                        };
        private ArrayList listaOfertas = new ArrayList();
        private ArrayList listaUsuarioEmpresa = new ArrayList();
        private ArrayList listaUsuarioEmprendedor = new ArrayList();
        private ArrayList listaEmpresa = new ArrayList();
        private ArrayList listaUsuariosRegistrados = new ArrayList();
        
        /// <summary>
        /// Busca las ofertas por ID y retorna la oferta.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oferId"></param>
        /// <returns>Retorna una Oferta.</returns>
        public Oferta GetOfertaById(string userId, string oferId)
        {
            UserEmpresa user = (UserEmpresa)this.GetUserById(userId);
            foreach (Oferta oferta in user.Empresa.Ofertas)
            {
                if (oferta.Id == oferId)
                {
                    return oferta;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Busca entre los usuarios registrados por id y retorna el usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un IUser.</returns>
        public IUser GetUserById(string id) //(Expert)
        {
            foreach (IUser user in this.listaUsuariosRegistrados)
            {
                if (user.Id == id)
                {
                    return user;
                }
                Console.WriteLine($"USER WITH ID: {id} NOT FOUND.");
                return null;
            }
            Console.WriteLine($"USER WITH ID: {id} NOT FOUND.");
            return null;
        }

        /// <summary>
        /// Lista de usuarios registrados mediante el handler "RegisterHandler"
        /// </summary>
        /// <returns>Lista con los usuarios registrados.</returns>
        public ArrayList ListaUsuariosRegistrados() //(Singleton)
        {
            return this.listaUsuariosRegistrados;
        }

        public void ImprimirUsuarios()
        {
            int cont = 0;
            Console.WriteLine("--LISTA DE USUARIOS REGISTRADOS--");
            foreach (IUser user in this.listaUsuariosRegistrados)
            {
                Console.WriteLine($"Usuario {cont}: <{user.Id}>");
                cont+=1;
            }
            Console.WriteLine("---------------------------------");
        }
      
        /// <summary>
        /// Verifica si la id ya esta registrada.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve true si la id esta registrada, false de lo contrario</returns>
        public bool IsRegistered(string id) //(Expert)
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

        /// <summary>
        /// Devuelve una lista con los ids de admins validos.
        /// </summary>
        /// <returns>Lista de ids de admins.</returns>
        public string[] ListaAdmins() //(Singleton)
        {
            return this.listaAdmins;
        }

        /// <summary>
        /// Verifica si es un admin.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Devuelve true sie es un admin, false de lo contrario.</returns>
        public bool IsAdmin(string token) //(Expert)
        {
            return this.listaAdmins.Contains(token);
        }

        /// <summary>
        /// Devuelve la lista de tokens validos.
        /// </summary>
        /// <returns>Lista de tokens validos.</returns>
        public ArrayList ListaTokens() //(Singleton)
        {
            return this.listaTokens;
        }

        /// <summary>
        /// Agrega un token a la lista.
        /// </summary>
        /// <param name="token"></param>
        public void AgregarToken(string token) //(Expert)
        {
            this.listaTokens.Add(token);
        }

        /// <summary>
        /// Elimina un token de la lista.
        /// </summary>
        /// <param name="token"></param>
        public void EliminarToken(string token) //(Expert)
        {
            this.listaTokens.Remove(token);
        }

        /// <summary>
        /// Verifica si el token es valido.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Devuelve true si es valido, false de lo contrario.</returns>
        public bool IsTokenValid(string token) //(Expert)
        {
            return this.listaTokens.Contains(token);
        }

        /// <summary>
        /// Otorga una lista con todas las publicaciones realizadas.
        /// </summary>
        /// <returns>Lista con Oferta.</returns>
        public ArrayList ListaOfertas() //(Singleton)
        {
            return this.listaOfertas;
        }

        /// <summary>
        /// Agrega una oferta a la lista de publicaciones.
        /// </summary>
        /// <param name="oferta"></param>
        public void AgregarOferta(Oferta oferta) //(Expert)
        {
            this.listaOfertas.Add(oferta);
        }

        /// <summary>
        /// Otorga una lista con todos los UserEmpresa registrados en la aplicacion.
        /// </summary>
        /// <returns>Lista con UserEmpresa</returns>
        public ArrayList ListaUsuarioEmpresa() //(Singleton)
        {
            return this.listaUsuarioEmpresa;
        }

        /// <summary>
        /// Agrega un UserEmpresa a la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        public void AgregarUsuarioEmpresa(UserEmpresa user) //(Expert)
        {
            this.listaUsuarioEmpresa.Add(user);
        }

        /// <summary>
        /// Otorga una lista con todos los UserEmprendedor registrados.
        /// </summary>
        /// <returns>Lista con UserEmprendedor</returns>
        public ArrayList ListaUsuarioEmprendedor() //(Singleton)
        {
            return this.listaUsuarioEmprendedor;
        }

        /// <summary>
        /// Agrega un UserEmprendedor a la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        public void AgregarUsuarioEmprendedor(UserEmprendedor user) //(Expert)
        {
            this.listaUsuarioEmprendedor.Add(user);
        }

        /// <summary>
        /// Lista con todas las Empresa registradas.
        /// </summary>
        /// <returns>Lista con Empresa</returns>
        public ArrayList ListaEmpresa() //(Singleton)
        {
            return this.listaEmpresa;
        }

        /// <summary>
        /// Agrega una empresa a la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        public void AgregarEmpresa(Empresa user) //(Expert)
        {
            this.listaEmpresa.Add(user);
        }

        ///<summary>
        /// Otorga una lista de habilitaciones registradas por el programa <see cref="Habilitaciones"/>.
        /// </summary>
        /// <returns>Retorna la lista "listaHabilitaciones" de la clase "Datos".</returns>  
        public ArrayList ListaHabilitaciones() //(Singleton)
        {
            return this.listaHabilitaciones;
        }

        /// <summary>
        /// Otorga una lista de tipos de producto (plástico, tela, etc...) registradas por el programa <see cref="TipoProducto"/>.
        /// </summary>
        /// <returns>Retorna la lista "listaTipos" de la clase "Datos".</returns>
        public ArrayList ListaTipos() //(Singleton)
        {
            return this.listaTipos;
        }

        ///<summary>
        /// Otorga una lista de rubros disponibles para asignarle a una empresa <see cref="Rubro"/>.
        /// </summary>
        /// <returns>Retorna una lista "listaRubros" de la clase "Datos".</returns>//  
        public ArrayList ListaRubros() //(Singleton)
        {
            return this.listaRubros;
        }

        /// <summary>
        /// Agrega una habilitación a la lista de habilitaciones permitidas por el programa.
        /// </summary>
        /// <param name="habilitacion"></param>
        public void AgregarHabilitacion(Habilitaciones habilitacion) //(Expert)
        {
            listaHabilitaciones.Add(habilitacion);
        }

        /// <summary>
        /// Elimina una habilitación de la lista de habilitaciones permitidas por el programa.
        /// </summary>
        /// <param name="habilitacion"></param>
        public void EliminarHabilitacion(Habilitaciones habilitacion) //(Expert)
        {
            listaHabilitaciones.Remove(habilitacion);
        }

        /// <summary>
        /// Agrega un rubro a la lista de rubros permitidos por el programa.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(Rubro rubro) //(Expert)
        {
            listaRubros.Add(rubro);
        }

        /// <summary>
        /// Elimina un rubro de la lista de rubros permitidos por el programa.
        /// </summary>
        /// <param name="rubro"></param>
        public void EliminarRubro(Rubro rubro) //(Expert)
        {
            listaRubros.Remove(rubro);
        }

        /// <summary>
        /// Agrega un tipo de producto a la lista de tipos de productos permitidos por el programa.
        /// </summary>
        /// <param name="tipo"></param>
        public void AgregarTipo(TipoProducto tipo) //(Expert)
        {
            listaTipos.Add(tipo);
        }

        /// <summary>
        /// Elimina un tipo de producto de la lista de tipos de productos permitidos por el programa.
        /// </summary>
        /// <param name="tipo"></param>
        public void EliminarTipo(TipoProducto tipo) //(Expert)
        {
            listaTipos.Remove(tipo);
        }

        /// <summary>
        /// Elimina una oferta de la lista de ofertas.
        /// </summary>
        /// <param name="oferta"></param>
        public void EliminarOfertas(Oferta oferta) //(Expert)
        {
            listaOfertas.Remove(oferta.Id);
        }

        /// <summary>
        /// Revisa si la habilitación que el usuario quiere asignarse existe dentro de las habilitaciones permitidas por el programa.
        /// </summary>
        /// <param name="habilitacion"></param>
        /// <returns><c>true</c>Si la habilitación a agregar concuerda con las existentes en el programa,<c>false</c> en caso contrario.</returns>
        public bool CheckHabilitaciones(string habilitacion) //(Expert)
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
        public bool CheckTipos(string tipoProducto) //(Expert)
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
        public bool CheckRubros(string rubro) //(Expert)
        {
            if (this.listaRubros.Contains(rubro))
            {
                return true;
            }
            return false; 
        }
    }
}