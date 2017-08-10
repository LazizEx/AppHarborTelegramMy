using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;

namespace TEMP1.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;

        //private static List<Command> commandList;
        //public static IReadOnlyList<Command> Commands => commandList.AsReadOnly();

        public static List<string> textList = new List<string>();

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
                return client;

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");

            await client.SetWebhookAsync(hook);
            return client;
        }
    }
}