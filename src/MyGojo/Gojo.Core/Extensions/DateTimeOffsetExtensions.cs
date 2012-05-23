using System;
using System.Linq;
using System.Text;

namespace Gojo.Core.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset AtNoon(this DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, 12, 0, 0, 0, date.Offset);
        }

        public static DateTimeOffset AtTime(this DateTimeOffset date, DateTimeOffset time)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond, date.Offset);
        }

        public static DateTimeOffset WithDate(this DateTimeOffset time, DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond, time.Offset);
        }

        public static DateTimeOffset WithDate(this DateTimeOffset time, DateTime date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond, time.Offset);
        }

        public static DateTimeOffset SkipToNextWorkDay(this DateTimeOffset date)
        {
            // we explicitly choose not to user the CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
            // because we want it to be fixed for what we need, not whatever the user for this is set to.
            if (date.DayOfWeek == DayOfWeek.Saturday)
                return date.AddDays(2);

            if (date.DayOfWeek == DayOfWeek.Sunday)
                return date.AddDays(1);

            return date;
        }
        
        public static DateTimeOffset AsMinutes(this DateTimeOffset self)
        {
            return new DateTimeOffset(self.Year, self.Month, self.Day, self.Hour, self.Minute, 0, 0, self.Offset);
        }

        public static DateTimeOffset ConvertFromUnixTimestamp(long timestamp)
        {
            var origin = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, DateTimeOffset.Now.Offset);
            return origin.AddSeconds(timestamp);
        }

        public static DateTimeOffset ConvertFromJsTimestamp(long timestamp)
        {
            var origin = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, DateTimeOffset.Now.Offset);
            return origin.AddMilliseconds(timestamp);
        }
    }
}
