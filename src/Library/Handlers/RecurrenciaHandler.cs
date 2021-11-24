using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Nito.AsyncEx;
using Telegram.Bot.Types.ReplyMarkups;
using System.Text;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "invitar".
    /// </summary>
    public class RecurrenciaHandler : BaseHandler
    {
        private string[] allowedStatus;
        
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InviteHandler"/>. Esta clase procesa el mensaje "invitar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RecurrenciaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"recurrencia"};
            this.AllowedStatus = new string[] {"STATUS_RECURRENCIA_RESPONSE", 
                                                "STATUS_PUNTUAL_RESPONSE"};
        }

        /// <summary>
        /// Procesa el mensaje "invitar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (check == "STATUS_IDLE")
                {
                   response = "¿Quieres buscar las ofertas recurrentes? Y/N";
                   return true;
                }
                else if(check == "STATUS_RECURRENCIA_RESPONSE")
                {
                    if(message.Text.ToUpper() == "Y")
                    {
                        StringBuilder str = new StringBuilder();
                        foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
                        {
                            if(oferta.IsRecurrente)
                            {
                                str.Append($"+ {oferta.Id}\n");
                            }
                        }
                        response = "Listas de ofertas recurrentes:\n";
                        response += str;
                        return true;
                    }
                    else
                    {
                        response = "¿Queres buscar las ofertas puntuales? Y/N";
                        return true;
                    }
                }
                else if(check == "STATUS_PUNTUAL_RESPONSE")
                {
                    if(message.Text.ToUpper() == "Y")
                    {
                        StringBuilder str2 = new StringBuilder();
                        foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
                        {
                            if(!oferta.IsRecurrente)
                            {
                                str2.Append($"+ {oferta.Id}\n");
                            }
                        }
                        response = "Listas de ofertas puntuales:\n";
                        response += str2;
                        return true;
                    }
                    else
                    {
                        response = "Busqueda cancelada";
                        return true;
                    }
                }
            }
            response = string.Empty;
            return false;
        }
    }

}