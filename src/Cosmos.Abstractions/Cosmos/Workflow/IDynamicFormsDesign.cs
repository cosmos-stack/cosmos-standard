using System.Collections.Generic;

namespace Cosmos.Workflow
{
    /// <summary>
    /// Dynamic Forms Design Interface
    /// </summary>
    public interface IDynamicFormsDesign
    {
        /// <summary>
        /// Id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Display Title
        /// </summary>
        string DisplayTitle { get; set; }

        /// <summary>
        /// Elements
        /// </summary>
        IList<IDynamicElementDesign> Elements { get; }
    }
}