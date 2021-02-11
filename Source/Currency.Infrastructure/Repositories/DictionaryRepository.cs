using Microsoft.EntityFrameworkCore;
using Ondato.DB;
using Ondato.DB.Models;
using Ondato.Helpers.Connections;
using Ondato.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Ondato.Infrastructure.Repositories
{
    public class DictionaryRepository : BaseRepository, IDictionaryRepository
    {

        public DictionaryRepository(IDatabaseConnectionFactory connectionFactory, OndatoContext context) : base(connectionFactory: connectionFactory, context: context)
        {
        }


        public async Task Create(string key)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (Context.DictionaryKeys.Any(dk => dk.Key == key))
                    await Delete(key)
                        .ConfigureAwait(false);

                await Context.DictionaryKeys.AddAsync(new DictionaryKey { Key = key })
                    .ConfigureAwait(false);
                await Context.SaveChangesAsync()
                    .ConfigureAwait(false);
                scope.Complete();
            }

        }

        public async Task Append(string key, byte[] value)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                var valueObj = new DictionaryValue { Key = key, Value = value };

                var dictionaryKey = await Context.DictionaryKeys.SingleOrDefaultAsync(dk => dk.Key == key).ConfigureAwait(false);

                if (dictionaryKey == null)
                {
                    await Context.DictionaryKeys.AddAsync(new DictionaryKey { Key = key, DictionaryValues = new List<DictionaryValue>() { valueObj } })
                        .ConfigureAwait(false);
                    await Context.SaveChangesAsync();
                    scope.Complete();
                    return;
                }
                await Context.DictionaryValues.AddAsync(valueObj)
                    .ConfigureAwait(false);
                dictionaryKey.UpdatedDate = DateTime.Now;
                await Context.SaveChangesAsync()
                    .ConfigureAwait(false);
                scope.Complete();
            }
        }

        public async Task Delete(string key)
        {
            await Context.DictionaryKeys.DeleteByKeyAsync(key)
                .ConfigureAwait(false);
            await Context.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<byte[]>> Get(string key)
        {
            var dictionaryValue = await Context.DictionaryKeys.SingleOrDefaultAsync(dk=>dk.Key == key)
                .ConfigureAwait(false);
            if (dictionaryValue != null) {
                dictionaryValue.UpdatedDate = DateTime.Now;
                await Context.SaveChangesAsync()
                    .ConfigureAwait(false);

                return await Context.DictionaryValues.AsNoTracking().Where(dv => dv.Key == key).Select(dv => dv.Value).ToListAsync()
                    .ConfigureAwait(false);
            }
            return null;
            
        }

        public async Task Delete(DateTime dateTo)
        {
            var trash = Context.DictionaryKeys.AsNoTracking().Where(dk => dk.UpdatedDate > dateTo).Select(dk => dk.Key).ToList();
            if (trash.Count > 0)
            {
                await Context.DictionaryKeys.DeleteRangeByKeyAsync(trash)
                       .ConfigureAwait(false);
                await Context.SaveChangesAsync()
                    .ConfigureAwait(false);
            }

        }
    }
}
