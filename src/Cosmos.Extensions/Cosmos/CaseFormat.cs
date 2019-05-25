using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Joiners;
using Cosmos.Splitters;

namespace Cosmos
{
    public class CaseFormat
    {
        private readonly ISplitter _splitter;

        private CaseFormat(ISplitter splitter)
        {
            _splitter = splitter ?? throw new ArgumentNullException(nameof(splitter));
        }

        public string To(Style style, string sequence)
        {
            var list = _splitter.SplitToList(sequence);
            IJoiner joiner;
            switch (style)
            {
                case Style.LOWER_CAMEL:
                {
                    CaseFormatUtils.LowerCase(list);
                    CaseFormatUtils.UpperCaseEachFirstChar(list);
                    CaseFormatUtils.LowerCaseFirstItemFirstChar(list);
                    joiner = Joiner.On("");
                    break;
                }

                case Style.LOWER_HYPHEN:
                {
                    CaseFormatUtils.LowerCase(list);
                    joiner = Joiner.On("-");
                    break;
                }

                case Style.LOWER_UNDERSCORE:
                {
                    CaseFormatUtils.LowerCase(list);
                    joiner = Joiner.On("_");
                    break;
                }

                case Style.UPPER_CAMEL:
                {
                    CaseFormatUtils.LowerCase(list);
                    CaseFormatUtils.UpperCaseEachFirstChar(list);
                    joiner = Joiner.On("");
                    break;
                }

                case Style.UPPER_UNDERSCORE:
                {
                    CaseFormatUtils.UpperCase(list);
                    joiner = Joiner.On("_");
                    break;
                }

                default:
                    throw new InvalidOperationException("Invalid operation.");
            }

            return joiner.Join(list);
        }

        public static CaseFormat LowerHyphen => new CaseFormat(Splitter.On("-"));

        public static CaseFormat LowerUnderscore => new CaseFormat(Splitter.On("_"));

        public static CaseFormat UpperUnderscore => new CaseFormat(Splitter.On("_"));

        public static CaseFormat Instance => new CaseFormat(Splitter.OnPattern("-_ "));

        private static class CaseFormatUtils
        {
            public static void LowerCase(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    list[i] = list[i].ToLower();
                }
            }

            public static void UpperCase(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    list[i] = list[i].ToUpper();
                }
            }

            public static void LowerCaseEachFirstChar(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i].IsNullOrWhiteSpace())
                        continue;

                    var array = list[i].ToCharArray();

                    array[0] = array[0].ToLowerInvariant();
                    list[i] = new string(array);
                }
            }

            public static void UpperCaseEachFirstChar(List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i].IsNullOrWhiteSpace())
                        continue;

                    var array = list[i].ToCharArray();

                    array[0] = array[0].ToUpperInvariant();
                    list[i] = new string(array);
                }
            }

            public static void LowerCaseFirstItemFirstChar(List<string> list)
            {
                if (list != null && list.Any() && !list[0].IsNullOrWhiteSpace())
                {
                    var array = list[0].ToCharArray();

                    array[0] = array[0].ToLowerInvariant();
                    list[0] = new string(array);
                }
            }

            public static void UpperCaseFirstItemFirstChar(List<string> list)
            {
                if (list != null && list.Any() && !list[0].IsNullOrWhiteSpace())
                {
                    var array = list[0].ToCharArray();

                    array[0] = array[0].ToUpperInvariant();
                    list[0] = new string(array);
                }
            }
        }

        public enum Style
        {
            LOWER_CAMEL,
            LOWER_HYPHEN,
            LOWER_UNDERSCORE,
            UPPER_CAMEL,
            UPPER_UNDERSCORE
        }
    }
}