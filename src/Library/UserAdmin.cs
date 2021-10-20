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
        public void InvitarEmpresa(UserEmpresa userEmpresa)
        {
            userEmpresa.AceptarInvitacion();
        }
    }
}