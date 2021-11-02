using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa a los administradores del programa.
    /// </summary>
    public class UserAdmin
    {
        /// <summary>
        /// Otorga el nombre de usuario del administrador.
        /// </summary>
        /// <value>Nombre de usuario del administrador</value>
        
        public string Nombre { get; }

        /// <summary>
        /// Inicializa la clase UserAdmin.
        /// </summary>
        /// <param name="nombre"></param>
        public UserAdmin(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// Invita a una empresa desde cualquier IUserInterface siempre y cuando esta empresa no haya sido invitada.
        /// </summary>
        /// <param name="userEmpresa"></param>
        /// <param name="userInterface"></param>
        public void InvitarEmpresa(string nombreUserEmpresa)
        {
            foreach (UserEmpresa user in Singleton<Datos>.Instance.ListaUsuarioEmpresa())
            {
                if (user.Nombre == nombreUserEmpresa)
                {
                    user.Invitacion = new Invitacion();
                }
            }
        }
    }
}