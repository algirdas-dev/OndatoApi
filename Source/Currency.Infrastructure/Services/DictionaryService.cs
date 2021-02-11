using Microsoft.Extensions.Options;
using Ondato.Domain.Dtos;
using Ondato.Domain.IServices;
using Ondato.Infrastructure.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ondato.Helpers.Serializers;
using System;

namespace Ondato.Infrastructure.Services
{
    public class DictionaryService : BaseService, IDictionaryService
    {
        private readonly IDictionaryRepository _repository;
        public DictionaryService(IDictionaryRepository repository, IOptions<AppSettingsDto> settings) : base(settings: settings)
        {
            _repository = repository;
        }

        public async Task Append(string key, object value)
        {
            await _repository.Append(key, value.SerializeToByteArray())
                .ConfigureAwait(false);
        }

        public async Task Create(string key)
        {
            await _repository.Create(key)
                .ConfigureAwait(false);
        }

        public async Task Delete(string key)
        {
            await _repository.Delete(key)
                .ConfigureAwait(false);
        }

        public async Task<List<object>> Get(string key)
        {
            var dictionaryValuesBytes = await _repository.Get(key)
                .ConfigureAwait(false);
            if (dictionaryValuesBytes != null)
            {
                List<object> result = new List<object>();
                foreach (var s in dictionaryValuesBytes)
                {
                    result.Add(s.SerializeToObject());
                }
                return result;
            }

            return null;
        }

        public async Task DeleteExpired()
        {
            var expirationDate = DateTime.Now.AddDays(AppSettings.ExpirationPeriod.Days)
                .AddDays(AppSettings.ExpirationPeriod.Days)
                .AddHours(AppSettings.ExpirationPeriod.Hours)
                .AddMinutes(AppSettings.ExpirationPeriod.Minutes)
                .AddSeconds(AppSettings.ExpirationPeriod.Seconds);

            await _repository.Delete(expirationDate)
                .ConfigureAwait(false);
        }
    }
}
