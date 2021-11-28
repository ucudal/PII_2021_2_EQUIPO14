using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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
                                        "Hab-3",
                                        "No"
                                        };
        private List<string> listaTokens = new List<string>();
        private List<Oferta> listaOfertas = new List<Oferta>();
        private List<UserEmpresa> listaUsuarioEmpresa = new List<UserEmpresa>();
        private List<UserEmprendedor> listaUsuarioEmprendedor = new List<UserEmprendedor>();

        /// <summary>
        /// Al inicializar el programa se obtienen todos los datos de la DB.
        /// </summary>
        public void GetData()
        {
            this.LoadTokensData();
            this.LoadRegisteredEmpresas();
            this.LoadRegisteredEmprendedores();
            this.LoadPublications();
        }

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
            }
            Console.WriteLine($"OFFER WITH ID: {oferId} NOT FOUND.");
            return null;
        }

        /// <summary>
        /// Busca entre los usuarios registrados por id y retorna el usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un IUser.</returns>
        public IUser GetUserById(string id) //(Expert)
        {
            foreach (UserEmpresa userEmpresa in this.listaUsuarioEmpresa)
            {
                if (userEmpresa.Id == id)
                {
                    Console.WriteLine($"USEREMPRESA {id} ENCONTRADO");
                    return userEmpresa;
                }
            }
            foreach (UserEmprendedor userEmprendedor in this.listaUsuarioEmprendedor)
            {
                if (userEmprendedor.Id == id)
                {
                    Console.WriteLine($"USEREMPRENDEDOR {id} ENCONTRADO");
                    return userEmprendedor;
                }
            }                     
            Console.WriteLine($"USER WITH ID: {id} NOT FOUND.");
            return null;
        }

        /// <summary>
        /// Agrega un usuario Empresa a la lista de usuarios y actualiza la lista para que al momento de guardar el archivo .json, se actualizen los datos modificados.
        /// </summary>
        /// <param name="user"></param>
        public void RegistrarUsuarioEmpresa(UserEmpresa user)
        {
            this.listaUsuarioEmpresa.Add(user);
            this.UpdateEmpresasData();
        }

        /// <summary>
        /// Agrega un usuario Emprendedor a la lista de usuarios y actualiza la lista para que al momento de guardar el archivo .json, se actualizen los datos modificados.
        /// </summary>
        /// <param name="user"></param>
        public void RegistrarUsuarioEmprendedor(UserEmprendedor user)
        {
            this.listaUsuarioEmprendedor.Add(user);
            this.UpdateEmprendedoresData();
        }

        /// <summary>
        /// Verifica si una oferta es valida (no tiene comprador y existe).
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oferId"></param>
        /// <returns></returns>
        public bool IsOfferValid(string userId, string oferId)
        {
            foreach (UserEmpresa userEmpresa in this.listaUsuarioEmpresa)
            {
                if (userEmpresa.Id == userId)
                {
                    foreach (Oferta oferta in userEmpresa.Empresa.Ofertas)
                    {
                        if ((oferta.Id == oferId) && (oferta.Comprador == null))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si la id ya esta registrada.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve true si la id esta registrada, false de lo contrario</returns>
        public bool IsRegistered(string id) //(Expert)
        {
            foreach (UserEmpresa userEmpresa in this.listaUsuarioEmpresa)
            {
                if (userEmpresa.Id == id)
                {
                    return true;
                }
            }
            foreach (UserEmprendedor userEmprendedor in this.listaUsuarioEmprendedor)
            {
                if (userEmprendedor.Id == id)
                {
                    return true;
                }
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
        /// Checkea en base a un ID si esta ID pertenece a un UserEmprendedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true si la ID es de un objeto de UserEmprendedor, false si no lo es.</returns>
        public bool IsUserEmprendedor(string id)
        {
            foreach (UserEmprendedor user in this.listaUsuarioEmprendedor)
            {
                if (user.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checkea en base a un ID si esta ID pertenece a un UserEmpresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true si la ID es de un objeto de UserEmprensa, false si no lo es.</returns>
        public bool IsUserEmpresa(string id)
        {
            foreach (UserEmpresa user in this.listaUsuarioEmpresa)
            {
                if (user.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Devuelve la lista de tokens validos.
        /// </summary>
        /// <returns>Lista de tokens validos.</returns>
        public List<string> ListaTokens() //(Singleton)
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
            
            this.UpdateTokensData();
        }

        /// <summary>
        /// Elimina un token de la lista.
        /// </summary>
        /// <param name="token"></param>
        public void EliminarToken(string token) //(Expert)
        {
            this.listaTokens.Remove(token);

            this.UpdateTokensData();
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
        public List<Oferta> ListaOfertas() //(Singleton)
        {
            return this.listaOfertas;
        }

        /// <summary>
        /// Actualiza la informacion de las publicaciones.
        /// </summary>
        public void UpdateOfersData()
        {
            this.UpdateEmpresasData();
            this.LoadPublications();
        }

        /// <summary>
        /// Otorga una lista con todos los UserEmpresa registrados en la aplicacion.
        /// </summary>
        /// <returns>Lista con UserEmpresa</returns>
        public List<UserEmpresa> ListaUsuarioEmpresa() //(Singleton)
        {
            return this.listaUsuarioEmpresa;
        }

        /// <summary>
        /// Otorga una lista con todos los UserEmprendedor registrados.
        /// </summary>
        /// <returns>Lista con UserEmprendedor</returns>
        public List<UserEmprendedor> ListaUsuarioEmprendedor() //(Singleton)
        {
            return this.listaUsuarioEmprendedor;
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
        /// Elimina una oferta de la lista de ofertas.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarOfertas(string id) //(Expert)
        {
            foreach (Oferta oferta in this.listaOfertas)
            {
                if (oferta.Id == id)
                {
                    this.listaOfertas.Remove(oferta);
                }
            }
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

        /// <summary>
        /// Carga los datos de la lista de Tokens desde el archivo ".json".
        /// </summary>
        public void LoadTokensData()
        {
            if (!File.Exists(@"tokens.json"))
            {
                string json = JsonSerializer.Serialize(this.listaTokens);
                File.WriteAllText(@"tokens.json", json);
            }
            else
            {
                string json = File.ReadAllText(@"tokens.json");
                this.listaTokens = JsonSerializer.Deserialize<List<string>>(json);
            }
            Console.WriteLine($"[DATOS] : {this.listaTokens.Count} Tokens cargados.");
        }

        /// <summary>
        /// Actualiza los datos almacenados en la listaTokens
        /// </summary>
        public void UpdateTokensData()
        {
            string json = JsonSerializer.Serialize(this.listaTokens);
            File.WriteAllText(@"tokens.json", json);
        }

        /// <summary>
        /// Carga los datos de una empresa en base al archivo ".json"
        /// </summary>
        public void LoadRegisteredEmpresas()
        {
            if (!File.Exists(@"empresas.json"))
            {
                string json = JsonSerializer.Serialize(this.listaUsuarioEmpresa);
                File.WriteAllText(@"empresas.json", json);
            }
            else
            {
                string json = File.ReadAllText(@"empresas.json");
                this.listaUsuarioEmpresa = JsonSerializer.Deserialize<List<UserEmpresa>>(json);
            }
            Console.WriteLine($"[DATOS] : {this.listaUsuarioEmpresa.Count} Empresas cargadas.");
        }

        /// <summary>
        /// Actualiza los datos que se encuentran almacenados en el ".json", para que sean iguales a los datos almacenados en la lista.
        /// </summary>    
        public void UpdateEmpresasData()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this.listaUsuarioEmpresa, options);
            File.WriteAllText(@"empresas.json", json);
        }

        /// <summary>
        /// Carga los datos de los Emprendedores en base a un archivo ".json".
        /// </summary>
        public void LoadRegisteredEmprendedores()
        {
            if (!File.Exists(@"emprendedores.json"))
            {
                string json = JsonSerializer.Serialize(this.listaUsuarioEmprendedor);
                File.WriteAllText(@"emprendedores.json", json);
            }
            else
            {
                string json = File.ReadAllText(@"emprendedores.json");
                this.listaUsuarioEmprendedor = JsonSerializer.Deserialize<List<UserEmprendedor>>(json);
            }
            Console.WriteLine($"[DATOS] : {this.listaUsuarioEmprendedor.Count} Emprendedores cargados.");
        }

        /// <summary>
        /// Actualiza los datos que se encuentran almacenados en el ".json", para que sean iguales a los datos almacenados en la lista.
        /// </summary>
        public void UpdateEmprendedoresData()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this.listaUsuarioEmprendedor, options);
            File.WriteAllText(@"emprendedores.json", json);
        }

        /// <summary>
        /// Carga las publicaciones en base a los datos de las publicaciones almacenadas en todos los Usuarios Empresa.
        /// </summary>
        public void LoadPublications()
        {
            int cont = 0;

            foreach (UserEmpresa user in this.listaUsuarioEmpresa)
            {
                foreach (Oferta oferta in user.Empresa.Ofertas)
                {
                    if (oferta.Comprador == null)
                    {
                        this.listaOfertas.Add(oferta);
                        cont+=1;
                    }
                }
            }
            Console.WriteLine($"[DATOS] : {cont} Publicaciones cargadas.");
        }

        /// <summary>
        /// Actualiza los datos de las publicaciones encontradas en su respectivo ".json" para que sean idénticas a las que se encontraban en la lista de publicaciones.
        /// </summary>
        public void UpdatePublicationsData()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this.listaOfertas, options);
            File.WriteAllText(@"publicaciones.json", json);
        }
    }
}