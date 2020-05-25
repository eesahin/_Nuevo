using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using _Nuevo.Business.Interfaces;
using _Nuevo.WebUI.Services;

namespace _Nuevo.WebUI.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {

        public ScheduleTask(IServiceScopeFactory serviceScopeFactory, ITargetService targetService, IStatuService statuService
            , IHttpClientFactory clientFactory,IEmailSender emailSender) : base(serviceScopeFactory, targetService, statuService, clientFactory, emailSender)
        {
        }
        protected override string Schedule => "*/10 * * * *";
        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Processing starts here");
            return Task.CompletedTask;
        }
    }
}
