using System;

namespace Cosmos.Html {
    /// <summary>
    /// Regex rule for html elements
    /// </summary>
    public static class HtmlElementRule {
        /// <summary>
        /// To match all a-flag
        /// </summary>
        public static readonly string AList = "<a[\\s\\S]+?href[=\"\']([\\s\\S]+?)[\"\'\\s+][\\s\\S]+?>([\\s\\S]+?)</a>";

        /// <summary>
        /// To match all img-flag
        /// </summary>
        public static readonly string ImgList = "<img[\\s\\S]*?src=[\"\']([\\s\\S]*?)[\"\'][\\s\\S]*?>([\\s\\S]*?)>";

        /// <summary>
        /// To match all Nscript-flag
        /// </summary>
        public static readonly string Nscript = "<nscript[\\s\\S]*?>[\\s\\S]*?</nscript>";

        /// <summary>
        /// To match all style-flag
        /// </summary>
        public static readonly string Style = "<style[\\s\\S]*?>[\\s\\S]*?</style>";

        /// <summary>
        /// To match all script-flag
        /// </summary>
        public static readonly string Script = "<script[\\s\\S]*?>[\\s\\S]*?</script>";

        /// <summary>
        /// To match all html tags
        /// </summary>
        public static readonly string Html = "<[\\s\\S]*?>";

        /// <summary>
        /// To match newline
        /// </summary>
        public static readonly string NewLine = Environment.NewLine;

        /// <summary>
        ///To match the encode of html page
        /// </summary>
        public static readonly string Enconding = "<meta[^<]*charset=([^<]*)[\"']";

        /// <summary>
        /// To match all html
        /// </summary>
        public static readonly string AllHtml = "([\\s\\S]*?)";

        /// <summary>
        /// To match title-flag
        /// </summary>
        public static readonly string HtmlTitle = "<title>([\\s\\S]*?)</title>";
    }
}