namespace Cosmos.Html.Elements
{
    /// <summary>
    /// A
    /// </summary>
    public class AElement
    {
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// 链接文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 链接的图片 
        /// </summary>
        public ImgElement Img { get; set; }

        /// <summary>
        /// 整个连接Html
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// A链接的类型 文本/图像
        /// </summary>
        public AType Type { get; set; }
    }
}