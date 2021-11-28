using System;
using Telegram.Bot.Types;

namespace Proyecto_Final
{

    /// <summary>
    /// Esta es la clase encargada procesar los mensajes.
    /// En este caso la plataforma es telegram, pero modificando este clase podria ser 
    /// utilizada en otras plataformas como whatsapp, etc
    /// </summary>

    public class TelegramAdapter : IMessage
    {
        /// <summary>
        /// Inicializa el texto.
        /// /// </summary>
        /// <value>Text de telegram</value>
        
        private Message message;

        /// <summary>
        /// Otorga el texto.
        /// /// </summary>
        /// <value>Texto de telegram</value>
        public string Text { get { return this.message.Text; } }

        /// <summary>
        /// Otorga el UserId
        /// </summary>
        /// <value>UserId de telegram</value>
        public string UserId { get { return this.message.From.Id.ToString(); } }

        /// <summary>
        /// Otorga el ChatId
        /// </summary>
        /// <value>ChatId de telegram</value>
        public string ChatId { get { return this.message.Chat.Id.ToString(); } }

        /// <summary>
        /// Otorga el nombre del usuario
        /// </summary>
        /// <value>Nombre del usuario de telegram</value>
        public string FirstName { get { return this.message.From.FirstName; } }

        /// <summary>
        /// Otorga el apellido del usuario
        /// </summary>
        /// <value>Apellido del usuario de telegram</value>
        public string LastName { get { return this.message.From.LastName; } }

        /// <summary>
        /// Otorga el tiempo del mensaje
        /// </summary>
        /// <value>Tiempo del mensaje de telegram</value>
        public DateTime Date { get { return this.message.Date; } }

        /// <summary>
        /// Otorga el número de teléfono del usuario que envió el mensaje
        /// </summary>
        /// <value>String del número de teléfono del usuario.</value>
        public string PhoneNumber {get {return this.message.Contact.PhoneNumber;} }

        /// <summary>
        /// Inicializa la clase TelegramAdapter.
        /// </summary>
        /// <param name="message"></param>

        public TelegramAdapter(Message message)
        {
            this.message = message;
        }
    }
}