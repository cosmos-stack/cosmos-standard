using System;

namespace Cosmos.Date
{
    public class InfinitePastInfo : DateInfo
    {
        // ReSharper disable once InconsistentNaming
        private static readonly DateTime _internalDateTime = DateTime.MinValue;

        public static InfinitePastInfo Instance { get; } = new InfinitePastInfo();

        private InfinitePastInfo() { }

        public override int Year => _internalDateTime.Year;

        public override int Month => _internalDateTime.Month;

        public override int Day => _internalDateTime.Day;

        public override DateTime ToDateTime() => DateTime.MinValue;
    }
}
