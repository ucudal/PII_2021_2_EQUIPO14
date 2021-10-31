using System;

namespace Proyecto_Final
{
    public class UserAdmin
    {
        public string Nombre { get; }

        public UserAdmin(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// Invita a una empresa desde cualquier IUserInterface siempre y cuando esta empresa no haya sido invitada.
        /// </summary>
        /// <param name="userEmpresa"></param>
        /// <param name="userInterface"></param>
        public void InvitarEmpresa(UserEmpresa userEmpresa, IUserInterface userInterface)
        {
            // Si la empresa no fue invitada, la invita.
            if (!userEmpresa.IsInvited)
            {
                bool isAccepted = userInterface.AceptarInvitacion();
                userEmpresa.AceptarInvitacion(isAccepted, userInterface);
            }
            else 
            {
                userInterface.AlreadyInvitedMsg();
            }
        }
    }
}