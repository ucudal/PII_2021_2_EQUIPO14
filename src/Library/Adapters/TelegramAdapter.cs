using System;
using Telegram.Bot.Types;

namespace Proyecto_Final
{
    public class TelegramAdapter : IMessage
    {
        private Message message;
        public string Text { get { return this.message.Text; } }
        public string UserId { get { return this.message.From.Id.ToString(); } }
        public string ChatId { get { return this.message.Chat.Id.ToString(); } }
        public string FirstName { get { return this.message.From.FirstName; } }
        public string LastName { get { return this.message.From.LastName; } }
        public DateTime Date { get { return this.message.Date; } }
        public TelegramAdapter(Message message)
        {
            this.message = message;
        }
    }
}