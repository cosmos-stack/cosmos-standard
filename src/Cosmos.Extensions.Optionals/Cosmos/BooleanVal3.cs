using System.Runtime.CompilerServices;
using Cosmos.UnionTypes;

namespace Cosmos
{
    public class BooleanVal3 : UnionOf<BooleanVal3.True, BooleanVal3.False, BooleanVal3.Null>
    {
        private BooleanVal3(UnionType<True, False, Null> input) : base(input) { }

        #region Values

        public class True : ValueOf<bool?, True>
        {
            public static True Instance { get; } = From(true);

            public static implicit operator bool?(True _) => true;
        }

        public class False : ValueOf<bool?, False>
        {
            public static False Instance { get; } = From(false);

            public static implicit operator bool?(False _) => false;
        }

        public class Null : ValueOf<bool?, Null>
        {
            public static Null Instance { get; } = From(null);

            public static implicit operator bool?(Null _) => null;
        }

        #endregion

        #region Value Shortcut

        public static bool? TrueValue => true;

        public static bool? FalseValue => false;

        public static bool? NullValue => null;

        public static BooleanVal3 Default => Null.Instance;

        #endregion

        #region Value Instances

        public static BooleanVal3 TrueVal { get; } = True.Instance;

        public static BooleanVal3 FalseVal { get; } = False.Instance;

        public static BooleanVal3 NullVal { get; } = Null.Instance;

        #endregion

        #region Implicit Opts

        public static implicit operator BooleanVal3(True input) => new(input);

        public static implicit operator BooleanVal3(False input) => new(input);

        public static implicit operator BooleanVal3(Null input) => new(input);

        public static implicit operator BooleanVal3(bool? value) => new(X(value));

        public static implicit operator bool?(BooleanVal3 value)
        {
            if (value is null) return null;
            if (value.IsT0()) return value.AsT0();
            if (value.IsT1()) return value.AsT1();
            if (value.IsT2()) return value.AsT2();
            return null;
        }

        #endregion

        #region Static Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UnionType<True, False, Null> X(bool? v)
        {
            if (v is null)
                return Null.Instance;
            if (v.Value)
                return True.Instance;
            return False.Instance;
        }

        /// <summary>
        /// And operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool And(bool? left, bool? right)
        {
            if (left.HasValue && right.HasValue)
                return left.Value && right.Value;
            return false;
        }

        /// <summary>
        /// And operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="rights"></param>
        /// <returns></returns>
        public static bool And(bool? left, params bool?[] rights)
        {
            if (!left.HasValue) return false;
            if (rights is null) return left.Value;

            var result = left.Value;
            for (var i = 0; i < rights.Length; i++)
            {
                result = And(result, rights[i]);
                if (!result) break;
            }

            return result;
        }

        /// <summary>
        /// Or operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool Or(bool? left, bool? right)
        {
            if (left.HasValue && right.HasValue)
                return left.Value || right.Value;
            if (left.HasValue)
                return left.Value;
            if (right.HasValue)
                return right.Value;
            return false;
        }

        /// <summary>
        /// Or operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="rights"></param>
        /// <returns></returns>
        public static bool Or(bool? left, params bool?[] rights)
        {
            var result = left.HasValue ? left.Value : false;
            if (rights is null) return result;

            for (var i = 0; i < rights.Length; i++)
            {
                result = Or(result, rights[i]);
            }

            return result;
        }

        /// <summary>
        /// Same operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool Same(bool? left, bool? right)
        {
            if (left.HasValue && right.HasValue)
                return left.Value && right.Value;
            if (!left.HasValue && !right.HasValue)
                return true;
            return false;
        }

        #endregion
    }

    public static class BooleanVal3Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 ToBooleanVal3(this bool value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 ToBooleanVal3(this bool? value) => value;
    }
}