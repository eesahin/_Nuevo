using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _Nuevo.WebUI.BackgroundService
{
    public abstract class BackgroundService : IHostedService
    {
        private Task _executingTask;
        private readonly CancellationTokenSource _stoppingCts =
                                                       new CancellationTokenSource();
        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _executingTask = ExecuteAsync(_stoppingCts.Token);
            if (_executingTask.IsCompleted)
            {
                return _executingTask;
            }
            return Task.CompletedTask;
        }
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask == null)
            {
                return;
            }
            try
            {
                _stoppingCts.Cancel();
            }
            finally
            {
                await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite));
            }
        }
        protected virtual async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await Process();
                await Task.Delay(10000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }
        protected abstract Task Process();
    }
}
