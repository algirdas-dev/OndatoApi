
using Ondato.Domain.Dtos;
using Ondato.Domain.IDtos;
using Microsoft.Extensions.Options;

namespace Ondato.Infrastructure.Services
{
    public abstract class BaseService
    {
        protected readonly AppSettingsDto AppSettings;
        protected BaseService(IOptions<AppSettingsDto> settings = null) {
            AppSettings = settings.Value;
        }
    }
}
