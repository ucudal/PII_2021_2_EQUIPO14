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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "authorization".
    /// </summary>

    public class AddAuthorizationHandler: BaseHandler
    {
        private string[] allowedStatus;
        
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddAuthorizationHandler"/>. Esta clase procesa el mensaje "authorization".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>


        public AddAuthorizationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"/agregar_habilitacion"};
            this.AllowedStatus = new string [] {"STATUS_ADD_AUTHORIZATION_RESPONSE",
                                                "STATUS_ADD_AUTHORIZATION_ACCEPTED",
                                
                                                
                                                
                                                };
        }

        /// <summary>
        /// Procesa el mensaje "authorization" y retorna true; retorna false en caso contrario.
        /// </summary>

        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>


        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if  (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (check == "STATUS_IDLE")
                {
                    response = "¿Quieres agregar una habilitacion? Y/N";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_ADD_AUTHORIZATION_RESPONSE");
                    return true;
                }
 

                else if (check == "STATUS_ADD_AUTHORIZATION_RESPONSE")
                {
                    if(message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese la habilitacion: ";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_ADD_AUTHORIZATION_ACCEPTED");
                        return true;
                    }


                    else if (message.Text.ToUpper() == "N")
                    {
                        response = $"Se ha cancelado la accion de agregar una habilitacion.";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }


                    else
                    {
                        response = $"No entendí, por favor, responda \"Y\" para agregar una habilitacion o escriba \"N\" cancelar la accion.";
                        return true;
                    }
                }


                else if (check == "STATUS_ADD_AUTHORIZATION_ACCEPTED")
                {
                    UserEmprendedor user = (UserEmprendedor) Singleton<Datos>.Instance.GetUserById(message.UserId);
                    response = $"La habilitacion: {message.Text}, ha sido agregada con exito a la oferta";
                    user.AgregarHabilitacion(message.Text);
                    Singleton<Datos>.Instance.UpdateEmprendedoresData();
                    return true; 
                } 
            }



            response = string.Empty;
            return false;
        }










    }













}