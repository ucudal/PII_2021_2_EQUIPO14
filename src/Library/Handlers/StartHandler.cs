using Telegram.Bot.Types;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "start".
    /// </summary>
    public class StartHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "start".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/start"};
        }

        /// <summary>
        /// Procesa el mensaje "start" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message))
            {
                response = $"Hola, ¿cómo estás {message.From.FirstName}? 👋😀\nMe llamo EXIV y soy el Bot de PII del Equipo 14.";
                Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.From.Id, "STATUS_IDLE");
                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}