using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Nito.AsyncEx;
using Telegram.Bot.Types.ReplyMarkups;
using System;


namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "keyword".
    /// </summary>

    public class KeyWordsHandler: BaseHandler
    {
        private string[] allowedStatus;
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="KeyWordsHandler"/>. Esta clase procesa el mensaje "keyword".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public KeyWordsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"keyword"};
            this.AllowedStatus = new string [] {"STATUS_KEYWORD_RESPONSE",
                                                "STATUS_KEYWORD_RECIVED"};
        }

        /// <summary>
        /// Procesa el mensaje "keyword" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>

        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if  (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (check == "STATUS_IDLE")
                {
                    response = "¿Tienes una palabra clave? Y/N";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_KEYWORD_RESPONSE");
                    return true;
                }

                else if (check == "STATUS_KEYWORD_RESPONSE")
                {
                    if(message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese su palabra clave: ";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_KEYWORD_RECIVED");
                        return true;
                    }
                }

                else if (check == "STATUS_KEYWORD_RECIVED")
                {
                   //Metodo para filtrar por palabras clave 
                }
                else
                {
                    response = "Usted no ingreso una palabra clave, busqueda anulada";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    return true;
                }
                
            }
            response = string.Empty;
            return false;
        }










    }













}