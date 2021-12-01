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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/invitar".
    /// </summary>
    public class InviteHandler : BaseHandler
    {
        private string[] allowedStatus;
        
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InviteHandler"/>. Esta clase procesa el mensaje "/invitar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public InviteHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/invitar"};
            this.AllowedStatus = new string[] {"STATUS_INVITE_SEND"};
        }

        /// <summary>
        /// Procesa el mensaje "/invitar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (check == "STATUS_IDLE")
                {
                    if (Singleton<Datos>.Instance.IsAdmin(message.UserId))
                    {
                        string newToken = UserAdmin.InvitarEmpresa();
                        response = $"Envie este token a la persona que desea invitar como Empresa.\n\nTOKEN:\n{newToken}";
                        Singleton<Datos>.Instance.AgregarToken(newToken);
                        Console.WriteLine($"InviteHandler: TOKEN | {newToken} | generado por < {message.UserId} > ");
                        return true;
                    }
                    else
                    {
                        response = "Usted no es un administrador.";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                }
            }
            response = string.Empty;
            return false;
        }
    }

}