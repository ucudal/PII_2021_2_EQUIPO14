using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Proyecto_Final
{
    public class TelegramBot
    {

        private const string TELEBRAM_BOT_TOKEN = "2004584466:AAEgtrmxu4kgJwBAomfmRPuovsGTI9pAwAg";
        private static TelegramBot instance;
        private TelegramBotClient bot;

        private TelegramBot()
        {
            this.bot = new TelegramBotClient(TELEBRAM_BOT_TOKEN);
        }

        public TelegramBotClient Client
        {
            get
            {
                return this.bot;
            }
        }

        private User BotInfo
        {
            get
            {
                return this.Client.GetMeAsync().Result;
            }
        }

        public int BotId
        {
            get
            {
                return this.BotInfo.Id;
            }
        }

        public string BotName
        {
            get
            {
                return this.BotInfo.FirstName;
            }
        }

        public static TelegramBot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TelegramBot();
                }
                return instance;
            }
        }
    }
}
