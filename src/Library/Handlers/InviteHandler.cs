using Telegram.Bot.Types;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "invitar".
    /// </summary>
    public class InviteHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InviteHandler"/>. Esta clase procesa el mensaje "invitar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public InviteHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"invitar"};
        }

        /// <summary>
        /// Procesa el mensaje "invitar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message))
            {
                // TODO: Verificar si es un administrador.
                if (message.From.Id == 2051203726)
                {
                    response = "Ingrese el ID del usuario que quiere invitar como empresa.";
                    return true;
                }
                else
                {
                    response = string.Empty;
                    return false;
                }
   
            }

            response = string.Empty;
            return false;
        }
    }
}