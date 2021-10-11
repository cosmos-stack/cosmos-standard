﻿using System;

namespace TinyMapper.Core.DataStructures
{
    internal struct Option<T>
    {
        public Option(T value, bool hasValue = true)
        {
            HasValue = hasValue;
            Value = value;
        }

        public static Option<T> Empty { get; } = new Option<T>(default, false);

        public bool HasNoValue => !HasValue;

        public bool HasValue { get; }

        public T Value { get; }

        public Option<T> Match(Func<T, bool> predicate, Action<T> action)
        {
            if (HasNoValue)
            {
                return Empty;
            }

            if (predicate(Value))
            {
                action(Value);
            }

            return this;
        }

        public Option<T> MatchType<TTarget>(Action<TTarget> action)
        where TTarget : T
        {
            if (HasNoValue)
            {
                return Empty;
            }

            if (Value.GetType() == typeof(TTarget))
            {
                action((TTarget) Value);
            }

            return this;
        }

        public Option<T> ThrowOnEmpty<TException>()
        where TException : Exception, new()
        {
            if (HasValue)
            {
                return this;
            }

            throw Error.Type<TException>();
        }

        public Option<T> ThrowOnEmpty<TException>(Func<TException> func)
        where TException : Exception
        {
            if (HasValue)
            {
                return this;
            }

            throw func();
        }
    }
}