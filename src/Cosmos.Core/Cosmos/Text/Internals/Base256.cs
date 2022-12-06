namespace Cosmos.Text.Internals;
/*
 * Reference to:
 *	https://github.com/KvanTTT/BaseNcoding/blob/master/BaseNcoding/Base256.cs
 *	Author: KvanTTT (Ivan Kochurkin)
 *	License:
 *		Apache License 2.0
 *		https://github.com/KvanTTT/BaseNcoding/blob/master/LICENSE
 *
 */

internal class Base256 : BaseXCore
{
    public const string DefaultAlphabet =
        "!#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ ¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳĴĵĶķĸĹĺĻļĽľĿŀŁł";

    public const char DefaultSpecial = (char)0;

    public override bool HasSpecial => false;

    public Base256(string alphabet = DefaultAlphabet, char special = DefaultSpecial, Encoding textEncoding = null)
        : base(256, alphabet, special, textEncoding) { }

    public override string Encode(byte[] data)
    {
        if (data is null)
            return string.Empty;

        var result = new char[data.Length];

        for (var i = 0; i < data.Length; i++)
            result[i] = Alphabet[data[i]];

        return new string(result);
    }

    public override byte[] Decode(string data)
    {
        unchecked
        {
            if (string.IsNullOrEmpty(data))
                return Array.Empty<byte>();

            var result = new byte[data.Length];

            for (var i = 0; i < data.Length; i++)
                result[i] = (byte)InvAlphabet[data[i]];

            return result;
        }
    }
}