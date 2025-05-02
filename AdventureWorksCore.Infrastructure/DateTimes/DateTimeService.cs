using AdventureWorksCore.Application.Common.Interfaces;

namespace AdventureWorksCore.Infrastructure.DateTimes;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}