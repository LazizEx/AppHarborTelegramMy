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
            if (update.Message.Type == MessageType.TextMessage)
            {
                var message = update.Message;
                var client = await Bot.Get();
                await client.SendTextMessageAsync(message.Chat.Id, "HI");
                await client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
            return Ok();
        }
    }
}
