using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ondato.Domain.IServices;
using Ondato.Domain.IWorkers;
using System.Threading;
using System.Threading.Tasks;

namespace Ondato.Infrastructure.Workers
{
    public class BackgroundWorker : IHostedService
    {
        private readonly IDictionaryCleanWorker _dictionaryCleanerworker;
        private readonly ILogger<BackgroundWorker> _logger;
        public BackgroundWorker(IDictionaryCleanWorker dictionaryCleanerWorker, ILogger<BackgroundWorker> logger) {
            _dictionaryCleanerworker = dictionaryCleanerWorker;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background worker started");
            await _dictionaryCleanerworker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background worker stopping");
            return Task.CompletedTask;
        }
    }
}
