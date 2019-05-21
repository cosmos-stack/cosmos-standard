using System;
using System.Collections.Generic;

namespace Cosmos.Guava
{
    public partial class Joiner : IGuavaJoiner
    {
        private readonly string _on;

        private JoinerOptions Options { get; set; } = new JoinerOptions();

        private Joiner(string on)
        {
            _on = on;
        }

        #region SkipNulls

        IGuavaJoiner IGuavaJoiner.SkipNulls()
        {
            Options.SetSkipNulls();
            return this;
        }

        #endregion

        #region UseForNull

        IGuavaJoiner IGuavaJoiner.UseForNull(string value)
        {
            Options.SetReplacer<string>(s => value);
            return this;
        }

        IGuavaJoiner IGuavaJoiner.UseForNull(Func<string, string> valueFunc)
        {
            Options.SetReplacer(valueFunc);
            return this;
        }

        #endregion

        #region WithKeyValueSeparator

        public IGuavaMapJoiner WithKeyValueSeparator(string separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        public IGuavaMapJoiner WithKeyValueSeparator(char separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        #endregion

        #region Join - List
        string IGuavaJoiner.Join(IEnumerable<string> list)
        {
            return list.JoinToString(_on, JoinerUtils.GetStringPredicate(Options), Options.GetReplacer<string>());
        }

        string IGuavaJoiner.Join<T>(IEnumerable<T> list, ITypeConverter<T, string> converter)
        {
            return list.JoinToString(_on, JoinerUtils.GetObjectPredicate<T>(Options), converter, replaceFunc: Options.GetReplacer<T>());
        }

        string IGuavaJoiner.Join<T>(IEnumerable<T> list, Func<T, string> to)
        {
            return list.JoinToString(_on, JoinerUtils.GetObjectPredicate<T>(Options), to, Options.GetReplacer<T>());
        }

        string IGuavaJoiner.Join(string str1, params string[] restStrings)
        {
            var list = new List<string>() { str1 };
            list.AddRange(restStrings);
            return ((IGuavaJoiner)this).Join(list);
        }

        string IGuavaJoiner.Join<T>(ITypeConverter<T, string> converter, T item1, params T[] restItems)
        {
            var list = new List<T> { item1 };
            list.AddRange(restItems);
            return ((IGuavaJoiner)this).Join(list, converter);
        }

        string IGuavaJoiner.Join<T>(Func<T, string> to, T item1, params T[] restItems)
        {
            var list = new List<T> { item1 };
            list.AddRange(restItems);
            return ((IGuavaJoiner)this).Join(list, to);
        }

        #endregion

        #region On

        public static IGuavaJoiner On(string on)
        {
            return new Joiner(on);
        }

        public static IGuavaJoiner On(char on)
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

    public interface IGuavaJoiner
    {
        IGuavaJoiner SkipNulls();
        IGuavaJoiner UseForNull(string value);
        IGuavaJoiner UseForNull(Func<string, string> valueFunc);
        IGuavaMapJoiner WithKeyValueSeparator(string separator);
        IGuavaMapJoiner WithKeyValueSeparator(char separator);
        string Join(IEnumerable<string> list);
        string Join(string str1, params string[] restStrings);
        string Join<T>(IEnumerable<T> list, ITypeConverter<T, string> converter);
        string Join<T>(IEnumerable<T> list, Func<T, string> to);
        string Join<T>(ITypeConverter<T, string> converter, T item1, params T[] restItems);
        string Join<T>(Func<T, string> to, T item1, params T[] restItems);
    }

    public enum SkipNullType
    {
        Nothing,
        WhenBoth,
        WhenEither,
        WhenKeyIsNull,
        WhenValueIsNull
    }
}
