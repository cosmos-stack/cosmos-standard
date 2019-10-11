using System;
using System.Collections.Generic;

namespace Cosmos.Verba.Boolean
{
    /// <summary>
    /// Interface for boolean verba
    /// </summary>
    [Obsolete("将会被 Cosmos.I18N 取代")]
    public interface IBooleanVerba : IVerba
    {
        /// <summary>
        /// True alias list
        /// </summary>
        IList<string> TrueVerbaList { get; }

        /// <summary>
        /// False alias list
        /// </summary>
        IList<string> FalseVerbaList { get; }
    }
}