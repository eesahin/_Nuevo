using Microsoft.Extensions.DependencyInjection;
using NCrontab;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using _Nuevo.Business.Interfaces;
using _Nuevo.WebUI.BackgroundService;
using _Nuevo.WebUI.Services;

namespace _Nuevo.WebUI.Scheduler
{
    public abstract class ScheduledProcessor : ScopedProcessor
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private readonly ITargetService _targetService;
        private readonly IStatuService _statuService;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IEmailSender _emailSender;
        protected abstract string Schedule { get; }
        public ScheduledProcessor(IServiceScopeFactory serviceScopeFactory, ITargetService targetService, IStatuService statuService
            , IHttpClientFactory clientFactory, IEmailSender emailSender) : base(serviceScopeFactory, targetService, statuService, clientFactory, emailSender)
        {
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                await Process();
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}
