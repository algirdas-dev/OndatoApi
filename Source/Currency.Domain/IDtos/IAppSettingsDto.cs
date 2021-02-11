using static Ondato.Domain.Dtos.AppSettingsDto;

namespace Ondato.Domain.IDtos
{
    public interface IAppSettingsDto
    {
        ExpirationPeriodDto ExpirationPeriod { get; set; }
        int CleanDictionaryTimerS { get; set; }
    }
}
