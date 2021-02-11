
using Ondato.Domain.IServices;
using System.Threading;
using System.Threading.Tasks;

namespace Ondato.Domain.IWorkers
{
    public interface IDictionaryCleanWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
