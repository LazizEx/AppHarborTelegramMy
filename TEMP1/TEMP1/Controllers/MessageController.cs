using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
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
            try
            {
                if (update.Message.Type == MessageType.TextMessage)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "HI");
                    await client.SendTextMessageAsync(message.Chat.Id, message.Text);
                    if (message.Text == "time")
                    {
                        long id = message.Chat.Id;
                        System.Timers.Timer t = new System.Timers.Timer(5000);
                        t.Elapsed += async (s, e) =>
                        {
                            await client.SendTextMessageAsync(id, DateTime.Now.ToShortTimeString());
                        };
                        t.Start();
                        Bot.timers.Add(new System.Timers.Timer());
                    }
                }

                switch (update.Type)
                {
                    case UpdateType.UnkownUpdate:
                        await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                        break;
                    case UpdateType.MessageUpdate:
                        if (message.Text.StartsWith("/"))
                        {
                            await client.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                            var keyboard = new InlineKeyboardMarkup(new[]
                                         {
                                    new[]
                                    {
                                        new InlineKeyboardButton{ Text="1.1", Url="https://vk.com/" },
                                        new InlineKeyboardButton{ Text="1.2", SwitchInlineQuery = "1.2" },
                                    },
                                    new[]
                                    {
                                        new InlineKeyboardButton{ Text="2.1", CallbackData="he" },
                                        new InlineKeyboardButton{ Text="2.2", SwitchInlineQuery ="2.2" },
                                    }
                                });
                            await Task.Delay(500);
                            await client.SendTextMessageAsync(message.Chat.Id, "Choose", replyMarkup: keyboard);
                        }
                        await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                        break;
                    case UpdateType.InlineQueryUpdate:
                        await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                        break;
                    case UpdateType.ChosenInlineResultUpdate:
                        await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                        break;
                    case UpdateType.CallbackQueryUpdate:
                        await client.EditMessageTextAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId, "test");
                        await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                        break;
                    case UpdateType.EditedMessage:
                        await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                        break;
                    default:
                        await client.SendTextMessageAsync(message.Chat.Id, update.Type.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                await client.SendTextMessageAsync(message.Chat.Id, ex.ToString());
            }

            return Ok();
        }
    }
}
