using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "salir".
    /// </summary>
    public class ExitHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ExitHandler"/>. Esta clase procesa el mensaje "salir".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ExitHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"salir"};
        }

        /// <summary>
        /// Procesa el mensaje "salir" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {

            if (this.CanHandle(message))
            {
                string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
                if (check != "STATUS_IDLE")
                {
                    response = "Proceso terminado.";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    return true;
                }
                response = string.Empty;
                return false;
            }
            response = string.Empty;
            return false;
        }
    }

}