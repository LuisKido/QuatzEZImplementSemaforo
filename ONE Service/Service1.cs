using ONE_Service.Servicios;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ONE_Service
{
    public partial class Service1 : ServiceBase
    {

        private static IScheduler sched;

        public Service1()
        {
            InitializeComponent();
        }

        public void StartFromDebugger(string[] args)
        {
            OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            StdSchedulerFactory sf = new StdSchedulerFactory();
            sched = sf.GetScheduler();

            string tiempoEjecucionProcesoExtractFTP = ConfigurationManager.AppSettings["tiempoEjecucionProcesoExtractFTP"].ToString();


            IJobDetail job2 = JobBuilder.Create<ProcesoExtractFTP>()
              .WithIdentity("job2", "group1")
              .Build();

            ICronTrigger trigger2 = (ICronTrigger)TriggerBuilder.Create()
                                                      .WithIdentity("trigger2", "group1")
                                                      .WithCronSchedule(tiempoEjecucionProcesoExtractFTP)
                                                      .Build();

            DateTimeOffset ft2 = sched.ScheduleJob(job2, trigger2);


            sched.Start();
        }

        protected override void OnStop()
        {
            sched.Shutdown(true);
        }
    }
}
