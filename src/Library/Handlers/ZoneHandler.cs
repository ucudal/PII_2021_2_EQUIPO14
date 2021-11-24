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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "zone".
    /// </summary>

    public class ZoneHandler: BaseHandler
    {
        private string[] allowedStatus;
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="KeyWordsHandler"/>. Esta clase procesa el mensaje "zone".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public ZoneHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"/buscar_zona"};
            this.AllowedStatus = new string [] {"STATUS_ZONE_RESPONSE",
                                                "STATUS_ZONE_RECEIVED"};
        }

        /// <summary>
        /// Procesa el mensaje "zone" y retorna true; retorna false en caso contrario.
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
                    response = "¿Quiere filtrar los materiales por zona? Y/N";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_ZONE_RESPONSE");
                    return true;
                }

                else if (check == "STATUS_ZONE_RESPONSE")
                {
                    if(message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese la zona: ";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_ZONE_RECEIVED");
                        return true;
                    }
                }

                else if (check == "STATUS_ZONE_RECEIVED")
                {
                    //Metodo de filtrar por zona
                }
                else
                {
                    response = "Usted no ingreso una zona";
                    
                    check = "STATUS_IDLE";
                    return true;
                }
                
            }
            response = string.Empty;
            return false;
        }










    }













}