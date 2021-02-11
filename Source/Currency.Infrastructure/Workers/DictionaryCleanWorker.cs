using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ondato.Domain.Dtos;
using Ondato.Domain.IServices;
using Ondato.Domain.IWorkers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ondato.Infrastructure.Workers
{
    public class DictionaryCleanWorker : IDictionaryCleanWorker
    {
        private readonly ILogger<BackgroundWorker> _logger;
        private readonly IServiceProvider _services;
        public DictionaryCleanWorker(ILogger<BackgroundWorker> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }
        public async Task DoWork(CancellationToken cancellationToken)
        {
            int delayTimeS = 10;
            while (!cancellationToken.IsCancellationRequested) {
                try
                {
                    using (var scope = _services.CreateScope())
                    {
                        var dictionaryService =
                            scope.ServiceProvider
                                .GetRequiredService<IDictionaryService>();

                        delayTimeS = scope.ServiceProvider
                                .GetRequiredService<IOptions<AppSettingsDto>>().Value.CleanDictionaryTimerS;

                        await dictionaryService.DeleteExpired().ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Worker exception", ex);
                }

                await Task.Delay(delayTimeS * 1000);
            }
          
        }

    }
}
