using System;

namespace Cosmos.IdUtils {
    /// <summary>
    /// Model Id Accessor
    /// </summary>
    public sealed class ModelIdAccessor {
        private NoRepeatTimeStampFactory _factory = new NoRepeatTimeStampFactory();
        private int Index { get; set; }
        private DateTime Now { get; set; }

        private readonly object _lockObj = new object();

        /// <summary>
        /// Create a new <see cref="ModelIdAccessor"/> instance.
        /// </summary>
        public ModelIdAccessor() {
            Now = _factory.GetTimeStamp();
        }

        /// <summary>
        /// Get next index
        /// </summary>
        /// <returns></returns>
        public int GetNextIndex() {
            int ix;

            lock (_lockObj) {
                ix = Index;
                Index = Index + 1;
            }

            return ix;
        }

        /// <summary>
        /// Get time spot
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeSpot() => Now;

        /// <summary>
        /// Refresh time spot
        /// </summary>
        public void RefreshTimeSpot() => Now = _factory.GetTimeStamp();
    }
}