using System;
using Cosmos.Optionals.NamedOptionals;

namespace Cosmos.Optionals {
    /// <summary>
    /// Optional utilities
    /// </summary>
    public static partial class Optional {
        /// <summary>
        /// Get an instance of builder, to build a named Maybe.
        /// </summary>
        public static INamedOptionalBuilder Named => NamedOptionalBuilder.Create();
    }
}