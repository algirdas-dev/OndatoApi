using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ondato.Infrastructure.IRepositories
{
    public interface IDictionaryRepository
    {
        Task Create(string key);
        Task Append(string key, byte[] value);
        Task Delete(string key);
        Task Delete(DateTime dateTo);
        Task<List<byte[]>> Get(string key);
    }
}
