namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "/chau" y "/adiós".
    /// </summary>
    public class GoodByeHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GoodByeHandler"/>. Esta clase procesa los mensajes "/chau" y "/adiós".
        /// y el mensaje "adiós" -un ejemplo de cómo un "handler" puede procesar comandos con sinónimos.
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public GoodByeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/chau", "/adiós" };
        }

        /// <summary>
        /// Procesa los mensajes "/chau" y "/adiós" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (this.CanHandle(message))
            {
                response = "¡Chau! ¡Qué andes bien!";
                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}