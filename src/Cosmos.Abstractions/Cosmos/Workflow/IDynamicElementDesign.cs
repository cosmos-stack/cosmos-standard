namespace Cosmos.Workflow
{
    /// <summary>
    /// Dynamic Element Design Interface
    /// </summary>
    public interface IDynamicElementDesign
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
    }
}