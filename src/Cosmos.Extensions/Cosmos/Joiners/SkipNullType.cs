namespace Cosmos.Joiners
{
    /// <summary>
    /// Skip null types<br />
    /// 跳过 null 的类型
    /// </summary>
    public enum SkipNullType
    {
        /// <summary>
        /// Nothing
        /// </summary>
        Nothing,

        /// <summary>
        /// When both
        /// </summary>
        WhenBoth,

        /// <summary>
        /// When either
        /// </summary>
        WhenEither,
        
        /// <summary>
        /// When key is null
        /// </summary>
        WhenKeyIsNull,

        /// <summary>
        /// When value is null
        /// </summary>
        WhenValueIsNull
    }
}