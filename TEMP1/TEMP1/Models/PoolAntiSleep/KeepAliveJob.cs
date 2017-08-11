using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TEMP1.Models.PoolAntiSleep
{
    public class KeepAliveJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadString("http://telegrambot-3.apphb.com");
            }
        }
    }
}