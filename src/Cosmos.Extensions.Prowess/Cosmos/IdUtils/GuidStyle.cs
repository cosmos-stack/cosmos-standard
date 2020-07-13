namespace Cosmos.IdUtils
{
    /// <summary>
    /// Guid style
    /// </summary>
    public enum GuidStyle
    {
        /// <summary>
        /// Basic
        /// </summary>
        BasicStyle,

        /// <summary>
        /// Timestamp
        /// </summary>
        TimeStampStyle,

        /// <summary>
        /// Unix timestamp
        /// </summary>
        UnixTimeStampStyle,

        /// <summary>
        /// Sql timestamp
        /// </summary>
        SqlTimeStampStyle,

        /// <summary>
        /// Legacy sql timestamp
        /// </summary>
        LegacySqlTimeStampStyle,

        /// <summary>
        /// PostgreSql timestamp
        /// </summary>
        PostgreSqlTimeStampStyle,

        /// <summary>
        /// Comb
        /// </summary>
        CombStyle,

        /// <summary>
        /// Sequential as string
        /// </summary>
        SequentialAsStringStyle,

        /// <summary>
        /// Sequential as binary
        /// </summary>
        SequentialAsBinaryStyle,

        /// <summary>
        /// Sequential as end
        /// </summary>
        SequentialAsEndStyle,

        /// <summary>
        /// Equifax
        /// </summary>
        EquifaxStyle,
    }
}