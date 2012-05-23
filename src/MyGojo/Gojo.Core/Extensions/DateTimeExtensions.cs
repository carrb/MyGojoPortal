using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Gojo.Core.Extensions
{
    public static class DateTimeExtensions
    {
        /// AddWeekdays
        /// 
        /// Example Usage:
        ///     var newYearsEve2010 = new DateTime(2010, 12, 31);
        ///     var firstWeekdayAfterNewYearsEve2010 = newYearsEve2010.AddWeekdays(1);
        /// 
        public static DateTime AddWeekdays(this DateTime date, int days)
        {
            var sign = days < 0 ? -1 : 1;
            var unsignedDays = Math.Abs(days);
            var weekdaysAdded = 0;

            while (weekdaysAdded < unsignedDays)
            {
                date = date.AddDays(sign);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    weekdaysAdded++;
            }

            return date;
        }


        /// SetTime
        /// 
        /// Example Usage:
        ///     var quittingTime = DateTime.Now.SetTime(5, 45); 
        /// 
        public static DateTime SetTime(this DateTime date, int hour)
        {
            return date.SetTime(hour, 0, 0, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute)
        {
            return date.SetTime(hour, minute, 0, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
        {
            return date.SetTime(hour, minute, second, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
        }


        /// FirstDayOfMonth / LastDayOfMonth
        /// 
        /// Example Usage:
        ///     var firstDayOfThisMonth = DateTime.Now.FirstDayOfMonth();
        ///     var lastDayOfThisMonth = DateTime.Now.LastDayOfMonth();
        /// 
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }


        /// ToString - for Nullable DateTime Values
        /// 
        /// Example Usage:
        ///     DateTime? nullableDate = ...;
        ///     string formattedDate = nullableDate.ToString("...");
        /// 
        public static string ToString(this DateTime? date)
        {
            return date.ToString(null, DateTimeFormatInfo.CurrentInfo);
        }

        public static string ToString(this DateTime? date, string format)
        {
            return date.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        public static string ToString(this DateTime? date, IFormatProvider provider)
        {
            return date.ToString(null, provider);
        }

        public static string ToString(this DateTime? date, string format, IFormatProvider provider)
        {
            return date.HasValue ? date.Value.ToString(format, provider) : string.Empty;
        }


        /// ToRelativeDateString
        /// 
        /// Example Usage:
        ///     DateTime? nullableDate = ...;
        ///     string formattedDate = nullableDate.ToString("...");
        /// 
        public static string ToRelativeDateString(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.Now);
        }

        public static string ToRelativeDateStringUtc(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.UtcNow);
        }

        private static string GetRelativeDateValue(DateTime date, DateTime comparedTo)
        {
            TimeSpan diff = comparedTo.Subtract(date);

            if (diff.TotalDays >= 365)
                return string.Concat("on ", date.ToString("MMMM d, yyyy"));
            if (diff.TotalDays >= 7)
                return string.Concat("on ", date.ToString("MMMM d"));
            if (diff.TotalDays > 1)
                return string.Format("{0:N0} days ago", diff.TotalDays);
            if (diff.TotalDays == 1)
                return "yesterday";
            if (diff.TotalHours >= 2)
                return string.Format("{0:N0} hours ago", diff.TotalHours);
            if (diff.TotalMinutes >= 60)
                return "more than an hour ago";
            if (diff.TotalMinutes >= 5)
                return string.Format("{0:N0} minutes ago", diff.TotalMinutes);
            return diff.TotalMinutes >= 1 ? "a few minutes ago" : "less than a minute ago";
        }


        
        /// ToStartOfTimeZonesDayInUtc - The time in UTC that the day started in the given time zone for a specific UTC time
        /// 
        /// <param name="utcTime">A point in time, specified in UTC</param>
        /// <param name="timezone">The time zone that determines when the day started</param>
        /// 
        public static DateTime ToStartOfTimeZonesDayInUtc(this DateTime utcTime, TimeZoneInfo timezone)
        {
            var startOfDayInGivenTimeZone = utcTime.ToLocalTime(timezone).Date;
            return startOfDayInGivenTimeZone.ToUniversalTime(timezone);
        }

        /// StartOfTodayInUtc - The time in UTC that the current day started in the given time zone
        /// 
        /// <param name="timezone">The time zone that determines when the day started</param>
        /// 
        public static DateTime StartOfTodayInUtc(this TimeZoneInfo timezone)
        {
            return DateTime.UtcNow.ToStartOfTimeZonesDayInUtc(timezone);
        }

        /// ToLocalTime - Converts a UTC time to a time in the given time zone
        /// 
        /// <param name="targetTimeZone">The time zone to convert to</param>
        /// <param name="utcTime">The UTC time</param>
        /// 
        public static DateTime ToLocalTime(this DateTime utcTime, TimeZoneInfo targetTimeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, targetTimeZone);
        }

        /// ToUniversalTime - Converts a local time to a UTC time
        /// 
        /// <param name="sourceTimeZone">The time zone of the local time</param>
        /// <param name="localTime">The local time</param>
        /// 
        public static DateTime ToUniversalTime(this DateTime localTime, TimeZoneInfo sourceTimeZone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(localTime, sourceTimeZone);
        }
    }
}
