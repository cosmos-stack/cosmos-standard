namespace Cosmos.Conversions;

public static class UnmanagedCastingExtensions
{
    public static unsafe byte[] CastToUnsafeBytes<TUnMan>(this TUnMan unmanagedObj) where TUnMan : unmanaged
    {
        var size = sizeof(TUnMan);
        var result = new byte[size];
        var p = (byte*)&unmanagedObj;
        for (var i = 0; i < size; i++)
            result[i] = *p++;
        return result;
    }
}