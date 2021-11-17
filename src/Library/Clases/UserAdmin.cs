using System;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa a los administradores del programa.
    /// </summary>
    public class UserAdmin : IUser
    {
<<<<<<< HEAD
=======

        /// <summary>
        /// Otorga el id del administrador.
        /// </summary>
        /// <value></value>
        public string Id { get; set; }

>>>>>>> 4d41251b17fbacfc164ff1b5a71007d06f0afdd8
        /// <summary>
        /// Otorga el nombre de usuario del administrador.
        /// </summary>
        /// <value>Nombre de usuario del administrador</value>
<<<<<<< HEAD
        
        public string Nombre { get; }
        
=======
        public string Nombre { get; }

>>>>>>> 4d41251b17fbacfc164ff1b5a71007d06f0afdd8
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
        public string InvitarEmpresa()
        {
            return this.generateToken();
        }

        private string generateToken()
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