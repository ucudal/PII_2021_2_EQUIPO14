using System.Linq;
using System;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/agregar_palabra".
    /// </summary>
    public class AddKeyWordHandler : BaseHandler
    {
        private string[] allowedStatus;
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>

        public string[] AllowedStatus { get; set;}
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddKeyWordHandler"/>. Esta clase procesa el mensaje "/agregar_palabra".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AddKeyWordHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/agregar_palabra"};
            this.AllowedStatus = new string[] {"STATUS_KEYWORD_RESPONSE",
                                               "STATUS_KEYWORD_OFERTNAME",
                                               "STATUS_KEYWORD_KEYWORD",
                                               };  
        }
    
        /// <summary>
        /// Procesa el mensaje "/agregar_palabra" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if (Singleton<Datos>.Instance.IsUserEmpresa(message.UserId))
            {
                if (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
                {
                    if (check == "STATUS_IDLE")
                    {   
                        response = "¿Desea agregarle una palabra clave a una oferta? Y/N";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_KEYWORD_RESPONSE");
                        return true;
                    }
                    else if (check == "STATUS_KEYWORD_RESPONSE")
                    {
                        if (message.Text.ToUpper() == "Y")
                        {
                            response = "Ingrese el ID de la oferta a asignarle una palabra clave";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_KEYWORD_OFERTNAME");
                            return true;
                        }
                        else
                        {
                            response = "Se ha cancelado la asignación de una palabra clave";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                            return true;
                        }
                    }
                    else if (check == "STATUS_KEYWORD_OFERTNAME")
                    {
                        if (Singleton<Datos>.Instance.IsOfferValid(message.UserId, message.Text))
                        {
                            response = $"El ID de la oferta es: {message.Text}.\n\nIngrese la palabra clave a asignarle: ";
                            Singleton<Temp>.Instance.AddDataById(message.UserId, "oferIdKeyword", message.Text);
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_KEYWORD_KEYWORD");
                            return true;
                        }
                        response = $"ID de oferta invalido. Se ha cancelado la asignacion de palabra clave.";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                    else if (check == "STATUS_KEYWORD_KEYWORD")
                    {
                        response = $"La palabra clave es: {message.Text}.\n\nPalabra clave asignada correctamente!! ";
                        UserEmpresa user = (UserEmpresa) Singleton<Datos>.Instance.GetUserById(message.UserId);
                        user.CrearMsjClave(Singleton<Temp>.Instance.GetDataByKey(message.UserId, "oferIdKeyword"), message.Text);
                        Singleton<Datos>.Instance.UpdateEmpresasData();
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                }
            }
            else
            {
                response = "Usted no tiene los permisos necesarios para realizar esta acción";
                Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}
