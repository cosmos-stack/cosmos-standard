using System.Net;
using Cosmos.Conversions;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsIpAddress")]
    public class StringConvBeIpAddressTypeTests
    {
        public StringConvBeIpAddressTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is IpAddress type or not test")]
        public void JudgingStringIsIpAddressTypeTest()
        {
            var type = typeof(IPAddress);
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is IpAddress type or not and ignore case test")]
        public void JudgingStringIsIpAddressTypeWithIgnoreCaseTest()
        {
            var type = typeof(IPAddress);
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is IpAddress type or not by generic type test")]
        public void JudgingStringIsIpAddressTypeByGenericTypeTest()
        {
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is<IPAddress>().ShouldBeTrue();
            text1.Is<IPAddress>().ShouldBeTrue();
            text2.Is<IPAddress>().ShouldBeTrue();
            text3.Is<IPAddress>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is IpAddress type or not by generic type and ignore case test")]
        public void JudgingStringIsIpAddressTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is<IPAddress>(Context).ShouldBeTrue();
            text1.Is<IPAddress>(Context).ShouldBeTrue();
            text2.Is<IPAddress>(Context).ShouldBeTrue();
            text3.Is<IPAddress>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is IpAddress type or not test")]
        public void JudgingNullOrEmptyStringIsIpAddressTypeTest()
        {
            var type = typeof(IPAddress);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeFalse();
            text5.Is(type).ShouldBeFalse();
            text6.Is(type).ShouldBeTrue();
            text7.Is(type).ShouldBeTrue();
            text8.Is(type).ShouldBeTrue();
            text9.Is(type).ShouldBeTrue();
            textA.Is(type).ShouldBeTrue();
            textB.Is(type).ShouldBeTrue();
            textC.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is IpAddress type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsIpAddressTypeWithIgnoreCaseTest()
        {
            var type = typeof(IPAddress);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
            text4.Is(type, Context).ShouldBeFalse();
            text5.Is(type, Context).ShouldBeFalse();
            text6.Is(type, Context).ShouldBeTrue();
            text7.Is(type, Context).ShouldBeTrue();
            text8.Is(type, Context).ShouldBeTrue();
            text9.Is(type, Context).ShouldBeTrue();
            textA.Is(type, Context).ShouldBeTrue();
            textB.Is(type, Context).ShouldBeTrue();
            textC.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is IpAddress type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsIpAddressTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.Is<IPAddress>().ShouldBeFalse();
            text1.Is<IPAddress>().ShouldBeFalse();
            text2.Is<IPAddress>().ShouldBeFalse();
            text3.Is<IPAddress>().ShouldBeFalse();
            text4.Is<IPAddress>().ShouldBeFalse();
            text5.Is<IPAddress>().ShouldBeFalse();
            text6.Is<IPAddress>().ShouldBeTrue();
            text7.Is<IPAddress>().ShouldBeTrue();
            text8.Is<IPAddress>().ShouldBeTrue();
            text9.Is<IPAddress>().ShouldBeTrue();
            textA.Is<IPAddress>().ShouldBeTrue();
            textB.Is<IPAddress>().ShouldBeTrue();
            textC.Is<IPAddress>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is IpAddress type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsIpAddressTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.Is<IPAddress>(Context).ShouldBeFalse();
            text1.Is<IPAddress>(Context).ShouldBeFalse();
            text2.Is<IPAddress>(Context).ShouldBeFalse();
            text3.Is<IPAddress>(Context).ShouldBeFalse();
            text4.Is<IPAddress>(Context).ShouldBeFalse();
            text5.Is<IPAddress>(Context).ShouldBeFalse();
            text6.Is<IPAddress>(Context).ShouldBeTrue();
            text7.Is<IPAddress>(Context).ShouldBeTrue();
            text8.Is<IPAddress>(Context).ShouldBeTrue();
            text9.Is<IPAddress>(Context).ShouldBeTrue();
            textA.Is<IPAddress>(Context).ShouldBeTrue();
            textB.Is<IPAddress>(Context).ShouldBeTrue();
            textC.Is<IPAddress>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable IpAddress type or not test")]
        public void JudgingStringIsNullableIpAddressTypeTest()
        {
            var type = typeof(IPAddress);
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable IpAddress type or not and ignore case test")]
        public void JudgingStringIsNullableIpAddressTypeWithIgnoreCaseTest()
        {
            var type = typeof(IPAddress);
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();
            text3.IsNullable(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable IpAddress type or not by generic type test")]
        public void JudgingStringIsNullableIpAddressTypeByGenericTypeTest()
        {
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is<IPAddress>().ShouldBeTrue();
            text1.Is<IPAddress>().ShouldBeTrue();
            text2.Is<IPAddress>().ShouldBeTrue();
            text3.Is<IPAddress>().ShouldBeTrue();

            text0.IsNullable<IPAddress>().ShouldBeTrue();
            text1.IsNullable<IPAddress>().ShouldBeTrue();
            text2.IsNullable<IPAddress>().ShouldBeTrue();
            text3.IsNullable<IPAddress>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable IpAddress type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableIpAddressTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = IPAddress.Parse("192.168.1.1").ToString();
            var text1 = IPAddress.Parse("202.96.209.133").ToString();
            var text2 = IPAddress.Parse("fe80:0000:0001:0000:0440:44ff:1233:5678").ToString();
            var text3 = IPAddress.Parse("fe80::0001:0000").ToString();

            text0.Is<IPAddress>(Context).ShouldBeTrue();
            text1.Is<IPAddress>(Context).ShouldBeTrue();
            text2.Is<IPAddress>(Context).ShouldBeTrue();
            text3.Is<IPAddress>(Context).ShouldBeTrue();

            text0.IsNullable<IPAddress>(Context).ShouldBeTrue();
            text1.IsNullable<IPAddress>(Context).ShouldBeTrue();
            text2.IsNullable<IPAddress>(Context).ShouldBeTrue();
            text3.IsNullable<IPAddress>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable IpAddress type or not test")]
        public void JudgingNullOrEmptyStringIsNullableIpAddressTypeTest()
        {
            var type = typeof(IPAddress);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeFalse();
            text5.Is(type).ShouldBeFalse();
            text6.Is(type).ShouldBeTrue();
            text7.Is(type).ShouldBeTrue();
            text8.Is(type).ShouldBeTrue();
            text9.Is(type).ShouldBeTrue();
            textA.Is(type).ShouldBeTrue();
            textB.Is(type).ShouldBeTrue();
            textC.Is(type).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            text3.IsNullable(type).ShouldBeFalse();
            text4.IsNullable(type).ShouldBeFalse();
            text5.IsNullable(type).ShouldBeFalse();
            text6.IsNullable(type).ShouldBeTrue();
            text7.IsNullable(type).ShouldBeTrue();
            text8.IsNullable(type).ShouldBeTrue();
            text9.IsNullable(type).ShouldBeTrue();
            textA.IsNullable(type).ShouldBeTrue();
            textB.IsNullable(type).ShouldBeTrue();
            textC.IsNullable(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable IpAddress type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableIpAddressTypeWithIgnoreCaseTest()
        {
            var type = typeof(IPAddress);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
            text4.Is(type, Context).ShouldBeFalse();
            text5.Is(type, Context).ShouldBeFalse();
            text6.Is(type, Context).ShouldBeTrue();
            text7.Is(type, Context).ShouldBeTrue();
            text8.Is(type, Context).ShouldBeTrue();
            text9.Is(type, Context).ShouldBeTrue();
            textA.Is(type, Context).ShouldBeTrue();
            textB.Is(type, Context).ShouldBeTrue();
            textC.Is(type, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();
            text3.IsNullable(type, Context).ShouldBeFalse();
            text4.IsNullable(type, Context).ShouldBeFalse();
            text5.IsNullable(type, Context).ShouldBeFalse();
            text6.IsNullable(type, Context).ShouldBeTrue();
            text7.IsNullable(type, Context).ShouldBeTrue();
            text8.IsNullable(type, Context).ShouldBeTrue();
            text9.IsNullable(type, Context).ShouldBeTrue();
            textA.IsNullable(type, Context).ShouldBeTrue();
            textB.IsNullable(type, Context).ShouldBeTrue();
            textC.IsNullable(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable IpAddress type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableIpAddressTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.IsNullable<IPAddress>().ShouldBeTrue();
            text1.IsNullable<IPAddress>().ShouldBeFalse();
            text2.IsNullable<IPAddress>().ShouldBeFalse();
            text3.IsNullable<IPAddress>().ShouldBeFalse();
            text4.IsNullable<IPAddress>().ShouldBeFalse();
            text5.IsNullable<IPAddress>().ShouldBeFalse();
            text6.IsNullable<IPAddress>().ShouldBeTrue();
            text7.IsNullable<IPAddress>().ShouldBeTrue();
            text8.IsNullable<IPAddress>().ShouldBeTrue();
            text9.IsNullable<IPAddress>().ShouldBeTrue();
            textA.IsNullable<IPAddress>().ShouldBeTrue();
            textB.IsNullable<IPAddress>().ShouldBeTrue();
            textC.IsNullable<IPAddress>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable IpAddress type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableIpAddressTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = "255.255.255.256";
            string text5 = "fe80::0001::0001:0000";
            string text6 = IPAddress.Any.ToString();
            string text7 = IPAddress.IPv6Any.ToString();
            string text8 = IPAddress.None.ToString();
            string text9 = IPAddress.IPv6None.ToString();
            string textA = IPAddress.Broadcast.ToString();
            string textB = IPAddress.Loopback.ToString();
            string textC = IPAddress.IPv6Loopback.ToString();

            text0.IsNullable<IPAddress>(Context).ShouldBeTrue();
            text1.IsNullable<IPAddress>(Context).ShouldBeFalse();
            text2.IsNullable<IPAddress>(Context).ShouldBeFalse();
            text3.IsNullable<IPAddress>(Context).ShouldBeFalse();
            text4.IsNullable<IPAddress>(Context).ShouldBeFalse();
            text5.IsNullable<IPAddress>(Context).ShouldBeFalse();
            text6.IsNullable<IPAddress>(Context).ShouldBeTrue();
            text7.IsNullable<IPAddress>(Context).ShouldBeTrue();
            text8.IsNullable<IPAddress>(Context).ShouldBeTrue();
            text9.IsNullable<IPAddress>(Context).ShouldBeTrue();
            textA.IsNullable<IPAddress>(Context).ShouldBeTrue();
            textB.IsNullable<IPAddress>(Context).ShouldBeTrue();
            textC.IsNullable<IPAddress>(Context).ShouldBeTrue();
        }
    }
}