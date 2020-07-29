namespace Cosmos.Conversions
{
    internal static class GuidFormatStylesExtensions
    {
        public static string X(this GuidFormatStyles styles)
        {
            return styles switch
            {
                GuidFormatStyles.B => "B",
                GuidFormatStyles.D => "D",
                GuidFormatStyles.N => "N",
                GuidFormatStyles.P => "P",
                _ => "N"
            };
        }
    }
}