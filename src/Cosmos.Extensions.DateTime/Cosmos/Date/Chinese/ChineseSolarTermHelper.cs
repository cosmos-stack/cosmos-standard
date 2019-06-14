using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

/*
 * Reference to: https://www.jianshu.com/p/de33e6d9d880
 * Update and refactor by Alex LEWIS.
 */

namespace Cosmos.Date.Chinese
{
    /// <summary>
    /// Chinese solar term helper<br />
    /// 中国二十四节气辅助类
    /// </summary>
    public static class ChineseSolarTermHelper
    {
        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        private static readonly string[] SOLARTERMS =
        {
            "小寒", "大寒", "立春", "雨水", "惊蛰", "春分",
            "清明", "谷雨", "立夏", "小满", "芒种", "夏至",
            "小暑", "大暑", "立秋", "处暑", "白露", "秋分",
            "寒露", "霜降", "立冬", "小雪", "大雪", "冬至"
        };

        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        private static readonly string[] SOLARTERMZ =
        {
            "小寒", "大寒", "立春", "雨水", "驚蟄", "春分",
            "清明", "谷雨", "立夏", "小滿", "芒種", "夏至",
            "小暑", "大暑", "立秋", "處暑", "白露", "秋分",
            "寒露", "霜降", "立冬", "小雪", "大雪", "冬至"
        };

        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        private static readonly List<ChineseSolarTerms> SOLARTERMENUM = new List<ChineseSolarTerms>
        {
            ChineseSolarTerms.SlightCold,
            ChineseSolarTerms.GreatCold,
            ChineseSolarTerms.BeginningOfSpring,
            ChineseSolarTerms.RainWater,
            ChineseSolarTerms.TheWakingOfInsects,
            ChineseSolarTerms.VernalEquinox,
            ChineseSolarTerms.QingmingFestival,
            ChineseSolarTerms.GrainRain,
            ChineseSolarTerms.BeginningOfSummer,
            ChineseSolarTerms.GrainFull,
            ChineseSolarTerms.GrainInEar,
            ChineseSolarTerms.SummerSolstice,
            ChineseSolarTerms.SlightHeat,
            ChineseSolarTerms.GreatHeat,
            ChineseSolarTerms.BeginningOfAutumn,
            ChineseSolarTerms.TheLimitOfHeat,
            ChineseSolarTerms.WhiteDew,
            ChineseSolarTerms.AutumnalEquinox,
            ChineseSolarTerms.ColdDew,
            ChineseSolarTerms.FrostsDescent,
            ChineseSolarTerms.BeginningOfWinter,
            ChineseSolarTerms.SlightSnow,
            ChineseSolarTerms.GreatSnow,
            ChineseSolarTerms.WinterSolstice,
        };

        // ReSharper disable once IdentifierTypo
        // ReSharper disable once InconsistentNaming
        private static readonly int[] SOLARTERMINFO = {
            0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989,
            308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758
        };

        /// <summary>
        /// Convert <see cref="ChineseSolarTerms"/> to Chinese name.<br />
        /// 将 <see cref="ChineseSolarTerms"/> 转换为中文名称。
        /// </summary>
        /// <param name="solarTerms"></param>
        /// <param name="traditionalChineseCharacters"></param>
        /// <returns></returns>
        public static string GetName(ChineseSolarTerms solarTerms, bool traditionalChineseCharacters = false)
        {
            var index = SOLARTERMENUM.IndexOf(solarTerms);
            var solarTermP = traditionalChineseCharacters ? SOLARTERMZ : SOLARTERMS;
            return solarTermP[index];
        }

        /// <summary>
        /// Gets solar term for special day.<br />
        /// 获取指定日期（公历）的节气。
        /// </summary>
        public static string GetSolarTerm(ChineseLunisolarCalendar calendar, DateTime targetDt, bool traditionalChineseCharacters = false)
        {
            var i = SolarTermFunc(calendar, targetDt, (x, y) => x == y, out _);
            var solarTermP = traditionalChineseCharacters ? SOLARTERMZ : SOLARTERMS;
            return i == -1 ? "" : solarTermP[i];
        }

        /// <summary>
        /// Gets last solar term<br />
        /// 获取指定日期（公历）的上一个节气。
        /// </summary>
        public static string GetLastSolarTerm(ChineseLunisolarCalendar calendar, DateTime targetDt, bool traditionalChineseCharacters = false)
        {
            return GetLastSolarTerm(calendar, targetDt, out _, traditionalChineseCharacters);
        }

        /// <summary>
        /// Gets last solar term<br />
        /// 获取指定日期（公历）的上一个节气。
        /// </summary>
        public static string GetLastSolarTerm(ChineseLunisolarCalendar calendar, DateTime targetDt, out DateTime dt, bool traditionalChineseCharacters = false)
        {
            var i = SolarTermFunc(calendar, targetDt, (x, y) => x < y, out dt);
            var solarTermP = traditionalChineseCharacters ? SOLARTERMZ : SOLARTERMS;
            return i == -1 ? "" : solarTermP[i];
        }

