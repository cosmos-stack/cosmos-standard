using System;
using System.Collections.Generic;
using Cosmos.Optionals.Internals;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Maybe
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="T11"></typeparam>
    /// <typeparam name="T12"></typeparam>
    /// <typeparam name="T13"></typeparam>
    /// <typeparam name="T14"></typeparam>
    /// <typeparam name="T15"></typeparam>
    /// <typeparam name="T16"></typeparam>
    /// <typeparam name="T17"></typeparam>
    [Serializable]
    public readonly struct Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> :
        IOptionalImpl<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>>,
        IEquatable<Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>>,
        IComparable<Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>>
    {
        private readonly Maybe<T1> _o1;
        private readonly Maybe<T2> _o2;
        private readonly Maybe<T3> _o3;
        private readonly Maybe<T4> _o4;
        private readonly Maybe<T5> _o5;
        private readonly Maybe<T6> _o6;
        private readonly Maybe<T7> _o7;
        private readonly Maybe<T8> _o8;
        private readonly Maybe<T9> _o9;
        private readonly Maybe<T10> _o10;
        private readonly Maybe<T11> _o11;
        private readonly Maybe<T12> _o12;
        private readonly Maybe<T13> _o13;
        private readonly Maybe<T14> _o14;
        private readonly Maybe<T15> _o15;
        private readonly Maybe<T16> _o16;
        private readonly Maybe<T17> _o17;
        private readonly bool _hasValue;
        private readonly IReadOnlyDictionary<string, int> _optionalIndexCache;

        internal Maybe(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14,
            T15 value15, T16 value16, T17 value17, bool hasValue)
        {
            _o1 = Optional.From(value1);
            _o2 = Optional.From(value2);
            _o3 = Optional.From(value3);
            _o4 = Optional.From(value4);
            _o5 = Optional.From(value5);
            _o6 = Optional.From(value6);
            _o7 = Optional.From(value7);
            _o8 = Optional.From(value8);
            _o9 = Optional.From(value9);
            _o10 = Optional.From(value10);
            _o11 = Optional.From(value11);
            _o12 = Optional.From(value12);
            _o13 = Optional.From(value13);
            _o14 = Optional.From(value14);
            _o15 = Optional.From(value15);
            _o16 = Optional.From(value16);
            _o17 = Optional.From(value17);
            _hasValue = hasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(17);
        }

        internal Maybe(T1 value1, string key1, T2 value2, string key2, T3 value3, string key3, T4 value4, string key4, T5 value5, string key5, T6 value6, string key6,
            T7 value7, string key7, T8 value8, string key8, T9 value9, string key9, T10 value10, string key10, T11 value11, string key11, T12 value12, string key12,
            T13 value13, string key13, T14 value14, string key14, T15 value15, string key15, T16 value16, string key16, T17 value17, string key17, bool hasValue)
        {
            _o1 = Optional.From(value1);
            _o2 = Optional.From(value2);
            _o3 = Optional.From(value3);
            _o4 = Optional.From(value4);
            _o5 = Optional.From(value5);
            _o6 = Optional.From(value6);
            _o7 = Optional.From(value7);
            _o8 = Optional.From(value8);
            _o9 = Optional.From(value9);
            _o10 = Optional.From(value10);
            _o11 = Optional.From(value11);
            _o12 = Optional.From(value12);
            _o13 = Optional.From(value13);
            _o14 = Optional.From(value14);
            _o15 = Optional.From(value15);
            _o16 = Optional.From(value16);
            _o17 = Optional.From(value17);
            _hasValue = hasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(17, key1, key2, key3, key4, key5, key6, key7, key8, key9, key10, key11, key12, key13, key14, key15, key16, key17);
        }

        internal Maybe(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Maybe<T4> maybe4, Maybe<T5> maybe5, Maybe<T6> maybe6, Maybe<T7> maybe7, Maybe<T8> maybe8, Maybe<T9> maybe9, Maybe<T10> maybe10, Maybe<T11> maybe11, Maybe<T12> maybe12,
            Maybe<T13> maybe13, Maybe<T14> maybe14, Maybe<T15> maybe15, Maybe<T16> maybe16, Maybe<T17> maybe17)
        {
            _o1 = maybe1;
            _o2 = maybe2;
            _o3 = maybe3;
            _o4 = maybe4;
            _o5 = maybe5;
            _o6 = maybe6;
            _o7 = maybe7;
            _o8 = maybe8;
            _o9 = maybe9;
            _o10 = maybe10;
            _o11 = maybe11;
            _o12 = maybe12;
            _o13 = maybe13;
            _o14 = maybe14;
            _o15 = maybe15;
            _o16 = maybe16;
            _o17 = maybe17;
            _hasValue = _o1.HasValue && _o2.HasValue && _o3.HasValue && _o4.HasValue && _o5.HasValue && _o6.HasValue && _o7.HasValue && _o8.HasValue && _o9.HasValue && _o10.HasValue && _o11.HasValue && _o12.HasValue && _o13.HasValue &&
                        _o14.HasValue && _o15.HasValue && _o16.HasValue && _o17.HasValue;
            _optionalIndexCache = NamedMaybeHelper.CreateIndexCache(17, maybe1.Key, maybe2.Key, maybe3.Key, maybe4.Key, maybe5.Key, maybe6.Key, maybe7.Key, maybe8.Key, maybe9.Key, maybe10.Key, maybe11.Key, maybe12.Key,
                maybe13.Key, maybe14.Key, maybe15.Key, maybe16.Key, maybe17.Key);
        }

        /// <summary>
        /// Gets value of he first item
        /// </summary>
        public T1 Item1 => _o1.Value;

        /// <summary>
        /// Gets value of he second item
        /// </summary>
        public T2 Item2 => _o2.Value;

        /// <summary>
        /// Gets value of he third item
        /// </summary>
        public T3 Item3 => _o3.Value;

        /// <summary>
        /// Gets value of he forth item
        /// </summary>
        public T4 Item4 => _o4.Value;

        /// <summary>
        /// Gets value of he fifth item
        /// </summary>
        public T5 Item5 => _o5.Value;

        /// <summary>
        /// Gets value of he sixth item
        /// </summary>
        public T6 Item6 => _o6.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T7 Item7 => _o7.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T8 Item8 => _o8.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T9 Item9 => _o9.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T10 Item10 => _o10.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T11 Item11 => _o11.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T12 Item12 => _o12.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T13 Item13 => _o13.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T14 Item14 => _o14.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T15 Item15 => _o15.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T16 Item16 => _o16.Value;

        /// <summary>
        /// Gets value of he seventh item
        /// </summary>
        public T17 Item17 => _o17.Value;

        /// <inheritdoc />
        public (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) Value => (Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10, Item11, Item12, Item13, Item14, Item15, Item16, Item17);

        /// <inheritdoc />
        public bool HasValue => _hasValue && _o1.HasValue && _o2.HasValue && _o3.HasValue && _o4.HasValue && _o5.HasValue && _o6.HasValue && _o7.HasValue && _o8.HasValue && _o9.HasValue && _o10.HasValue && _o11.HasValue && _o12.HasValue &&
                                _o13.HasValue && _o14.HasValue && _o15.HasValue && _o16.HasValue && _o17.HasValue;

        /// <inheritdoc />
        public string Key => _o17.Key;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType1 => _o1.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the second item
        /// </summary>
        public Type UnderlyingType2 => _o2.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the third item
        /// </summary>
        public Type UnderlyingType3 => _o3.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the forth item
        /// </summary>
        public Type UnderlyingType4 => _o4.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the fifth item
        /// </summary>
        public Type UnderlyingType5 => _o5.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the sixth item
        /// </summary>
        public Type UnderlyingType6 => _o6.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the seventh item
        /// </summary>
        public Type UnderlyingType7 => _o7.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the seventh item
        /// </summary>
        public Type UnderlyingType8 => _o8.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the seventh item
        /// </summary>
        public Type UnderlyingType9 => _o9.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType10 => _o10.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType11 => _o11.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType12 => _o12.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType13 => _o13.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType14 => _o14.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType15 => _o15.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType16 => _o16.UnderlyingType;

        /// <summary>
        /// Gets UnderlyingType of the first item
        /// </summary>
        public Type UnderlyingType17 => _o17.UnderlyingType;

        /// <inheritdoc />
        public Type UnderlyingType => _o17.UnderlyingType;

        /// <summary>
        /// Gets all underlying type for this <see cref="Maybe{T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,T17}"/>.
        /// </summary>
        public (Type, Type, Type, Type, Type, Type, Type, Type, Type, Type, Type, Type, Type, Type, Type, Type, Type) UnderlyingTypes =>
            (UnderlyingType1, UnderlyingType2, UnderlyingType3, UnderlyingType4, UnderlyingType5, UnderlyingType6, UnderlyingType7, UnderlyingType8, UnderlyingType9, UnderlyingType10, UnderlyingType11, UnderlyingType12, UnderlyingType13,
             UnderlyingType14, UnderlyingType15, UnderlyingType16, UnderlyingType17);

        #region Index

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="index"></param>
        public object this[int index]
        {
            get
            {
                return index switch
                {
                    0 => _o1.Value,
                    1 => _o2.Value,
                    2 => _o3.Value,
                    3 => _o4.Value,
                    4 => _o5.Value,
                    5 => _o6.Value,
                    6 => _o7.Value,
                    7 => _o8.Value,
                    8 => _o9.Value,
                    9 => _o10.Value,
                    10 => _o11.Value,
                    11 => _o12.Value,
                    12 => _o13.Value,
                    13 => _o14.Value,
                    14 => _o15.Value,
                    15 => _o16.Value,
                    16 => _o17.Value,
                    _ => throw new IndexOutOfRangeException($"Index value '{index}' must between [0, 17).")
                };
            }
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="key"></param>
        public object this[string key]
            => _optionalIndexCache.TryGetValue(key, out var index)
                ? this[index]
                : default;

        #endregion

        #region Deconstruct

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        /// <param name="item6"></param>
        /// <param name="item7"></param>
        /// <param name="item8"></param>
        /// <param name="item9"></param>
        /// <param name="item10"></param>
        /// <param name="item11"></param>
        /// <param name="item12"></param>
        /// <param name="item13"></param>
        /// <param name="item14"></param>
        /// <param name="item15"></param>
        /// <param name="item16"></param>
        /// <param name="item17"></param>
        public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4, out T5 item5, out T6 item6, out T7 item7, out T8 item8, out T9 item9, out T10 item10, out T11 item11, out T12 item12,
            out T13 item13, out T14 item14, out T15 item15, out T16 item16, out T17 item17)
        {
            item1 = _o1.Value;
            item2 = _o2.Value;
            item3 = _o3.Value;
            item4 = _o4.Value;
            item5 = _o5.Value;
            item6 = _o6.Value;
            item7 = _o7.Value;
            item8 = _o8.Value;
            item9 = _o9.Value;
            item10 = _o10.Value;
            item11 = _o11.Value;
            item12 = _o12.Value;
            item13 = _o13.Value;
            item14 = _o14.Value;
            item15 = _o15.Value;
            item16 = _o16.Value;
            item17 = _o17.Value;
        }

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="maybe1"></param>
        /// <param name="maybe2"></param>
        /// <param name="maybe3"></param>
        /// <param name="maybe4"></param>
        /// <param name="maybe5"></param>
        /// <param name="maybe6"></param>
        /// <param name="maybe7"></param>
        /// <param name="maybe8"></param>
        /// <param name="maybe9"></param>
        /// <param name="maybe10"></param>
        /// <param name="maybe11"></param>
        /// <param name="maybe12"></param>
        /// <param name="maybe13"></param>
        /// <param name="maybe14"></param>
        /// <param name="maybe15"></param>
        /// <param name="maybe16"></param>
        /// <param name="maybe17"></param>
        public void Deconstruct(out Maybe<T1> maybe1, out Maybe<T2> maybe2, out Maybe<T3> maybe3, out Maybe<T4> maybe4, out Maybe<T5> maybe5, out Maybe<T6> maybe6,
            out Maybe<T7> maybe7, out Maybe<T8> maybe8, out Maybe<T9> maybe9, out Maybe<T10> maybe10, out Maybe<T11> maybe11, out Maybe<T12> maybe12,
            out Maybe<T13> maybe13, out Maybe<T14> maybe14, out Maybe<T15> maybe15, out Maybe<T16> maybe16, out Maybe<T17> maybe17)
        {
            maybe1 = _o1;
            maybe2 = _o2;
            maybe3 = _o3;
            maybe4 = _o4;
            maybe5 = _o5;
            maybe6 = _o6;
            maybe7 = _o7;
            maybe8 = _o8;
            maybe9 = _o9;
            maybe10 = _o10;
            maybe11 = _o11;
            maybe12 = _o12;
            maybe13 = _o13;
            maybe14 = _o14;
            maybe15 = _o15;
            maybe16 = _o16;
            maybe17 = _o17;
        }

        #endregion

        #region Equals

        /// <inheritdoc />
        public bool Equals((T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) other)
        {
            return Item1.Equals(other.Item1) &&
                   Item2.Equals(other.Item2) &&
                   Item3.Equals(other.Item3) &&
                   Item4.Equals(other.Item4) &&
                   Item5.Equals(other.Item5) &&
                   Item6.Equals(other.Item6) &&
                   Item7.Equals(other.Item7) &&
                   Item8.Equals(other.Item8) &&
                   Item9.Equals(other.Item9) &&
                   Item10.Equals(other.Item10) &&
                   Item11.Equals(other.Item11) &&
                   Item12.Equals(other.Item12) &&
                   Item13.Equals(other.Item13) &&
                   Item14.Equals(other.Item14) &&
                   Item15.Equals(other.Item15) &&
                   Item16.Equals(other.Item16) &&
                   Item17.Equals(other.Item17);
        }

        /// <inheritdoc />
        public bool Equals(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> other)
        {
            if (!HasValue && !other.HasValue)
                return true;
            if (HasValue && other.HasValue)
                return EqualityComparer<T1>.Default.Equals(Item1, other.Item1) &&
                       EqualityComparer<T2>.Default.Equals(Item2, other.Item2) &&
                       EqualityComparer<T3>.Default.Equals(Item3, other.Item3) &&
                       EqualityComparer<T4>.Default.Equals(Item4, other.Item4) &&
                       EqualityComparer<T5>.Default.Equals(Item5, other.Item5) &&
                       EqualityComparer<T6>.Default.Equals(Item6, other.Item6) &&
                       EqualityComparer<T7>.Default.Equals(Item7, other.Item7) &&
                       EqualityComparer<T8>.Default.Equals(Item8, other.Item8) &&
                       EqualityComparer<T9>.Default.Equals(Item9, other.Item9) &&
                       EqualityComparer<T10>.Default.Equals(Item10, other.Item10) &&
                       EqualityComparer<T11>.Default.Equals(Item11, other.Item11) &&
                       EqualityComparer<T12>.Default.Equals(Item12, other.Item12) &&
                       EqualityComparer<T13>.Default.Equals(Item13, other.Item13) &&
                       EqualityComparer<T14>.Default.Equals(Item14, other.Item14) &&
                       EqualityComparer<T15>.Default.Equals(Item15, other.Item15) &&
                       EqualityComparer<T16>.Default.Equals(Item16, other.Item16) &&
                       EqualityComparer<T17>.Default.Equals(Item17, other.Item17);
            return false;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> maybe && Equals(maybe);

        #endregion

        #region Compare to

        /// <inheritdoc />
        public int CompareTo((T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) other)
        {
            if (!HasValue) return -1;
            var v = new[]
            {
                CompareHelper.Compare(Item1, other.Item1, 17),
                CompareHelper.Compare(Item2, other.Item2, 16),
                CompareHelper.Compare(Item3, other.Item3, 15),
                CompareHelper.Compare(Item4, other.Item4, 14),
                CompareHelper.Compare(Item5, other.Item5, 13),
                CompareHelper.Compare(Item6, other.Item6, 12),
                CompareHelper.Compare(Item7, other.Item7, 11),
                CompareHelper.Compare(Item8, other.Item8, 10),
                CompareHelper.Compare(Item9, other.Item9, 9),
                CompareHelper.Compare(Item10, other.Item10, 8),
                CompareHelper.Compare(Item11, other.Item11, 7),
                CompareHelper.Compare(Item12, other.Item12, 6),
                CompareHelper.Compare(Item13, other.Item13, 5),
                CompareHelper.Compare(Item14, other.Item14, 4),
                CompareHelper.Compare(Item15, other.Item15, 3),
                CompareHelper.Compare(Item16, other.Item16, 2),
                CompareHelper.Compare(Item17, other.Item17, 1)
            };
            return CompareHelper.Calc(v);
        }

        /// <inheritdoc />
        public int CompareTo(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> other)
        {
            if (HasValue && !other.HasValue) return 1;
            if (!HasValue && other.HasValue) return -1;
            var v = new[]
            {
                CompareHelper.Compare(Item1, other.Item1, 17),
                CompareHelper.Compare(Item2, other.Item2, 16),
                CompareHelper.Compare(Item3, other.Item3, 15),
                CompareHelper.Compare(Item4, other.Item4, 14),
                CompareHelper.Compare(Item5, other.Item5, 13),
                CompareHelper.Compare(Item6, other.Item6, 12),
                CompareHelper.Compare(Item7, other.Item7, 11),
                CompareHelper.Compare(Item8, other.Item8, 10),
                CompareHelper.Compare(Item9, other.Item9, 9),
                CompareHelper.Compare(Item10, other.Item10, 8),
                CompareHelper.Compare(Item11, other.Item11, 7),
                CompareHelper.Compare(Item12, other.Item12, 6),
                CompareHelper.Compare(Item13, other.Item13, 5),
                CompareHelper.Compare(Item14, other.Item14, 4),
                CompareHelper.Compare(Item15, other.Item15, 3),
                CompareHelper.Compare(Item16, other.Item16, 2),
                CompareHelper.Compare(Item17, other.Item17, 1)
            };
            return CompareHelper.Calc(v);
        }

        #endregion

        #region ==/!=

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> left, Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> right) => left.Equals(right);

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> left, Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> right) => !left.Equals(right);

        #endregion

        #region < <= > >=

        /// <summary>
        /// Determines if an optional is less than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> left, Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines if an optional is less than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> left, Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines if an optional is greater than another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> left, Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines if an optional is greater than or equal to another optional.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> left, Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> right) => left.CompareTo(right) >= 0;

        #endregion

        #region Operator

        /// <summary>
        /// Convert maybe to tuple
        /// </summary>
        /// <param name="maybe"></param>
        /// <returns></returns>
        public static implicit operator (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> maybe)
        {
            return maybe.Value;
        }

        /// <summary>
        /// Convert maybe from tuple
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public static explicit operator Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>((T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) tuple)
        {
            return Optional.From(tuple);
        }

        #endregion

        #region ToString

        /// <inheritdoc />
        public override string ToString()
        {
            return HasValue
                ? $"Some(Item1:{Item1},Item2:{Item2},Item3:{Item3},Item4:{Item4},Item5:{Item5},Item6:{Item6},Item7:{Item7},Item8:{Item8},Item9:{Item9},Item10:{Item10},Item11:{Item11},Item12:{Item12},Item13:{Item13},Item14:{Item14},Item15:{Item15},Item16:{Item16},Item17:{Item17})"
                : "None";
        }

        #endregion

        #region GetHashCode

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HasValue
                ? Value.GetHashCode()
                : 0;
        }

        #endregion

        #region Contains / Exists

        /// <inheritdoc />
        public bool Contains((T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) value)
        {
            return _o1.Contains(value.Item1) &&
                   _o2.Contains(value.Item2) &&
                   _o3.Contains(value.Item3) &&
                   _o4.Contains(value.Item4) &&
                   _o5.Contains(value.Item5) &&
                   _o6.Contains(value.Item6) &&
                   _o7.Contains(value.Item7) &&
                   _o8.Contains(value.Item8) &&
                   _o9.Contains(value.Item9) &&
                   _o10.Contains(value.Item10) &&
                   _o11.Contains(value.Item11) &&
                   _o12.Contains(value.Item12) &&
                   _o13.Contains(value.Item13) &&
                   _o14.Contains(value.Item14) &&
                   _o15.Contains(value.Item15) &&
                   _o16.Contains(value.Item16)&&
                   _o17.Contains(value.Item17);
        }

        /// <inheritdoc />
        public bool Exists(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && predicate(Value);
        }

        #endregion

        #region Value or

        /// <inheritdoc />
        public (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) ValueOr((T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) alternative)
        {
            return HasValue ? Value : alternative;
        }

        /// <inheritdoc />
        public (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) ValueOr(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? Value : alternativeFactory();
        }

        #endregion

        #region Or / Else

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Or((T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17) alternative)
        {
            return HasValue ? this : Optional.From(alternative);
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Or(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? this : Optional.From(alternativeFactory());
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Else(Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> alternativeMaybe)
        {
            return HasValue ? this : alternativeMaybe;
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Else(Func<Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> alternativeMaybeFactory)
        {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return HasValue ? this : alternativeMaybeFactory();
        }

        #endregion

        #region With exception

        /// <inheritdoc />
        public Either<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TException> WithException<TException>(TException exception)
        {
            return Match(
                someFactory: Optional.Some<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TException>,
                noneFactory: () => Optional.None<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TException>(exception));
        }

        /// <inheritdoc />
        public Either<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TException> WithException<TException>(Func<TException> exceptionFactory)
        {
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return Match(
                someFactory: Optional.Some<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TException>,
                noneFactory: () => Optional.None<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TException>(exceptionFactory()));
        }

        #endregion

        #region Match

        /// <inheritdoc />
        public TResult Match<TResult>(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TResult> someFactory, Func<TResult> noneFactory)
        {
            if (someFactory is null)
                throw new ArgumentNullException(nameof(someFactory));
            if (noneFactory is null)
                throw new ArgumentNullException(nameof(noneFactory));
            return HasValue ? someFactory(Value) : noneFactory();
        }

        /// <inheritdoc />
        public void Match(Action<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> someAct, Action noneAct)
        {
            if (someAct is null)
                throw new ArgumentNullException(nameof(someAct));
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (HasValue)
                someAct(Value);
            else
                noneAct();
        }

        /// <inheritdoc />
        public void MatchMaybe(Action<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> maybeAct)
        {
            if (maybeAct is null)
                throw new ArgumentNullException(nameof(maybeAct));
            if (HasValue)
                maybeAct(Value);
        }

        /// <inheritdoc />
        public void MatchNone(Action noneAct)
        {
            if (noneAct is null)
                throw new ArgumentNullException(nameof(noneAct));
            if (!HasValue)
                noneAct();
        }

        #endregion

        #region Map

        /// <inheritdoc />
        public Maybe<TResult> Map<TResult>(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), TResult> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: val => Optional.Some(mapping(val)),
                noneFactory: Optional.None<TResult>);
        }

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult>(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), Maybe<TResult>> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return Match(
                someFactory: mapping,
                noneFactory: Optional.None<TResult>);
        }

        /// <inheritdoc />
        public Maybe<TResult> FlatMap<TResult, TException>(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), Either<TResult, TException>> mapping)
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return FlatMap(val => mapping(val).WithoutException());
        }

        #endregion

        #region Filter

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Filter(bool condition)
        {
            return HasValue && !condition ? Nothing : this;
        }

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Filter(Func<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17), bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return HasValue && !predicate(Value) ? Nothing : this;
        }

        #endregion

        #region Not null

        /// <inheritdoc />
        public Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> NotNull()
        {
            return HasValue &&
                   _o1.Value is null &&
                   _o2.Value is null &&
                   _o3.Value is null &&
                   _o4.Value is null &&
                   _o5.Value is null &&
                   _o6.Value is null &&
                   _o7.Value is null &&
                   _o8.Value is null &&
                   _o9.Value is null &&
                   _o10.Value is null &&
                   _o11.Value is null &&
                   _o12.Value is null &&
                   _o13.Value is null &&
                   _o14.Value is null &&
                   _o15.Value is null &&
                   _o16.Value is null&&
                   _o17.Value is null
                ? Nothing
                : this;
        }

        #endregion

        #region To wrapped object

        /// <summary>
        /// To wrapped optional some
        /// </summary>
        /// <returns></returns>
        public Some<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> ToWrappedSome() => new(Value);

        /// <summary>
        /// To wrapped optional none
        /// </summary>
        /// <returns></returns>
        public None<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17)> ToWrappedNone() => new();

        #endregion

        /// <summary>
        /// Nothing
        /// </summary>
        public static Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Nothing => Optional.None<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>();
    }
}