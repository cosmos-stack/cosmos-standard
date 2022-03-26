namespace Cosmos.Optionals.Internals;

internal static class CompareHelper
{
    public static int Compare<T>(T left, T right, int offset)
    {
        return (int) Math.Pow(10, offset) * Comparer<T>.Default.Compare(left, right);
    }

    public static int Calc(params int[] numbers)
    {
        var v = numbers.Sum();
        return v == 0 ? 0 : v > 0 ? 1 : -1;
    }
}