using System.Net;

namespace Cosmos.Net;

public static class IpConvert
{
    #region IPV4

    public static uint ConvertIPv4ToUInt32(IPAddress ipAddress)
    {
        var bytes = ipAddress.GetAddressBytes();
        var uints = new uint[4];
        for (var i = 0; i < bytes.Length; i++)
        {
            uints[i] = (uint)bytes[i] << (8 * (3 - i));
        }

        return uints[0] | uints[1] | uints[2] | uints[3];
    }

    public static uint ConvertIPv4ToUInt32(string ipAddress)
    {
        return ConvertIPv4ToUInt32(IPAddress.Parse(ipAddress));
    }

    public static IPAddress ConvertUInt32ToIPv4(uint ip)
    {
        var bytes = new byte[4];
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] = (byte)(ip >> (8 * (3 - i)));
        }

        return new IPAddress(bytes);
    }

    public static string ConvertUInt32ToIPv4Str(uint ip)
    {
        return ConvertUInt32ToIPv4(ip).ToString();
    }

    public static byte[] ConvertUInt32ToIPv4Bytes(uint ip)
    {
        return ConvertUInt32ToIPv4(ip).GetAddressBytes();
    }

    public static long ConvertIPv4ToInt64(IPAddress ipAddress)
    {
        return ConvertIPv4ToInt64Impl(ipAddress.ToString().Split('.'));
    }

    public static long ConvertIPv4ToInt64(string ipAddress)
    {
        var ret = 0L;
        if (ipAddress.Contains(':'))
            return ret;
        return ConvertIPv4ToInt64Impl(ipAddress.Split('.'));
    }

    public static IPAddress ConvertInt64ToIPv4(long ip)
    {
        var bytes = new byte[4];
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] = (byte)(ip >> (8 * (3 - i)));
        }

        return new IPAddress(bytes);
    }

    public static string ConvertInt64ToIPv4Str(long ip)
    {
        return $"{(ip >> 24) & 0xFF}.{(ip >> 16) & 0xFF}.{(ip >> 8) & 0xFF}.{ip & 0xFF}";
    }

    public static byte[] ConvertInt64ToIPv4Bytes(long ip)
    {
        return ConvertInt64ToIPv4(ip).GetAddressBytes();
    }

    private static long ConvertIPv4ToInt64Impl(string[] ipParts)
    {
        if (ipParts.Length != 4)
            return 0L;
        var lIps = new long[4];
        for (var i = 0; i < ipParts.Length; i++)
        {
            if (!(long.TryParse(ipParts[i], out lIps[i]) && lIps[i] >= 0 && lIps[i] <= 255))
                return 0L;
            lIps[i] = (lIps[i] << (8 * (3 - i))) & (0xFF << (8 * (3 - i)));
        }

        return (lIps[0] | lIps[1] | lIps[2] | lIps[3]) & 0xFFFFFFFFL;
    }

    public static byte[] ConvertIPv4ToBytes(IPAddress ipAddress)
    {
        return ipAddress.GetAddressBytes();
    }

    public static byte[] ConvertIPv4ToBytes(string ipAddress)
    {
        return IPAddress.Parse(ipAddress).GetAddressBytes();
    }

    #endregion

    #region IPV6

    public static long ConvertIPv6ToInt64(IPAddress ipAddress)
    {
        var bytes = ipAddress.GetAddressBytes();
        Array.Reverse(bytes);
        return BitConverter.ToInt64(bytes, 8);
    }

    public static long ConvertIPv6ToInt64(string ipAddress)
    {
        return ConvertIPv6ToInt64(IPAddress.Parse(ipAddress));
    }

    public static IPAddress ConvertInt64ToIPv6(long ip)
    {
        var bytes = BitConverter.GetBytes(ip);
        var a0 = BitConverter.ToUInt16(bytes, 0);
        var a1 = BitConverter.ToUInt16(bytes, 2);
        var a2 = BitConverter.ToUInt16(bytes, 4);
        var a3 = BitConverter.ToUInt16(bytes, 6);
        var ipStrSeg = Convert.ToString(a3, 16) + ":" +
                       Convert.ToString(a2, 16) + ":" +
                       Convert.ToString(a1, 16) + ":" +
                       Convert.ToString(a0, 16) + "::";
        return IPAddress.Parse(ipStrSeg);
    }

    public static string ConvertInt64ToIPv6Str(long ip)
    {
        return ConvertInt64ToIPv6(ip).ToString();
    }

    public static byte[] ConvertInt64ToIPv6Bytes(long ip)
    {
        return ConvertInt64ToIPv6(ip).GetAddressBytes();
    }

    public static ulong ConvertIPv6ToUInt64(IPAddress ipAddress)
    {
        var bytes = ipAddress.GetAddressBytes();
        Array.Reverse(bytes);

        var ret = 0UL;

        if (bytes.Length > 8)
        {
            //IPV6
            ret = BitConverter.ToUInt64(bytes, 0);
            ret <<= 64;
            ret += BitConverter.ToUInt64(bytes, 8); // r = r + x
        }
        else
        {
            //IPV4
            ret = BitConverter.ToUInt64(bytes, 0);
        }

        return ret;
    }

    public static ulong ConvertIPv6ToUInt64(string ipAddress)
    {
        return ConvertIPv6ToUInt64(IPAddress.Parse(ipAddress));
    }

    // public static IPAddress ConvertUInt64ToIPv6(ulong ip)
    // {
    //     var bytes = BitConverter.GetBytes(ip);
    //     if (bytes.Length > 8)
    //     {
    //         //IPV6
    //         ip >>= 64;
    //         BitConverter.GetBytes()
    //     }
    //     else
    //     {
    //         //IPV4
    //         Array.Reverse(bytes);
    //         return new IPAddress(bytes);
    //     }
    // }

    #endregion
}