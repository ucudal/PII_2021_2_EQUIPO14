using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Nito.AsyncEx;
using Telegram.Bot.Types.ReplyMarkups;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "registro".
    /// </summary>
    public class RegisterHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterHandler"/>. Esta clase procesa el mensaje "registro".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"registro"};
        }

        /// <summary>
        /// Procesa el mensaje "registro" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message))
            {

                response = "¿Deseas registrarte como Emprendedor?";
                return true;

            }

            response = string.Empty;
            return false;
        }
    }
}






