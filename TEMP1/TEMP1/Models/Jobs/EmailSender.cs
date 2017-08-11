using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TEMP1.Models.Jobs
{
    public class EmailSender : IJob
    {
        public async void Execute(IJobExecutionContext context)
        {
            var client = await Bot.Get();
            await client.SendTextMessageAsync(Bot.Id, DateTime.Now.ToShortTimeString());
            //using (MailMessage message = new MailMessage("admin@yandex.ru", "user@yandex.ru"))
            //{
            //    message.Subject = "Новостная рассылка";
            //    message.Body = "Новости сайта: бла бла бла";
            //    using (SmtpClient client = new SmtpClient
            //    {
            //        EnableSsl = true,
            //        Host = "smtp.yandex.ru",
            //        Port = 25,
            //        Credentials = new NetworkCredential("admin@yandex.ru", "password")
            //    })
            //    {
            //        client.Send(message);
            //    }
            //}
        }
    }
}