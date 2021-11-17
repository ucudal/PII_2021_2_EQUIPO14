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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "PeriodOfTime".
    /// </summary>

    public class PeriodOfTimeHandler: BaseHandler
    {
        private string[] allowedStatus;
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CategoryHandler"/>. Esta clase procesa el mensaje "PeriodOfTime".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public PeriodOfTimeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"PeriodOfTime"};
            this.AllowedStatus = new string [] {"STATUS_PERIODTIME_RESPONSE",
                                                "STATUS_PERIODTIME_RECIVED"};
        }

        /// <summary>
        /// Procesa el mensaje "PeriodOfTime" y retorna true; retorna false en caso contrario.
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
                    response = "¿Quieres observar los materiales o residuos entregados en un periodo de tiempo? Y/N" ;
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_PERIODTIME_RESPONSE");
                    return true;
                }

                else if (check == "STATUS_PERIODTIME_RESPONSE")
                {
                    if(message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese el periodo de tiempo: ";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_PERIODTIME_RECIVED");
                        return true;
                    }
                    else
                    {
                        response = "Usted no ingreso un periodo de tiempo, busqueda anulada";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                }

                else if (check == "STATUS_PERIODTIME_RECIVED")
                {
                    //Metodo para filtrar materiales por periodo de tiempo
                }
                
            }
            response = string.Empty;
            return false;
        }


    }


}