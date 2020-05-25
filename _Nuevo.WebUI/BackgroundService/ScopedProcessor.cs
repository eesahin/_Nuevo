using _Nuevo.Business.Interfaces;
using _Nuevo.Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using _Nuevo.WebUI.Services;

namespace _Nuevo.WebUI.BackgroundService
{
    public abstract class ScopedProcessor : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ITargetService _targetService;
        private readonly IStatuService _statuService;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IEmailSender _emailSender;
        protected ScopedProcessor(IServiceScopeFactory serviceScopeFactory, ITargetService targetService, IStatuService statuService
            , IHttpClientFactory clientFactory, IEmailSender emailSender) : base()
        {
            _serviceScopeFactory = serviceScopeFactory;
            _targetService = targetService;
            _statuService = statuService;
            _clientFactory = clientFactory;
            _emailSender = emailSender;
        }
        protected override async Task Process()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var data = _targetService.GetListForWork();
            foreach (var item in data)
            {
                try
                {
                    await ResponseCode(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            await ProcessInScope(scope.ServiceProvider);
        }
        public async Task ResponseCode(Target target)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                target.Url);
            var client = _clientFactory.CreateClient();
            var statuLink = _statuService.GetStatuForTargetId(target.Id);
            try
            {
                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    statuLink.Code = ((int)response.StatusCode).ToString();
                }
                else
                {
                    if (statuLink.IsSendAnEmail == false)
                    {
                        _emailSender.Send("emre@maama.me", "Error Link :" + target.Url,
                            "Error Code : " + (int)response.StatusCode + "Info : " + response.StatusCode + "<br/><br/> " + "Target Id :" + target.Id);
                    }
                    statuLink.Code = ((int)response.StatusCode).ToString();
                    statuLink.IsSendAnEmail = true;
                }
                statuLink.IsSendAnEmail = false;
            }
            catch (Exception e)
            {
                if (statuLink.IsSendAnEmail == false)
                {
                    _emailSender.Send("emre@maama.me", "Error Link :" + target.Url, e.Message.ToString() + "<br/><br/> " + "Target Id :" + target.Id);
                    statuLink.IsSendAnEmail = true;
                }
                statuLink.Code = e.Message.ToString();
            }
            statuLink.CheckDateTime = DateTime.Now;
            _statuService.Update(statuLink);
        }
        public abstract Task ProcessInScope(IServiceProvider serviceProvider);
    }
}
