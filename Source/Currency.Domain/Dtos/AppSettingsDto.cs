using Ondato.Domain.IDtos;

namespace Ondato.Domain.Dtos
{
    public class AppSettingsDto : IAppSettingsDto
    {
        public virtual ExpirationPeriodDto ExpirationPeriod { get; set; }
        public int CleanDictionaryTimerS { get; set; }

        public class ExpirationPeriodDto {
            public int Days { get; set; }
            public int Hours { get; set; }
            public int Minutes { get; set; }
            public int Seconds { get; set; }
        }
    }
}
