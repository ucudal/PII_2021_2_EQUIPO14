using System;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa a los administradores del programa.
    /// </summary>
    public class UserAdmin : IUser
    {

        /// <summary>
        /// Otorga el id del administrador.
        /// </summary>
        /// <value></value>
        public string Id { get; set; }

        /// <summary>
        /// Otorga el nombre de usuario del administrador.
        /// </summary>
        /// <value>Nombre de usuario del administrador</value>
        public string Nombre { get; }

        /// <summary>
        /// Inicializa la clase UserAdmin.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public UserAdmin(string id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Genera un token de invitacion para ser enviado y lo almacena para su verificacion.
        /// </summary>
        /// <returns>Devuelve un token generado como string</returns>
        public static string InvitarEmpresa()
        {
            return UserAdmin.generateToken();
        }

        private static string generateToken()
        {
            string allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";  
            Random random = new Random();  
            string resultToken = new string(  
            Enumerable.Repeat(allChar , 16)  
                        .Select(token => token[random.Next(token.Length)]).ToArray());   
   
            string authToken = resultToken.ToString();  
            return authToken;
        }
    }
}