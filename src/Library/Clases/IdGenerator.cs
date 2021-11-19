using System;
using System.Linq;

namespace Proyecto_Final
{

    /// <summary>
    /// Clase que ofrece el servicio de generar IDs o Tokens unicos.
    /// Aplicando SRP, es la unica capaz de realizar esta funcion. El resto de clases deberan solicitar el servicio. 
    /// </summary>
    public class IdGenerator
    {

        /// <summary>
        /// Genera un token.
        /// </summary>
        /// <returns>Devuelve un token.</returns>
        public static string GenerateToken()
        {
            return generator(10, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789&%$#@!");
        }

        /// <summary>
        /// Genera una ID numerica.
        /// </summary>
        /// <returns>Devuelve una ID numerica.</returns>
        public static string GenerateNumericId()
        {
            return generator(10, "0123456789");
        }

        private static string generator(int length, string charString)
        {
            string allChar = charString;  
            Random random = new Random();  
            string resultToken = new string(  
            Enumerable.Repeat(allChar , length)  
                        .Select(token => token[random.Next(token.Length)]).ToArray());   
   
            string authToken = resultToken.ToString();  
            return authToken;
        }
    }
}