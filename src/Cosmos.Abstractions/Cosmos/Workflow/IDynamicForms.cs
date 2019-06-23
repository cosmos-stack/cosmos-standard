namespace Cosmos.Workflow
{
    /// <summary>
    /// Dynamic Forms Interface
    /// </summary>
    public interface IDynamicForms
    {
        /// <summary>
        /// Dynamic Forms Design
        /// </summary>
        IDynamicFormsDesign Design { get; }

        /// <summary>
        /// Title
        /// </summary>
        string Title { get; }
    }
}