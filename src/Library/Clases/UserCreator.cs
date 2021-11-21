using System;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase tiene como función crear a los usuarios.
    /// Se aplica el patron Creator y SRP ya que es la responsable en crear las instancia de los usuarios.
    /// </summary>
    public sealed class  UserCreator
    {   

        private Dictionary<string, Dictionary<string, string>> userData = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// Agrega datos a la lista que contiene el id del usuario en el diccionario.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void AddDataById(string id, string key, string data)
        {
            if (this.userData.ContainsKey(id))
            {
                Dictionary<string, string> value;
                if(this.userData.TryGetValue(id, out value))
                {
                    if (value.ContainsKey(key))
                    {
                        value[key] = data;
                    }
                    else
                    {
                        value.Add(key, data);
                    }
                }
            }
            else
            {
                Dictionary<string, string> auxDict = new Dictionary<string, string>();
                auxDict.Add(key, data);
                this.userData.Add(id, auxDict);
            }
        }

        /// <summary>
        /// Elimina completamente el item del diccionario.
        /// </summary>
        /// <param name="id"></param>
        public void WipeDataById(string id)
        {
            this.userData.Remove(id);
        }

        /// <summary>
        /// Crea una instancia de UserAdmin y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserAdmin(string id)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> item in this.userData)
            {
                if (item.Key == id)
                {
                    Dictionary<string, string> data = item.Value;

                    UserAdmin userAdmin = new UserAdmin(id, data["nombre"]);
                    Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userAdmin);
                    Console.WriteLine($"UserCreator: Admin {id} creado.");
                }
            }
        }

        /// <summary>
        /// Crea una instancia de UserEmpresa y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserEmpresa(string id)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> item in this.userData)
            {
                if (item.Key == id)
                {
                    Dictionary<string, string> data = item.Value;

                    UserEmpresa userEmpresa = new UserEmpresa(id, data["nombre"]);
                    Empresa empresa = new Empresa(data["nombre"], data["ubicacion"], new Rubro(data["rubro"]));
                    userEmpresa.Empresa = empresa;
                    Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmpresa);
                    Console.WriteLine($"UserCreator: Empresa {id} creada.");
                }
            }
        }

        /// <summary>
        /// Crea una instancia de UserEmprendedor y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserEmprendedor(string id)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> item in this.userData)
            {
                if (item.Key == id)
                {
                    Dictionary<string, string> data = item.Value;

                    UserEmprendedor userEmprendedor = new UserEmprendedor(id, data["nombre"]);
                    Emprendedor emprendedor = new Emprendedor(data["ubicacion"], new Rubro(data["rubro"]), new Habilitaciones(data["habilitacion"]));
                    userEmprendedor.Emprendedor = emprendedor;
                    Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmprendedor);
                    Console.WriteLine($"UserCreator: Emprendedor {id} creado.");
                }
            }
        }
    }
}