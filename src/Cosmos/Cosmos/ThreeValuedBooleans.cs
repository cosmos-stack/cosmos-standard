namespace Cosmos
{
    /// <summary>
    /// Three value boolean
    /// </summary>
    public static class ThreeValuedBooleans
    {
        /// <summary>
        /// True
        /// </summary>
        public static bool? True => true;

        /// <summary>
        /// False
        /// </summary>
        public static bool? False => false;

        /// <summary>
        /// Default
        /// </summary>
        public static bool? Default => null;

        /// <summary>
        /// And operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
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
            if (rights == null) return left.Value;

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
            if (rights == null) return result;

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
    }
}