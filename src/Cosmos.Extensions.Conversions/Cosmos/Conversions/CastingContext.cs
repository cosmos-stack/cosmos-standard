using System;
using System.Globalization;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Casting context
    /// </summary>
    public class CastingContext
    {
        /// <summary>
        /// Default casting context
        /// </summary>
        internal static readonly CastingContext DefaultContext = new CastingContext();

        /// <summary>
        /// Ignore case
        /// </summary>
        public IgnoreCase IgnoreCase { get; set; } = IgnoreCase.FALSE;

        /// <summary>
        /// Format
        /// </summary>
        public string Format { get; set; } = null;

        /// <summary>
        /// Number styles
        /// </summary>
        public NumberStyles? NumberStyles { get; set; }

        /// <summary>
        /// DateTime styles
        /// </summary>
        public DateTimeStyles? DateTimeStyles { get; set; }

        /// <summary>
        /// DateTime target types
        /// </summary>
        public DateTimeFormatStyles DateTimeFormatStyles { get; set; } = DateTimeFormatStyles.Normal;

        /// <summary>
        /// Guid format styles
        /// </summary>
        public GuidFormatStyles GuidFormatStyles { get; set; } = GuidFormatStyles.N;

        /// <summary>
        /// Format provider
        /// </summary>
        public IFormatProvider FormatProvider { get; set; }

        /// <summary>
        /// Digits for <see cref="float"/>, <see cref="double"/> and <see cref="decimal"/>
        /// </summary>
        public int Digits { get; set; } = 2;

        /// <summary>
        /// String if true
        /// </summary>
        public string TrueString { get; set; } = "true";

        /// <summary>
        /// String if false
        /// </summary>
        public string FalseString { get; set; } = "false";

        /// <summary>
        /// Number if true
        /// </summary>
        public sbyte NumericTrue { get; set; } = 1;

        /// <summary>
        /// Number if false
        /// </summary>
        public sbyte NumericFalse { get; set; } = 0;
    }
}