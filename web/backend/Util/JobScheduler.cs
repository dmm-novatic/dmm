using A2F.Util;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F
{
    public class JobScheduler
    {
        public static async void Start()

        {

            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            IJobDetail job1 = JobBuilder.Create<AutoCreateNewsJob>().Build();
            ITrigger trigger1 = TriggerBuilder.Create()
               .WithIdentity("trigger1", "group1")
               .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(23, 30))
               .StartAt(DateTime.UtcNow)
               .WithPriority(1)
               .Build();

            await scheduler.Start();
            await scheduler.ScheduleJob(job1, trigger1);
        }
    }
}
