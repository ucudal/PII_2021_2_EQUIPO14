using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase tiene como función crear a los usuarios.
    /// Se aplica el patron Creator y SRP ya que es la experta en crear las instancia de los usuarios.
    /// </summary>
    public sealed class  UserCreator
    {   
        /// <summary>
        /// Crea una instancia de UserAdmin y la almacena.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public void CrearUserAdmin(string id, string nombre)
        {
            UserAdmin userAdmin = new UserAdmin(id, nombre);
            Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userAdmin);
            Console.WriteLine("UserCreator: Admin creado.");
        }

        /// <summary>
        /// Crea una instancia de UserEmpresa y la almacena.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public void CrearUserEmpresa(string id, string nombre)
        {
            UserEmpresa userEmpresa = new UserEmpresa(id, nombre);
            Empresa empresa = new Empresa(nombre, "", new Rubro(""));
            userEmpresa.Empresa = empresa;
            Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmpresa);
            Console.WriteLine("UserCreator: Empresa creada.");
        }

        /// <summary>
        /// Crea una instancia de UserEmprendedor y la almacena.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public void CrearUserEmprendedor(string id, string nombre)
        {
            UserEmprendedor userEmprendedor = new UserEmprendedor(id, nombre);
            Emprendedor emprendedor = new Emprendedor("", new Rubro(""), new Habilitaciones(""));
            userEmprendedor.Emprendedor = emprendedor;
            Singleton<Datos>.Instance.ListaUsuariosRegistrados().Add(userEmprendedor);
            Console.WriteLine("UserCreator: Emprendedor creado.");
        }

    }
}