using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TEMP1.Models;

namespace TEMP1.Controllers
{
    public class MessageController : ApiController
    {
        [Route("api/message/update")] // webhook uri api
        public async Task<IHttpActionResult> Update([FromBody]Update update)
        {
            var client = await Bot.Get();
            var message = update.Message;

            if (update.Message.Type == MessageType.TextMessage)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "HI");
                await client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }

            switch (update.Type)
            {
                case UpdateType.UnkownUpdate:
                    await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                    break;
                case UpdateType.MessageUpdate:
                    await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                    break;
                case UpdateType.InlineQueryUpdate:
                    await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                    break;
                case UpdateType.ChosenInlineResultUpdate:
                    await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                    break;
                case UpdateType.CallbackQueryUpdate:
                    await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                    break;
                case UpdateType.EditedMessage:
                    await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                    break;
                default:
                    await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                    break;
            }
            return Ok();
        }
    }
}
