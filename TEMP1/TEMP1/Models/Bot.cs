using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using Telegram.Bot;

namespace TEMP1.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;

        //public static List<Timer> timers = new List<Timer>();
        public static long Id;

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