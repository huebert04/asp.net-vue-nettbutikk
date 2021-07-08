using System;

namespace API.Common
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now() => DateTime.Now;
    }
}