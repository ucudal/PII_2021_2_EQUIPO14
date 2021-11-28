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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/materiales_consumidos".
    /// </summary>

    public class MaterialsConsumedHandler: BaseHandler
    {
        private string[] allowedStatus;
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MaterialsConsumedHandler"/>. Esta clase procesa el mensaje "/materiales_consumidos".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public MaterialsConsumedHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"/materiales_consumidos"};
            this.AllowedStatus = new string [] {"STATUS_MATERIALSCONSUMED_RESPONSE",
                                                "STATUS_MATERIALSCONSUMED_RECIVED"};
        }

        /// <summary>
        /// Procesa el mensaje "/materiales_consumidos" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>

        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if  (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (Singleton<Datos>.Instance.IsUserEmprendedor(message.UserId))
                {
                    if (check == "STATUS_IDLE")
                    {
                        response = "¿Quieres observar los materiales o residuos consumidos en un periodo de tiempo? Y/N";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_MATERIALSCONSUMED_RESPONSE");
                        return true;
                    }

                    else if (check == "STATUS_MATERIALSCONSUMED_RESPONSE")
                    {
                        if(message.Text.ToUpper() == "Y")
                        {
                            response = "Ingrese el periodo de tiempo: ";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_MATERIALSCONSUMED_RECIVED");
                            return true;
                        }
                        else
                        {
                            response = "Usted no ingreso un periodo de tiempo, busqueda anulada";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                            return true;

                        }
                    }

                    else if (check == "STATUS_MATERIALSCONSUMED_RECIVED")
                    {
                    //Metodo para ver los materiales consumidos en un periodo de tiempo

                    }
                }
                else
                {
                    response = "Usted no tiene los permisos necesarios para realizar esta acción";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}