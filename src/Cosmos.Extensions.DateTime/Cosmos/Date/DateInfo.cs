using System;
using FluentDateTime;
using NodaTime;

namespace Cosmos.Date
{
    public class DateInfo
    {
        // ReSharper disable once InconsistentNaming
        private DateTime _internalDateTime { get; set; }

        internal DateInfo() { }

        public DateInfo(DateTime dt)
        {
            _internalDateTime = dt.SetTime(0, 0, 0, 0);
        }

        public DateInfo(int year, int month, int day)
        {
            _internalDateTime = new DateTime(year, month, day, 0, 0, 0, 0);
        }

        public virtual int Year {
            get => _internalDateTime.Year;
            set => _internalDateTime = _internalDateTime.SetYear(value);
        }

        public virtual int Month {
            get => _internalDateTime.Month;
            set => _internalDateTime = _internalDateTime.SetMonth(DateChecker.CheckMonth(value));
        }

        public virtual int Day {
            get => _internalDateTime.Day;
            set => _internalDateTime = _internalDateTime.SetDay(value);
        }

        public virtual DateTime ToDateTime() => _internalDateTime.Clone();

        internal DateTime DateTimeRef => _internalDateTime;

        private static class DateChecker
        {
            public static int CheckMonth(int monthValue)
            {
                if (monthValue < 0 || monthValue > 12)
                    throw new ArgumentOutOfRangeException(nameof(monthValue), monthValue, "Month should be from 1 to 12.");
                return monthValue;
            }
        }

        public DateInfo AddDays(int days)
        {
            _internalDateTime = _internalDateTime.AddDays(days);
            return this;
        }

        public DateInfo AddMonths(int months)
        {
            _internalDateTime = _internalDateTime.AddMonths(months);
            return this;
        }

        public DateInfo AddYears(int years)
        {
            _internalDateTime = _internalDateTime.AddYears(years);
            return this;
        }

        public DateInfo AddDuration(Duration duration)
        {
            _internalDateTime = _internalDateTime.AddDuration(duration);
            return this;
        }

        public static implicit operator DateTime(DateInfo di)
        {
            return di.ToDateTime();
        }

        public static implicit operator DateInfo(DateTime dt)
        {
            return new DateInfo(dt);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is DateInfo date)
            {
                return _internalDateTime.Equals(date._internalDateTime);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return $"year={Year}&month={Month}&day={Day}".GetHashCode();
        }
    }
}
