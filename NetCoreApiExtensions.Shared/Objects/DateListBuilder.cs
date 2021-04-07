using System;
using System.Collections;
using System.Collections.Generic;
using NetCoreApiExtensions.Shared.Enumerations;
using NetCoreApiExtensions.Shared.Extensions;

namespace NetCoreApiExtensions.Shared
{
    public class DateListBuilder
    {
        public DateTime Date { get; set; }
        public DateListIncrement Increment { get; set; }
        public DateListIncrementRounding Rounding { get; set; } = DateListIncrementRounding.None;
        public int StepSize { get; set; } = 1;
        public int Count { get; set; }

        private void RoundDate()
        {
            switch (Rounding)
            {
                case DateListIncrementRounding.Down:
                    Date = Date.RoundDateDownTo(Increment);
                    break;
                case DateListIncrementRounding.Up:
                    Date = Date.RoundDateUpTo(Increment);
                    break;
                case DateListIncrementRounding.None:
                default:
                    break;
            }
        }

        public IList<DateTime> ToList()
        {
            if (Rounding != DateListIncrementRounding.None)
            {
                RoundDate();
            }

            var targetCount = Math.Abs(Count);

            var dateList = new List<DateTime>();

            do
            {
                var step = StepSize * dateList.Count;

                switch (Increment)
                {
                    case DateListIncrement.Second:
                        dateList.Add(Date.AddSeconds(step));
                        break;
                    case DateListIncrement.Minute:
                        dateList.Add(Date.AddMinutes(step));
                        break;
                    case DateListIncrement.Hour:
                        dateList.Add(Date.AddHours(step));
                        break;
                    case DateListIncrement.Day:
                        dateList.Add(Date.AddDays(step));
                        break;
                    case DateListIncrement.Month:
                        dateList.Add(Date.AddMonths(step));
                        break;
                    case DateListIncrement.Year:
                        dateList.Add(Date.AddYears(step));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (dateList.Count < targetCount);

            return dateList;
        }

        public static IList<DateTime> CreateList(DateTime date, DateListIncrement increment, int count, int stepSize = 1, DateListIncrementRounding rounding = DateListIncrementRounding.None)
        {
            var dateListBuilder = new DateListBuilder
            {
                Count = count,
                Increment = increment,
                Rounding = rounding,
                StepSize = stepSize,
                Date = date
            };

            return dateListBuilder.ToList();
        }
    }
}