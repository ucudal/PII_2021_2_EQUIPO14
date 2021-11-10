using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Nito.AsyncEx;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "foto".
    /// </summary>
    public class PhotoHandler : BaseHandler
    {
        private TelegramBotClient bot;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PhotoHandler"/>. Esta clase procesa el mensaje "foto".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        /// <param name="bot">El bot para enviar la foto.</param>
        public PhotoHandler(TelegramBotClient bot, BaseHandler next)
            : base(new string[] { "foto" }, next)
        {
            this.bot = bot;
        }

        /// <summary>
        /// Procesa el mensaje "foto" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (this.CanHandle(message))
            {
                // await SendProfileImage(message);
                AsyncContext.Run(() => SendProfileImage(message));

                response = string.Empty;
                return true;
            }

            response = string.Empty;
            return false;
        }

        /// <summary>
        /// Envía una imagen como respuesta al mensaje recibido. Como ejemplo enviamos siempre la misma foto.
        /// </summary>
        private async Task SendProfileImage(IMessage message)
        {
            // Can be null during testing
            if (bot != null)
            {
                await bot.SendChatActionAsync(message.ChatId, ChatAction.UploadPhoto);

                const string filePath = @"D:\GitHub\Equipo14_PII_Proyecto_Final\src\Assets\profile.jpeg";
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                await bot.SendPhotoAsync(
                    chatId: message.ChatId,
                    photo: new InputOnlineFile(fileStream, fileName),
                    caption: "Te ves bien!"
                );
            }
        }
    }
}
