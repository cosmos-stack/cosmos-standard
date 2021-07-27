using System.Runtime.CompilerServices;
using Cosmos.Optionals.DynamicOptionals;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Optional utilities
    /// </summary>
    public static partial class Optional
    {
        /// <summary>
        /// Get an instance of builder, to build a dynamic Maybe.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IDynamicOptionalBuilder Dynamic => DynamicOptionalBuilder.Create();
    }
}