        /// <summary>
        /// Gets next solar term<br />
        /// 获取指定日期（公历）的下一个节气。
        /// </summary>
        public static string GetNextSolarTerm(ChineseLunisolarCalendar calendar, DateTime targetDt, bool traditionalChineseCharacters = false)
        {
            return GetNextSolarTerm(calendar, targetDt, out _, traditionalChineseCharacters);
        }

        /// <summary>
        /// Gets next solar term<br />
        /// 获取指定日期（公历）的下一个节气。
        /// </summary>
        public static string GetNextSolarTerm(ChineseLunisolarCalendar calendar, DateTime targetDt, out DateTime dt, bool traditionalChineseCharacters = false)
        {
            var i = SolarTermFunc(calendar, targetDt, (x, y) => x > y, out dt);
            var solarTermP = traditionalChineseCharacters ? SOLARTERMZ : SOLARTERMS;
            return i == -1 ? "" : $"{solarTermP[i]}";
        }

        /// <summary>
        /// Get <see cref="ChineseSolarTerms"/> for special day.<br />
        /// 获取指定日期（公历）的节气枚举。
        /// </summary>
        /// <param name="calendar"></param>
        /// <param name="targetDt"></param>
        /// <returns></returns>
        public static ChineseSolarTerms? GetSolarTermEnum(ChineseLunisolarCalendar calendar, DateTime targetDt)
        {
            var i = SolarTermFunc(calendar, targetDt, (x, y) => x == y, out _);
            if (i == -1) return null;
            return SOLARTERMENUM[i];
        }

        /// <summary>
        /// Gets last <see cref="ChineseSolarTerms"/><br />
        /// 获取指定日期（公历）的上一个节气枚举。
        /// </summary>
        /// <param name="calendar"></param>
        /// <param name="targetDt"></param>
        /// <returns></returns>
        public static ChineseSolarTerms? GetLastSolarTermEnum(ChineseLunisolarCalendar calendar, DateTime targetDt)
        {
            return GetLastSolarTermEnum(calendar, targetDt, out _);
        }

        /// <summary>
        /// Gets last <see cref="ChineseSolarTerms"/><br />
        /// 获取指定日期（公历）的上一个节气枚举。
        /// </summary>
        /// <param name="calendar"></param>
        /// <param name="targetDt"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static ChineseSolarTerms? GetLastSolarTermEnum(ChineseLunisolarCalendar calendar, DateTime targetDt, out DateTime dt)
        {
            var i = SolarTermFunc(calendar, targetDt, (x, y) => x < y, out dt);
            if (i == -1) return null;
            return SOLARTERMENUM[i];
        }

        /// <summary>
        /// Gets next <see cref="ChineseSolarTerms"/><br />
        /// 获取指定日期（公历）的下一个节气枚举。
        /// </summary>
        /// <param name="calendar"></param>
        /// <param name="targetDt"></param>
        /// <returns></returns>
        public static ChineseSolarTerms? GetNextSolarTermEnum(ChineseLunisolarCalendar calendar, DateTime targetDt)
        {
            return GetNextSolarTermEnum(calendar, targetDt, out _);
        }

        /// <summary>
        /// Gets next <see cref="ChineseSolarTerms"/><br />
        /// 获取指定日期（公历）的下一个节气枚举。
        /// </summary>
        /// <param name="calendar"></param>
        /// <param name="targetDt"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static ChineseSolarTerms? GetNextSolarTermEnum(ChineseLunisolarCalendar calendar, DateTime targetDt, out DateTime dt)
        {
            var i = SolarTermFunc(calendar, targetDt, (x, y) => x > y, out dt);
            if (i == -1) return null;
            return SOLARTERMENUM[i];
        }

        /// <summary>
        /// 节气计算（当前年），返回指定条件的节气序及日期（公历）
        /// </summary>
        /// <param name="calendar"></param>
        /// <param name="targetDt"></param>
        /// <param name="func"></param>
        /// <param name="dateTime"></param>
        /// <returns>-1时即没找到</returns>
        private static int SolarTermFunc(ChineseLunisolarCalendar calendar, DateTime targetDt, Expression<Func<int, int, bool>> func, out DateTime dateTime)
        {
            var baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
            var year = targetDt.Year;
            int[] solar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            var expressionType = func.Body.NodeType;
            if (expressionType != ExpressionType.LessThan && expressionType != ExpressionType.LessThanOrEqual &&
                expressionType != ExpressionType.GreaterThan && expressionType != ExpressionType.GreaterThanOrEqual &&
                expressionType != ExpressionType.Equal)
            {
                throw new NotSupportedException("不受支持的操作符");
            }

            if (expressionType == ExpressionType.LessThan || expressionType == ExpressionType.LessThanOrEqual)
            {
                solar = solar.OrderByDescending(x => x).ToArray();
            }
            foreach (var item in solar)
            {
                var num = 525948.76 * (year - 1900) + SOLARTERMINFO[item - 1];
                var newDate = baseDateAndTime.AddMinutes(num); //按分钟计算
                if (func.Compile()(newDate.DayOfYear, targetDt.DayOfYear))
                {
                    dateTime = newDate;
                    return item - 1;
                }
            }

            dateTime = calendar.MinSupportedDateTime;
            return -1;
        }
    }
}
