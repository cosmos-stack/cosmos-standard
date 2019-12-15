using System;

namespace Cosmos.Domain.EntityDescriptors {
    /// <summary>
    /// To flag this entity will be expired, include start time and end time.
    /// </summary>
    public interface IExpireable {
        /// <summary>
        /// Expire limited from...
        /// </summary>
        DateTime? ExpireLimitedFromTime { get; set; }

        /// <summary>
        /// Expire limited to...
        /// </summary>
        DateTime? ExpireLimitedToTime { get; set; }

        /// <summary>
        /// Is start
        /// </summary>
        /// <returns></returns>
        bool IsStart();

        /// <summary>
        /// Is start
        /// </summary>
        /// <param name="targetTime"></param>
        /// <returns></returns>
        bool IsStart(DateTime targetTime);

        /// <summary>
        /// Is expired
        /// </summary>
        /// <returns></returns>
        bool IsExpired();

        /// <summary>
        /// Is expired
        /// </summary>
        /// <param name="targetTime"></param>
        /// <returns></returns>
        bool IsExpired(DateTime targetTime);

        /// <summary>
        /// Is active
        /// </summary>
        /// <returns></returns>
        bool IsActive();

        /// <summary>
        /// Is active
        /// </summary>
        /// <param name="targetTime"></param>
        /// <returns></returns>
        bool IsActive(DateTime targetTime);
    }
}