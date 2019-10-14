using System;
using System.Collections.Generic;

namespace Cosmos.Verba.Boolean
{
    /// <summary>
    /// Default global boolean verba
    /// </summary>
    [Obsolete("将会被 Cosmos.I18N 取代")]
    public class DefaultBooleanVerba : IBooleanVerba
    {
        static DefaultBooleanVerba()
        {
            Instance = new DefaultBooleanVerba();
        }

        /// <summary>
        /// Get a default global boolean verba instance
        /// </summary>
        public static DefaultBooleanVerba Instance { get; }

        private DefaultBooleanVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultBooleanVerba";

        /// <summary>
        /// True alias list
        /// </summary>
        public IList<string> TrueVerbaList { get; } = new List<string>() { "1", "yes", "yep", "ok" };

        /// <summary>
        /// False alias list
        /// </summary>
        public IList<string> FalseVerbaList { get; } = new List<string>() { "0", "no", "nope" };
    }
}