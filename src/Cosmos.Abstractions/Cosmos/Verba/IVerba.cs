using System;

namespace Cosmos.Verba
{
    /// <summary>
    /// Verba Meta Interface
    /// </summary>
    [Obsolete("将会被 Cosmos.I18N 取代")]
    public interface IVerba
    {
        /// <summary>
        /// Verba name
        /// </summary>
        string VerbaName { get; }
    }
}