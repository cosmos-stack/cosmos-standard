namespace CosmosStandardUT.Helpers;

internal  static class ArrayCreator
{
    public static T[] Of<T>(params T[] ts)
    {
        return ts;
    }
}