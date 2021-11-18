using System;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase tiene como función crear a los usuarios.
    /// Se aplica el patron Creator y SRP ya que es la experta en crear las instancia de los usuarios.
    /// </summary>
    public sealed class  UserCreator
    {   

        private Dictionary<string, List<string>> userData = new Dictionary<string, List<string>>();

        /// <summary>
        /// Agrega datos a la lista que contiene el id del usuario en el diccionario.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        public void AddDataById(string id, string data)
        {
            if (this.userData.ContainsKey(id))
            {
                List<string> value;
                if(this.userData.TryGetValue(id, out value))
                {
                    value.Add(data);
                    Console.WriteLine($"{data} ADDED.");
                }
            }
            else
            {
                this.userData.Add(id, new List<string>() {data});
                Console.WriteLine($"{data} ADDED. Key created.");
            }
        }

        /// <summary>
        /// Elimina completamente el item del diccionario.
        /// </summary>
        /// <param name="id"></param>
        public void WipeDataById(string id)
        {
            this.userData.Remove(id);
            /*
            foreach (KeyValuePair<string, List<string>> item in this.userData)
            {
                if (item.Key == id)
                {
                    item.;
                } 
            }*/
        }

        /// <summary>
        /// Crea una instancia de UserAdmin y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserAdmin(string id)
        {
            foreach (KeyValuePair<string, List<string>> item in this.userData)
            {
                if (item.Key == id)
                {
                    UserAdmin userAdmin = new UserAdmin(id, item.Value[0]);
                    Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userAdmin);
                    Console.WriteLine("UserCreator: Admin creado.");
                }
            }
        }

        /// <summary>
        /// Crea una instancia de UserEmpresa y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserEmpresa(string id)
        {
            foreach (KeyValuePair<string, List<string>> item in this.userData)
            {
                if (item.Key == id)
                {
                    UserEmpresa userEmpresa = new UserEmpresa(id, item.Value[0]);
                    Empresa empresa = new Empresa(item.Value[0], item.Value[2], new Rubro(item.Value[1]));
                    userEmpresa.Empresa = empresa;
                    Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmpresa);
                    Console.WriteLine("UserCreator: Empresa creada.");
                }
            }
        }

        /// <summary>
        /// Crea una instancia de UserEmprendedor y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserEmprendedor(string id)
        {
            foreach (KeyValuePair<string, List<string>> item in this.userData)
            {
                if (item.Key == id)
                {
                    UserEmprendedor userEmprendedor = new UserEmprendedor(id, item.Value[0]);
                    Emprendedor emprendedor = new Emprendedor(item.Value[1], new Rubro(item.Value[2]), new Habilitaciones(item.Value[3]));
                    userEmprendedor.Emprendedor = emprendedor;
                    Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmprendedor);
                    Console.WriteLine("UserCreator: Emprendedor creado.");
                }
            }
        }
    }
}