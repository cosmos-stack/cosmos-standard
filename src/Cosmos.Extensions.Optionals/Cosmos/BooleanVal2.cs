using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.UnionTypes;

namespace Cosmos
{
    public class BooleanVal2 : UnionOf<BooleanVal2.True, BooleanVal2.False>
    {
        private BooleanVal2(UnionType<True, False> input) : base(input) { }

        #region Values

        public class True : ValueOf<bool, True>
        {
            public static True Instance { get; } = From(true);

            public static implicit operator bool(True _) => true;
        }

        public class False : ValueOf<bool, False>
        {
            public static False Instance { get; } = From(false);

            public static implicit operator bool(False _) => false;
        }

        #endregion

        #region Value Shortcut

        public static bool TrueValue => true;

        public static bool FalseValue => false;

        #endregion

        #region Value Instances

        public static BooleanVal2 TrueVal { get; } = True.Instance;

        public static BooleanVal2 FalseVal { get; } = False.Instance;

        #endregion

        #region Implicit Opts

        public static implicit operator BooleanVal2(True input) => new(input);

        public static implicit operator BooleanVal2(False input) => new(input);

        public static implicit operator BooleanVal2(bool value) => new(X(value));

        public static implicit operator bool(BooleanVal2 value)
        {
            if (value.IsT0()) return value.AsT0();
            if (value.IsT1()) return value.AsT1();
            return false;
        }

        #endregion

        #region Static Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UnionType<True, False> X(bool v)
        {
            if (v)
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
        public static bool And(bool left, bool right)
        {
            return left && right;
        }

        /// <summary>
        /// And operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="rights"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool And(bool left, params bool[] rights)
        {
            return left && rights.All(x => x);
        }

        /// <summary>
        /// Or operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Or(bool left, bool right)
        {
            return left || right;
        }

        /// <summary>
        /// Or operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="rights"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Or(bool left, params bool[] rights)
        {
            return left || rights.Any(x => x);
        }

        /// <summary>
        /// Same operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Same(bool left, bool right)
        {
            return left == right;
        }

        #endregion
    }

    public static class BooleanVal2Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal2 ToBooleanVal2(this bool value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal2 ToBooleanVal2(this bool? value) => value.HasValue ? value.Value : BooleanVal2.FalseVal;
    }
}