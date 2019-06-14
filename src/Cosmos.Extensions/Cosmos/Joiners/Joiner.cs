using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Joiners
{
    /// <summary>
    /// Joiner<br />
    /// 连接器
    /// </summary>
    public partial class Joiner : IJoiner
    {
        private readonly string _on;

        private JoinerOptions Options { get; set; } = new JoinerOptions();

        private Joiner(string on)
        {
            _on = on;
        }

        #region SkipNulls

        /// <summary>
        /// Skip null<br />
        /// 跳过 null
        /// </summary>
        /// <returns></returns>
        IJoiner IJoiner.SkipNulls()
        {
            Options.SetSkipNulls();
            return this;
        }

        #endregion

        #region UseForNull

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IJoiner IJoiner.UseForNull(string value)
        {
            Options.SetReplacer<string>(s => value);
            return this;
        }

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        IJoiner IJoiner.UseForNull(Func<string, string> valueFunc)
        {
            Options.SetReplacer(valueFunc);
            return this;
        }

        #endregion

        #region WithKeyValueSeparator

        /// <summary>
        /// With KeyValue Separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IMapJoiner WithKeyValueSeparator(string separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        /// <summary>
        /// With KeyValue Separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IMapJoiner WithKeyValueSeparator(char separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        #endregion

        #region Join - List

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string IJoiner.Join(IEnumerable<string> list)
        {
            return list.JoinToString(_on, JoinerUtils.GetStringPredicate(Options), Options.GetReplacer<string>());
        }

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        string IJoiner.Join<T>(IEnumerable<T> list, ITypeConverter<T, string> converter)
        {
            return list.JoinToString(_on, JoinerUtils.GetObjectPredicate<T>(Options), converter, replaceFunc: Options.GetReplacer<T>());
        }

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        string IJoiner.Join<T>(IEnumerable<T> list, Func<T, string> to)
        {
            return list.JoinToString(_on, JoinerUtils.GetObjectPredicate<T>(Options), to, Options.GetReplacer<T>());
        }

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="restStrings"></param>
        /// <returns></returns>
        string IJoiner.Join(string str1, params string[] restStrings)
        {
            var list = new List<string>() { str1 };
            list.AddRange(restStrings);
            return ((IJoiner)this).Join(list);
        }

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converter"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        string IJoiner.Join<T>(ITypeConverter<T, string> converter, T item1, params T[] restItems)
        {
            var list = new List<T> { item1 };
            list.AddRange(restItems);
            return ((IJoiner)this).Join(list, converter);
        }

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="to"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        string IJoiner.Join<T>(Func<T, string> to, T item1, params T[] restItems)
        {
            var list = new List<T> { item1 };
            list.AddRange(restItems);
            return ((IJoiner)this).Join(list, to);
        }

        #endregion

        #region AppendTo

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        StringBuilder IJoiner.AppendTo(StringBuilder builder, IEnumerable<string> list)
        {
            CommonJoinUtils.JoinToString(builder, (c, s) => c.Append(s), list, _on, JoinerUtils.GetStringPredicate(Options), s => s, Options.GetReplacer<string>());
            return builder;
        }

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="str1"></param>
        /// <param name="restStrings"></param>
        /// <returns></returns>
        StringBuilder IJoiner.AppendTo(StringBuilder builder, string str1, params string[] restStrings)
        {
            var list = new List<string>() { str1 };
            list.AddRange(restStrings);
            return ((IJoiner)this).AppendTo(builder, list);
        }

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        StringBuilder IJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, ITypeConverter<T, string> converter)
        {
            CommonJoinUtils.JoinToString(builder, (c, s) => c.Append(s), list, _on, JoinerUtils.GetObjectPredicate<T>(Options), converter.To, replaceFunc: Options.GetReplacer<T>());
            return builder;
        }

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        StringBuilder IJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, Func<T, string> to)
        {
            CommonJoinUtils.JoinToString(builder, (c, s) => c.Append(s), list, _on, JoinerUtils.GetObjectPredicate<T>(Options), to, replaceFunc: Options.GetReplacer<T>());
            return builder;
        }

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="converter"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        StringBuilder IJoiner.AppendTo<T>(StringBuilder builder, ITypeConverter<T, string> converter, T item1, params T[] restItems)
        {
            var list = new List<T> { item1 };
            list.AddRange(restItems);
            return ((IJoiner)this).AppendTo(builder, list, converter);
        }

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="to"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        StringBuilder IJoiner.AppendTo<T>(StringBuilder builder, Func<T, string> to, T item1, params T[] restItems)
        {
            var list = new List<T> { item1 };
            list.AddRange(restItems);
            return ((IJoiner)this).AppendTo(builder, list, to);
        }

        #endregion

        #region On

        /// <summary>
        /// On, create a new <see cref="Joiner"/> instance.<br />
        /// On 操作，创建一个新 <see cref="Joiner"/> 实例。
        /// </summary>
        /// <param name="on"></param>
        /// <returns></returns>
        public static IJoiner On(string on)
        {
            return new Joiner(on);
        }

        /// <summary>
        /// On, create a new <see cref="Joiner"/> instance.<br />
        /// On 操作，创建一个新 <see cref="Joiner"/> 实例。
        /// </summary>
        /// <param name="on"></param>
        /// <returns></returns>
        public static IJoiner On(char on)
        {
            return new Joiner($"{on}");
        }

        #endregion

        #region Private class

        private partial class JoinerOptions
        {
            #region Skip Nulls - List

            public bool SkipNullsFlag { get; private set; }

            public void SetSkipNulls()
            {
                SkipNullsFlag = true;
            }

            #endregion

            #region UseForNull

            private JoinerObjectReplacer ObjectReplacer { get; set; }

            private bool ObjectReplacerFlag { get; set; }

            public Func<T, T> GetReplacer<T>()
            {
                return ObjectReplacerFlag ? ObjectReplacer?.GetValue<T>() : null;
            }

            public void SetReplacer<T>(Func<T, T> valueFunc)
            {
                ObjectReplacerFlag = true;
                ObjectReplacer = JoinerObjectReplacer.Create(valueFunc);
                SetSkipNulls();
            }

            #endregion

            private class JoinerObjectReplacer
            {
                private dynamic KeyFunc { get; }
                private dynamic ValueFunc { get; }

                private JoinerObjectReplacer(dynamic keyFunc, dynamic valueFunc)
                {
                    KeyFunc = keyFunc;
                    ValueFunc = valueFunc;
                }

                public Func<T, T> GetValue<T>() => ValueFunc as Func<T, T>;

                public Func<T1, T2> GetMapKey<T1, T2>() => KeyFunc as Func<T1, T2>;

                public Func<T1, T2> GetMapValue<T1, T2>() => ValueFunc as Func<T1, T2>;

                public Func<T1, T2, T1> GetTupleKey<T1, T2>() => KeyFunc as Func<T1, T2, T1>;

                public Func<T1, T2, T2> GetTupleValue<T1, T2>() => ValueFunc as Func<T1, T2, T2>;

                public static JoinerObjectReplacer Create<T>(Func<T, T> valueFunc) => new JoinerObjectReplacer(null, valueFunc);

                public static JoinerObjectReplacer CreateForMap<T1, T2, T3, T4>(Func<T1, T2> keyFunc, Func<T3, T4> valueFunc) => new JoinerObjectReplacer(keyFunc, valueFunc);

                public static JoinerObjectReplacer CreateForTuple<T1, T2, T3, T4>(Func<T1, T2, T1> keyFunc, Func<T3, T4, T4> valueFunc) => new JoinerObjectReplacer(keyFunc, valueFunc);
            }
        }

        private static partial class JoinerUtils
        {
            public static Func<string, bool> GetStringPredicate(JoinerOptions options)
            {
                if (options.SkipNullsFlag)
                    return s => !string.IsNullOrWhiteSpace(s);
                return null;
            }

            public static Func<T, bool> GetObjectPredicate<T>(JoinerOptions options)
            {
                if (options.SkipNullsFlag)
                    return t => t != null;
                return null;
            }
        }

        #endregion
    }
}
