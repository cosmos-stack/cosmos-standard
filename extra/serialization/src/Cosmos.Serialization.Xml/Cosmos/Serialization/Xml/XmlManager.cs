using System.Text;

namespace Cosmos.Serialization.Xml
{
    /// <summary>
    /// Xml manager
    /// </summary>
    public class XmlManager
    {
        private static Encoding _encoding = Encoding.UTF8;

        /// <summary>
        /// Gets or sets default encoding
        /// </summary>
        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }
    }
}