using System.Runtime.CompilerServices;

namespace CosmosStack.Text
{
    /// <summary>
    /// Char Judgement <br />
    /// 字符检查器
    /// </summary>
    public static class CharJudge
    {
        /// <summary>
        /// To judge whether the char value is between left and right. <br />
        /// 判断给定的字符是否包含在左值和右值之间
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBetween(char value, char left, char right) => value >= left && value <= right;
    }
}