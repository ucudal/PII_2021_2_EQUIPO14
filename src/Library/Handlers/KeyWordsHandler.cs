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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "keywords".
    /// </summary>

    public class KeyWordsHandler: BaseHandler
    {
        private string[] allowedStatus;
        public string[] AllowedStatus { get; set;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="KeyWordsHandler"/>. Esta clase procesa el mensaje "palabraClave".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>

        public KeyWordsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string [] {"palabraClave"};
            
        }










    }













}