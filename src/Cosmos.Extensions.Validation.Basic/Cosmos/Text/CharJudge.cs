namespace Cosmos.Text
{
    public static class CharJudge
    {
        /// <summary>
        /// To judge whether the char value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(char value, char left, char right) => value >= left && value <= right;
    }
}