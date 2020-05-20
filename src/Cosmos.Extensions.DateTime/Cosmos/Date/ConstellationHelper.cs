using System;

namespace Cosmos.Date
{
    /// <summary>
    /// Constellation helper<br />
    /// 星座辅助类
    /// </summary>
    public static class ConstellationHelper
    {
        private static readonly string[] ConstellationName =
        {
            "白羊座",
            "金牛座",
            "双子座",
            "巨蟹座",
            "狮子座",
            "处女座",
            "天秤座",
            "天蝎座",
            "射手座",
            "摩羯座",
            "水瓶座",
            "双鱼座"
        };

        /// <summary>
        /// Gets Constellation name<br />
        /// 获取星座名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string Get(DateTime dt)
        {
            int index;
            var m = dt.Month;
            var d = dt.Day;
            var y = m * 100 + d;
            if (((y >= 321) && (y <= 419)))
            {
                index = 0;
            }
            else if ((y >= 420) && (y <= 520))
            {
                index = 1;
            }
            else if ((y >= 521) && (y <= 620))
            {
                index = 2;
            }
            else if ((y >= 621) && (y <= 722))
            {
                index = 3;
            }
            else if ((y >= 723) && (y <= 822))
            {
                index = 4;
            }
            else if ((y >= 823) && (y <= 922))
            {
                index = 5;
            }
            else if ((y >= 923) && (y <= 1022))
            {
                index = 6;
            }
            else if ((y >= 1023) && (y <= 1121))
            {
                index = 7;
            }
            else if ((y >= 1122) && (y <= 1221))
            {
                index = 8;
            }
            else if ((y >= 1222) || (y <= 119))
            {
                index = 9;
            }
            else if ((y >= 120) && (y <= 218))
            {
                index = 10;
            }
            else if ((y >= 219) && (y <= 320))
            {
                index = 11;
            }
            else
            {
                index = 0;
            }

            return ConstellationName[index];
        }
    }
}