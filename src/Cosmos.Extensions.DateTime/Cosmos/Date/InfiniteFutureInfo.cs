using System;

namespace Cosmos.Date
{
    public class InfiniteFutureInfo : DateInfo
    {
        // ReSharper disable once InconsistentNaming
        private static readonly DateTime _internalDateTime = DateTime.MaxValue;

        public static InfiniteFutureInfo Instance { get; } = new InfiniteFutureInfo();

        private InfiniteFutureInfo() { }

        public override int Year => _internalDateTime.Year;

        public override int Month => _internalDateTime.Month;

        public override int Day => _internalDateTime.Day;

        public override DateTime ToDateTime() => DateTime.MaxValue;
    }
}
