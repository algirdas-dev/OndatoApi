using Ondato.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ondato.Domain.IServices
{
    public interface IDictionaryService
    {
        Task Create(string key);
        Task Append(string key, object value);
        Task Delete(string key);
        Task<List<object>> Get(string key);
        Task DeleteExpired();


    }
}
