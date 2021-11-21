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
        /// <summary>
        /// Crea una instancia de UserAdmin y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserAdmin(string id)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> item in Singleton<Temp>.Instance.TempData)
            {
                if (item.Key == id)
                {
                    Dictionary<string, string> data = item.Value;

                    UserAdmin userAdmin = new UserAdmin(id, data["nombreAdmin"]);
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
            UserEmpresa userEmpresa = new UserEmpresa(id, Singleton<Temp>.Instance.GetDataByKey(id, "nombreEmpresa"));

            Empresa empresa = new Empresa(
                Singleton<Temp>.Instance.GetDataByKey(id, "nombreEmpresa"),
                Singleton<Temp>.Instance.GetDataByKey(id, "ubicacionEmpresa"),
                new Rubro(Singleton<Temp>.Instance.GetDataByKey(id, "rubroEmpresa"))
            );

            userEmpresa.Empresa = empresa;
            Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmpresa);
            Console.WriteLine($"UserCreator: Empresa {id} creada.");
        }

        /// <summary>
        /// Crea una instancia de UserEmprendedor y la almacena.
        /// </summary>
        /// <param name="id"></param>
        public void CrearUserEmprendedor(string id)
        {
            UserEmprendedor userEmprendedor = new UserEmprendedor(id, Singleton<Temp>.Instance.GetDataByKey(id, "nombreEmprendedor"));
            Emprendedor emprendedor = new Emprendedor(
                Singleton<Temp>.Instance.GetDataByKey(id, "ubicacionEmprendedor"), 
                new Rubro(Singleton<Temp>.Instance.GetDataByKey(id, "rubroEmprendedor")),
                new Habilitaciones(Singleton<Temp>.Instance.GetDataByKey(id, "habilitacionEmprendedor"))
            );
            userEmprendedor.Emprendedor = emprendedor;
            Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmprendedor);
            Console.WriteLine($"UserCreator: Emprendedor {id} creado.");
        }
    }
}