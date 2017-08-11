using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEMP1.Models.PoolAntiSleep
{
    public class keepAliveScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //scheduler.Start();

            var keepAliveJob = JobBuilder.Create<KeepAliveJob>().Build();
            var keepAliveTrigger = TriggerBuilder.Create()
                            .WithSimpleSchedule(x => x.WithIntervalInMinutes(19).RepeatForever())
                            .Build();

            scheduler.ScheduleJob(keepAliveJob, keepAliveTrigger);
            scheduler.Start();
        }
    }
}