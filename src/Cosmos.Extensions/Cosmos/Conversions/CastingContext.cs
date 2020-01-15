using System;
using System.Globalization;
using Cosmos.IdUtils;

namespace Cosmos.Conversions {
    /// <summary>
    /// Casting context
    /// </summary>
    public class CastingContext {
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
    }
}