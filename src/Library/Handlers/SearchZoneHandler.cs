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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/buscar_zona".
    /// </summary>

    public class SearchZoneHandler: BaseHandler
    {
        private string[] allowedStatus;
        
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchZoneHandler"/>. Esta clase procesa el mensaje "/buscar_zona".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public SearchZoneHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"/buscar_zona"};
            this.AllowedStatus = new string [] {"STATUS_ZONE_RESPONSE",
                                                "STATUS_ZONE_RECEIVED"};
        }

        /// <summary>
        /// Procesa el mensaje "/buscar_zona" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>

        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            UserEmprendedor usercheck = (UserEmprendedor) Singleton<Datos>.Instance.GetUserById(message.UserId);
            if (Singleton<Datos>.Instance.ListaUsuarioEmprendedor().Contains(usercheck))
            {
                if  (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
                {
                    if (check == "STATUS_IDLE")
                    {
                        response = "¿Quiere realizar una búsqueda de ofertas por zona? Y/N";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_ZONE_RESPONSE");
                        return true;
                    }

                    else if (check == "STATUS_ZONE_RESPONSE")
                    {
                        if(message.Text.ToUpper() == "Y")
                        {
                            UserEmprendedor user = (UserEmprendedor) Singleton<Datos>.Instance.GetUserById(message.UserId);
                            response = user.VerOfertasUbicacion();
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_ZONE_RECEIVED");
                            return true;
                        }
                    }
                    else
                    {
                        response = "Usted ha cancelado la busqueda por zona";
                        
                        check = "STATUS_IDLE";
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