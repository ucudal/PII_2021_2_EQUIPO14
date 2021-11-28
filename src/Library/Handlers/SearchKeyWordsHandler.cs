using System.Linq;
using System;


namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/buscar_palabra".
    /// </summary>

    public class SearchKeyWordsHandler: BaseHandler
    {
        private string[] allowedStatus;

        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchKeyWordsHandler"/>. Esta clase procesa el mensaje "/buscar_palabra".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public SearchKeyWordsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"/buscar_palabra"};
            this.AllowedStatus = new string [] {"STATUS_SEARCH_KEYWORD_RESPONSE",
                                                "STATUS_SEARCH_KEYWORD_ACCEPTED",
                                                };
        }

        /// <summary>
        /// Procesa el mensaje "/buscar_palabra" y retorna true; retorna false en caso contrario.
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
                            response = $"¿Desea buscar ofertas mediante una palabra clave? Y/N";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_SEARCH_KEYWORD_RESPONSE");
                            return true;
                        }
                        else if (check == "STATUS_SEARCH_KEYWORD_RESPONSE")
                        {
                            if (message.Text.ToUpper() == "Y")
                            {
                                response = $"Ingrese la palabra clave para buscar:";
                                Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_SEARCH_KEYWORD_ACCEPTED");
                                return true;
                            }
                            else if (message.Text.ToUpper() == "N")
                            {
                                response = $"Se ha cancelado la busqueda.";
                                Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                                return true;
                            }
                            else
                            {
                                response = $"No entendí, por favor, responda \"Y\" para realizar la búsqueda o escriba \"N\" para cancelar la búsqueda.";
                                return true;
                            }
                        }
                        else if (check == "STATUS_SEARCH_KEYWORD_ACCEPTED")
                        {
                            UserEmprendedor user = (UserEmprendedor) Singleton<Datos>.Instance.GetUserById(message.UserId);
                            response = $"En base a la palabra clave {message.Text}, hemos encontrado las siguientes ofertas para tí:\n\n{user.VerOfertasPalabraClave(message.Text)}";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                            return true; 
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