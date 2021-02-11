using Ondato.DB;
using Ondato.Helpers.Connections;

namespace Ondato.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IDatabaseConnectionFactory ConnectionFactory;
        protected readonly OndatoContext Context;
        public BaseRepository(IDatabaseConnectionFactory connectionFactory = null, OndatoContext context = null) {
            ConnectionFactory = connectionFactory;
            Context = context;
        }
    }
}
