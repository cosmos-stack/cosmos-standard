using System;
using NodaTime;

namespace Cosmos.Date
{
    public class PeriodDateBuilder
    {
        public PeriodDateBuilder() { }

        public PeriodDateBuilder(DateTime from) : this(from.ToDateInfo(), InfiniteFutureInfo.Instance) { }

        public PeriodDateBuilder(DateTime from, DateTime to) : this(from.ToDateInfo(), to.ToDateInfo()) { }

        public PeriodDateBuilder(DateInfo from) : this(from, InfiniteFutureInfo.Instance) { }

        public PeriodDateBuilder(DateInfo from, DateInfo to)
        {
            _diFrom = from ?? throw new ArgumentNullException(nameof(from));
            _diTo = to ?? throw new ArgumentNullException(nameof(to));
        }

        private DateInfo _diFrom;
        private DateInfo _diTo;

        public PeriodDateBuilder From(DateInfo from)
        {
            _diFrom = from;
            return this;
        }

        public PeriodDateBuilder To(DateInfo to)
        {
            _diTo = to;
            return this;
        }

        public PeriodDateBuilder From(DateTime from) => From(from.ToDateInfo());

        public PeriodDateBuilder From(int year, int month, int day) => From(new DateInfo(year, month, day));

        public PeriodDateBuilder To(DateTime to) => To(to.ToDateInfo());

        public PeriodDateBuilder To(int year, int month, int day) => To(new DateInfo(year, month, day));

        public PeriodDateBuilder To(int days) => To(Duration.FromDays(days));

        public PeriodDateBuilder To(Duration duration) => To(_diFrom.DateTimeRef + duration.ToTimeSpan());


        public PeriodDateInfo Build()
        {
            var instance = new PeriodDateInfo(_diFrom, _diTo);

            return instance;
        }
    }
}
