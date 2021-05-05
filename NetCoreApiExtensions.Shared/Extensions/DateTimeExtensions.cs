using System;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime RoundDateDownTo(this DateTime date, DateListIncrement increment)
        {
            switch (increment)
            {
                case DateListIncrement.Second:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
                    break;
                case DateListIncrement.Minute:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
                    break;
                case DateListIncrement.Hour:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
                    break;
                case DateListIncrement.Day:
                    date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    break;
                case DateListIncrement.Month:
                    date = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
                    break;
                case DateListIncrement.Year:
                    date = new DateTime(date.Year, 1, 1, 0, 0, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return date;
        }

        public static DateTime RoundDateUpTo(this DateTime date, DateListIncrement increment)
        {
            switch (increment)
            {
                case DateListIncrement.Second:
                    date = date.Millisecond == 0
                        ? new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second)
                        : new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second).AddSeconds(1);
                    break;
                case DateListIncrement.Minute:
                    date = date.Second == 0 && date.Millisecond == 0
                        ? new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0)
                        : new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0).AddMinutes(1);
                    break;
                case DateListIncrement.Hour:
                    date = date.Minute == 0 && date.Second == 0 && date.Millisecond == 0
                        ? new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0)
                        : new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0).AddHours(1);
                    break;
                case DateListIncrement.Day:
                    date = date.Hour == 0 && date.Minute == 0 && date.Second == 0 && date.Millisecond == 0
                        ? new DateTime(date.Year, date.Month, date.Day, 0, 0, 0)
                        : new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).AddDays(1);
                    break;
                case DateListIncrement.Month:
                    date = date.Day == 1 && date.Hour == 0 && date.Minute == 0 && date.Second == 0 && date.Millisecond == 0
                        ? new DateTime(date.Year, date.Month, 1, 0, 0, 0)
                        : new DateTime(date.Year, date.Month, 1, 0, 0, 0).AddMonths(1);
                    break;
                case DateListIncrement.Year:
                    date = date.Month == 1 && date.Day == 1 && date.Hour == 0 && date.Minute == 0 && date.Second == 0 && date.Millisecond == 0
                        ? new DateTime(date.Year, 1, 1, 0, 0, 0)
                        : new DateTime(date.Year, 1, 1, 0, 0, 0).AddYears(1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return date;
        }
    }
}