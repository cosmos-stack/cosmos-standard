using System;
using System.IO;
using System.Text;

namespace Cosmos.Html.Core
{
    /// <summary>
    /// Stream Encoder
    /// </summary>
    public class StreamEncoder
    {
        /// <summary>   
        /// 取得一个文本文件的编码方式。如果无法在文件头部找到有效的前导符，Encoding.Default将被返回。   
        /// </summary>   
        /// <param name="fileName">文件名。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(string fileName) => GetEncoding(fileName, Encoding.Default);

        /// <summary>   
        /// 取得一个文本文件流的编码方式。   
        /// </summary>   
        /// <param name="stream">文本文件流。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(FileStream stream) => GetEncoding(stream, Encoding.Default);

        /// <summary>   
        /// 取得一个文本文件的编码方式。   
        /// </summary>   
        /// <param name="fileName">文件名。</param>   
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(string fileName, Encoding defaultEncoding)
        {
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                return GetEncoding(fs, defaultEncoding);
            }
        }

        /// <summary>   
        /// 取得一个文本文件流的编码方式。   
        /// </summary>   
        /// <param name="stream">文本文件流。</param>   
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(FileStream stream, Encoding defaultEncoding)
        {
            var targetEncoding = defaultEncoding;

            if (stream != null && stream.Length >= 2)
            {
                //保存文件流的前4个字节   
                byte byte1 = 0;
                byte byte2 = 0;
                byte byte3 = 0;
                byte byte4 = 0;

                //保存当前Seek位置   
                var origPos = stream.Seek(0, SeekOrigin.Begin);
                stream.Seek(0, SeekOrigin.Begin);

                var nByte = stream.ReadByte();
                byte1 = Convert.ToByte(nByte);
                byte2 = Convert.ToByte(stream.ReadByte());
                if (stream.Length >= 3)
                    byte3 = Convert.ToByte(stream.ReadByte());

                if (stream.Length >= 4)
                    byte4 = Convert.ToByte(stream.ReadByte());

                //根据文件流的前4个字节判断Encoding   
                //Unicode {0xFF, 0xFE};   
                //BE-Unicode {0xFE, 0xFF};   
                //UTF8 = {0xEF, 0xBB, 0xBF};   
                if (byte1 == 0xFE && byte2 == 0xFF)//UnicodeBe  
                    targetEncoding = Encoding.BigEndianUnicode;

                if (byte1 == 0xFF && byte2 == 0xFE && byte3 != 0xFF)//Unicode   
                    targetEncoding = Encoding.Unicode;

                if (byte1 == 0xEF && byte2 == 0xBB && byte3 == 0xBF)//UTF8   
                    targetEncoding = Encoding.UTF8;

                //恢复Seek位置         
                stream.Seek(origPos, SeekOrigin.Begin);
            }

            return targetEncoding;
        }

        /// <summary>
        /// 从字节数组中返回字符编码
        /// </summary>
        /// <param name="sen">字节数组</param>
        /// <returns>编码结果</returns>
        public static System.Text.Encoding GetEncodingFromBytes(byte[] sen)
        {
            if (sen.Length == 0)
                return null;

            using (Stream stream = new MemoryStream(sen))
            {
                return GetEncoding(stream);
            }
        }

        // 新增加一个方法，解决了不带BOM的 UTF8 编码问题    
        /// <summary>   
        /// 通过给定的文件流，判断文件的编码类型   
        /// </summary>   
        /// <param name="fs">文件流</param>   
        /// <returns>文件的编码类型</returns>   
        public static System.Text.Encoding GetEncoding(Stream fs)
        {
            var reVal = Encoding.Default;

            using (var r = new BinaryReader(fs, System.Text.Encoding.Default))
            {
                var ss = r.ReadBytes(4);
                if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
                {
                    reVal = Encoding.BigEndianUnicode;
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
                {
                    reVal = Encoding.Unicode;
                }
                else
                {
                    if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                    {
                        reVal = Encoding.UTF8;
                    }
                    else
                    {
                        int i;
                        int.TryParse(fs.Length.ToString(), out i);
                        ss = r.ReadBytes(i);

                        if (IsUtf8Bytes(ss))
                            reVal = Encoding.UTF8;
                    }
                }
                r.Close();
                return reVal;
            }
        }

        /// <summary>   
        /// 判断是否是不带 BOM 的 UTF8 格式   
        /// </summary>   
        /// <param name="data"></param>   
        /// <returns></returns>   
        private static bool IsUtf8Bytes(byte[] data)
        {
            var charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数   
            byte currentByte; //当前分析的字节. 
            
            for (var i = 0; i < data.Length; i++)
            {
                currentByte = data[i];
                if (charByteCounter == 1)
                {
                    if (currentByte >= 0x80)
                    {
                        //判断当前   
                        while (((currentByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　   
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1   
                    if ((currentByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }

            return charByteCounter <= 1;
        }
    }
}
