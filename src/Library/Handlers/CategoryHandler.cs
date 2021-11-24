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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/buscar_categoria".
    /// </summary>

    public class CategoryHandler: BaseHandler
    {
        private string[] allowedStatus;
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CategoryHandler"/>. Esta clase procesa el mensaje "/buscar_categoria".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public CategoryHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"/buscar_categoria"};
            this.AllowedStatus = new string [] {"STATUS_CATEGORY_RESPONSE",
                                                "STATUS_CATEGORY_RECIVED"};
        }

        /// <summary>
        /// Procesa el mensaje "/buscar_categoria" y retorna true; retorna false en caso contrario.
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
                        response = "¿Quieres filtrar los materiales por categoria?";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_CATEGORY_RESPONSE");
                        return true;
                    }

                    else if (check == "STATUS_CATEGORY_RESPONSE")
                    {
                        if(message.Text.ToUpper() == "Y")
                        {
                            response = "Ingrese la categoria: ";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_CATRGORY_RECIVED");
                            return true;
                        }
                    }

                    else if (check == "STATUS_CATEGORY_RECIVED")
                    {
                        
                    }
                    else
                    {
                        response = "Usted no ingreso una categoria";
                        
                        check = "STATUS_IDLE";
                        return true;
                    }
                    
                }
                response = string.Empty;
                return false;
            }
            else
            {
                response = "Usted no tiene los permisos necesarios para realizar esta acción";
                return false;
            }
        }










    }













}