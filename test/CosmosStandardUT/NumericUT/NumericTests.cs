using System;
using Cosmos.Numeric;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.NumericUT
{
    [Trait("NumericUT", "Numeric")]
    public class NumericTests
    {
        [Fact(DisplayName = "Number NaN test")]
        public void NaNTest()
        {
            var number1 = double.NaN;
            var number2 = float.NaN;

            Numbers.IsNaN(number1).ShouldBeTrue();
            Numbers.IsNaN(number2).ShouldBeTrue();
            Numbers.IsNaN(123).ShouldBeFalse();
        }

        [Fact(DisplayName = "Number default test")]
        public void DefaultValueTest()
        {
            Numbers.IsDefaultValue(default).ShouldBeTrue();
            Numbers.IsDefaultValue(0).ShouldBeTrue();
        }

        [Fact(DisplayName = "Number range between test")]
        public void NumbersRangeTest()
        {
            var numbers1 = Numbers.GetRangeBetween(1, 3);
            var numbers2 = Numbers.GetRangeBetween(1L, 4L);

            numbers1.Length.ShouldBe(3);
            numbers2.Length.ShouldBe(4);

            numbers1[0].ShouldBe(1);
            numbers1[1].ShouldBe(2);
            numbers1[2].ShouldBe(3);
            numbers2[0].ShouldBe(1);
            numbers2[1].ShouldBe(2);
            numbers2[2].ShouldBe(3);
            numbers2[3].ShouldBe(4);
        }

        [Fact(DisplayName = "Number ZeroFix test")]
        public void FixZeroTest()
        {
            Numbers.FixZero(default).ShouldBe(0);
            Numbers.FixZero(0).ShouldBe(0);
            Numbers.FixZero(+0).ShouldBe(0);
            Numbers.FixZero(-0).ShouldBe(0);
            Numbers.FixZero(77).ShouldBe(77);
            Numbers.FixZero(double.NaN).ShouldBe(double.NaN);
        }

        [Fact(DisplayName = "Number Decimal Places test")]
        public void DecimalPlacesTest()
        {
            Numbers.GetDecimalPlaces(default).ShouldBe(0);
            Numbers.GetDecimalPlaces(double.NaN).ShouldBe(0);
            Numbers.GetDecimalPlaces(12.9999999999999999).ShouldBe(0); //16
            Numbers.GetDecimalPlaces(12.999999999999999).ShouldBe(0); //15
            Numbers.GetDecimalPlaces(12.99999999999999).ShouldBe(0); //14
            Numbers.GetDecimalPlaces(12.9999999999999).ShouldBe(13); //13
            Numbers.GetDecimalPlaces(12.999999999999).ShouldBe(12); //12
            Numbers.GetDecimalPlaces(12.99999999999).ShouldBe(11); //11
            Numbers.GetDecimalPlaces(12.9999999999).ShouldBe(10); //10
            Numbers.GetDecimalPlaces(12.999999999).ShouldBe(9); //9
            Numbers.GetDecimalPlaces(12.99999999).ShouldBe(8); //8
            Numbers.GetDecimalPlaces(12.9999999).ShouldBe(7); //7
            Numbers.GetDecimalPlaces(12.999999).ShouldBe(6); //6
            Numbers.GetDecimalPlaces(12.99999).ShouldBe(5); //5
            Numbers.GetDecimalPlaces(12.9999).ShouldBe(4); //4
            Numbers.GetDecimalPlaces(12.999).ShouldBe(3); //3
            Numbers.GetDecimalPlaces(12.99).ShouldBe(2); //2
            Numbers.GetDecimalPlaces(12.0).ShouldBe(0); //1
            Numbers.GetDecimalPlaces(12).ShouldBe(0); //0
            Numbers.GetDecimalPlaces(-12.9999999999999999).ShouldBe(0);
            Numbers.GetDecimalPlaces(-12.999999999999999).ShouldBe(0);
            Numbers.GetDecimalPlaces(-12.99999999999999).ShouldBe(0);
            Numbers.GetDecimalPlaces(-12.9999999999999).ShouldBe(13);
            Numbers.GetDecimalPlaces(-12.999999999999).ShouldBe(12);
            Numbers.GetDecimalPlaces(-12.99999999999).ShouldBe(11);
            Numbers.GetDecimalPlaces(-12.9999999999).ShouldBe(10);
            Numbers.GetDecimalPlaces(-12.999999999).ShouldBe(9);
            Numbers.GetDecimalPlaces(-12.99999999).ShouldBe(8);
            Numbers.GetDecimalPlaces(-12.9999999).ShouldBe(7);
            Numbers.GetDecimalPlaces(-12.999999).ShouldBe(6);
            Numbers.GetDecimalPlaces(-12.99999).ShouldBe(5);
            Numbers.GetDecimalPlaces(-12.9999).ShouldBe(4);
            Numbers.GetDecimalPlaces(-12.999).ShouldBe(3);
            Numbers.GetDecimalPlaces(-12.99).ShouldBe(2);
            Numbers.GetDecimalPlaces(-12.0).ShouldBe(0);
            Numbers.GetDecimalPlaces(-12).ShouldBe(0);
        }

        [Fact(DisplayName = "Number Sum Accurate test")]
        public void SumAccurateTest()
        {
            Numbers.GetSumAccurate(1.11, 1.11).ShouldBe(2.22);
            Numbers.GetSumAccurate(1.11, 1.11111).ShouldBe(2.22111);
            Numbers.GetSumAccurate(1.111, 1.111).ShouldBe(2.222); //3
            Numbers.GetSumAccurate(1.1111, 1.1111).ShouldBe(2.2222); //4
            Numbers.GetSumAccurate(1.11111, 1.11111).ShouldBe(2.22222); //5
            Numbers.GetSumAccurate(1.111111, 1.111111).ShouldBe(2.222222); //6
            Numbers.GetSumAccurate(1.1111111, 1.1111111).ShouldBe(2.2222222); //7
            Numbers.GetSumAccurate(1.11111111, 1.11111111).ShouldBe(2.22222222); //8
            Numbers.GetSumAccurate(1.111111111, 1.111111111).ShouldBe(2.222222222); //9
            Numbers.GetSumAccurate(1.1111111111, 1.1111111111).ShouldBe(2.2222222222); //10
            Numbers.GetSumAccurate(1.11111111111, 1.11111111111).ShouldBe(2.22222222222); //11
            Numbers.GetSumAccurate(1.111111111111, 1.111111111111).ShouldBe(2.222222222222); //12
            Numbers.GetSumAccurate(1.1111111111111, 1.1111111111111).ShouldBe(2.2222222222222); //13
            Numbers.GetSumAccurate(1.11111111111111, 1.11111111111111).ShouldBe(2.22222222222222); //14
            Numbers.GetSumAccurate(1.111111111111111, 1.111111111111111).ShouldBe(2.22222222222222); //15 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.1111111111111111, 1.1111111111111111).ShouldBe(2.22222222222222); //16 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.11111111111111111, 1.11111111111111111).ShouldBe(2.22222222222222); //17 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.0, 1.111).ShouldBe(2.111); //3
            Numbers.GetSumAccurate(1.0, 1.1111).ShouldBe(2.1111); //4
            Numbers.GetSumAccurate(1.0, 1.11111).ShouldBe(2.11111); //5
            Numbers.GetSumAccurate(1.0, 1.111111).ShouldBe(2.111111); //6
            Numbers.GetSumAccurate(1.0, 1.1111111).ShouldBe(2.1111111); //7
            Numbers.GetSumAccurate(1.0, 1.11111111).ShouldBe(2.11111111); //8
            Numbers.GetSumAccurate(1.0, 1.111111111).ShouldBe(2.111111111); //9
            Numbers.GetSumAccurate(1.0, 1.1111111111).ShouldBe(2.1111111111); //10
            Numbers.GetSumAccurate(1.0, 1.11111111111).ShouldBe(2.11111111111); //11
            Numbers.GetSumAccurate(1.0, 1.111111111111).ShouldBe(2.111111111111); //12
            Numbers.GetSumAccurate(1.0, 1.1111111111111).ShouldBe(2.1111111111111); //13
            Numbers.GetSumAccurate(1.0, 1.11111111111111).ShouldBe(2.11111111111111); //14
            Numbers.GetSumAccurate(1.0, 1.111111111111111).ShouldBe(2.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.0, 1.1111111111111111).ShouldBe(2.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.0, 1.11111111111111111).ShouldBe(2.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.111, 1.0).ShouldBe(2.111); //3
            Numbers.GetSumAccurate(1.1111, 1.0).ShouldBe(2.1111); //4
            Numbers.GetSumAccurate(1.11111, 1.0).ShouldBe(2.11111); //5
            Numbers.GetSumAccurate(1.111111, 1.0).ShouldBe(2.111111); //6
            Numbers.GetSumAccurate(1.1111111, 1.0).ShouldBe(2.1111111); //7
            Numbers.GetSumAccurate(1.11111111, 1.0).ShouldBe(2.11111111); //8
            Numbers.GetSumAccurate(1.111111111, 1.0).ShouldBe(2.111111111); //9
            Numbers.GetSumAccurate(1.1111111111, 1.0).ShouldBe(2.1111111111); //10
            Numbers.GetSumAccurate(1.11111111111, 1.0).ShouldBe(2.11111111111); //11
            Numbers.GetSumAccurate(1.111111111111, 1.0).ShouldBe(2.111111111111); //12
            Numbers.GetSumAccurate(1.1111111111111, 1.0).ShouldBe(2.1111111111111); //13
            Numbers.GetSumAccurate(1.11111111111111, 1.0).ShouldBe(2.11111111111111); //14
            Numbers.GetSumAccurate(1.111111111111111, 1.0).ShouldBe(2.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.1111111111111111, 1.0).ShouldBe(2.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.11111111111111111, 1.0).ShouldBe(2.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetSumAccurate(-1.0, 1.111).ShouldBe(0.111); //3
            Numbers.GetSumAccurate(-1.0, 1.1111).ShouldBe(0.1111); //4
            Numbers.GetSumAccurate(-1.0, 1.11111).ShouldBe(0.11111); //5
            Numbers.GetSumAccurate(-1.0, 1.111111).ShouldBe(0.111111); //6
            Numbers.GetSumAccurate(-1.0, 1.1111111).ShouldBe(0.1111111); //7
            Numbers.GetSumAccurate(-1.0, 1.11111111).ShouldBe(0.11111111); //8
            Numbers.GetSumAccurate(-1.0, 1.111111111).ShouldBe(0.111111111); //9
            Numbers.GetSumAccurate(-1.0, 1.1111111111).ShouldBe(0.1111111111); //10
            Numbers.GetSumAccurate(-1.0, 1.11111111111).ShouldBe(0.11111111111); //11
            Numbers.GetSumAccurate(-1.0, 1.111111111111).ShouldBe(0.111111111111); //12
            Numbers.GetSumAccurate(-1.0, 1.1111111111111).ShouldBe(0.1111111111111); //13
            Numbers.GetSumAccurate(-1.0, 1.11111111111111).ShouldBe(0.11111111111111); //14
            Numbers.GetSumAccurate(-1.0, 1.111111111111111).ShouldBe(0.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumAccurate(-1.0, 1.1111111111111111).ShouldBe(0.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumAccurate(-1.0, 1.11111111111111111).ShouldBe(0.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.111, -1.111).ShouldBe(0); //3
            Numbers.GetSumAccurate(1.1111, -1.1111).ShouldBe(0); //4
            Numbers.GetSumAccurate(1.11111, -1.11111).ShouldBe(0); //5
            Numbers.GetSumAccurate(1.111111, -1.111111).ShouldBe(0); //6
            Numbers.GetSumAccurate(1.1111111, -1.1111111).ShouldBe(0); //7
            Numbers.GetSumAccurate(1.11111111, -1.11111111).ShouldBe(0); //8
            Numbers.GetSumAccurate(1.111111111, -1.111111111).ShouldBe(0); //9
            Numbers.GetSumAccurate(1.1111111111, -1.1111111111).ShouldBe(0); //10
            Numbers.GetSumAccurate(1.11111111111, -1.11111111111).ShouldBe(0); //11
            Numbers.GetSumAccurate(1.111111111111, -1.111111111111).ShouldBe(0); //12
            Numbers.GetSumAccurate(1.1111111111111, -1.1111111111111).ShouldBe(0); //13
            Numbers.GetSumAccurate(1.11111111111111, -1.11111111111111).ShouldBe(0); //14
            Numbers.GetSumAccurate(1.111111111111111, -1.111111111111111).ShouldBe(0); //15 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.1111111111111111, -1.1111111111111111).ShouldBe(0); //16 but max length was 14 (<15)
            Numbers.GetSumAccurate(1.11111111111111111, -1.11111111111111111).ShouldBe(0); //17 but max length was 14 (<15)
            Numbers.GetSumAccurate(-1.111, 1.0).ShouldBe(-0.111); //3
            Numbers.GetSumAccurate(-1.1111, 1.0).ShouldBe(-0.1111); //4
            Numbers.GetSumAccurate(-1.11111, 1.0).ShouldBe(-0.11111); //5
            Numbers.GetSumAccurate(-1.111111, 1.0).ShouldBe(-0.111111); //6
            Numbers.GetSumAccurate(-1.1111111, 1.0).ShouldBe(-0.1111111); //7
            Numbers.GetSumAccurate(-1.11111111, 1.0).ShouldBe(-0.11111111); //8
            Numbers.GetSumAccurate(-1.111111111, 1.0).ShouldBe(-0.111111111); //9
            Numbers.GetSumAccurate(-1.1111111111, 1.0).ShouldBe(-0.1111111111); //10
            Numbers.GetSumAccurate(-1.11111111111, 1.0).ShouldBe(-0.11111111111); //11
            Numbers.GetSumAccurate(-1.111111111111, 1.0).ShouldBe(-0.111111111111); //12
            Numbers.GetSumAccurate(-1.1111111111111, 1.0).ShouldBe(-0.1111111111111); //13
            Numbers.GetSumAccurate(-1.11111111111111, 1.0).ShouldBe(-0.11111111111111); //14
            Numbers.GetSumAccurate(-1.111111111111111, 1.0).ShouldBe(-0.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumAccurate(-1.1111111111111111, 1.0).ShouldBe(-0.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumAccurate(-1.11111111111111111, 1.0).ShouldBe(-0.11111111111111); //17 but max length was 14 (<15)
        }

        [Fact(DisplayName = "Number Product Accurate test")]
        public void ProductAccurateTest()
        {
            Numbers.GetProductAccurate(1, 1).ShouldBe(1); //0
            Numbers.GetProductAccurate(1.1, 1.1).ShouldBe(1.2); //1
            Numbers.GetProductAccurate(1.11, 1.11).ShouldBe(1.23); //2
            Numbers.GetProductAccurate(1.111, 1.111).ShouldBe(1.234); //3
            Numbers.GetProductAccurate(1.1111, 1.1111).ShouldBe(1.2345); //4
            Numbers.GetProductAccurate(1.11111, 1.11111).ShouldBe(1.23457); //5
            Numbers.GetProductAccurate(1.111111, 1.111111).ShouldBe(1.234568); //6
            Numbers.GetProductAccurate(1.1111111, 1.1111111).ShouldBe(1.2345679); //7
            Numbers.GetProductAccurate(1.11111111, 1.11111111).ShouldBe(1.23456790); //8
            Numbers.GetProductAccurate(1.111111111, 1.111111111).ShouldBe(1.234567901); //9
            Numbers.GetProductAccurate(1.1111111111, 1.1111111111).ShouldBe(1.2345679012); //10
            Numbers.GetProductAccurate(1.11111111111, 1.11111111111).ShouldBe(1.23456790123); //11
            Numbers.GetProductAccurate(1.111111111111, 1.111111111111).ShouldBe(1.234567901234); //12
            Numbers.GetProductAccurate(1.1111111111111, 1.1111111111111).ShouldBe(1.2345679012345); //13
            Numbers.GetProductAccurate(1.11111111111111, 1.11111111111111).ShouldBe(1.23456790123457); //14
            Numbers.GetProductAccurate(1.111111111111111, 1.111111111111111).ShouldBe(1.23456790123457); //15 but max length was 14 (<15)
            Numbers.GetProductAccurate(1.1111111111111111, 1.1111111111111111).ShouldBe(1.23456790123457); //16 but max length was 14 (<15)
            Numbers.GetProductAccurate(1.11111111111111111, 1.11111111111111111).ShouldBe(1.23456790123457); //17 but max length was 14 (<15)
            Numbers.GetProductAccurate(1, 1).ShouldBe(1); //0
            Numbers.GetProductAccurate(1, 1.1).ShouldBe(1.1); //1
            Numbers.GetProductAccurate(1, 1.11).ShouldBe(1.11); //2
            Numbers.GetProductAccurate(1, 1.111).ShouldBe(1.111); //3
            Numbers.GetProductAccurate(1, 1.1111).ShouldBe(1.1111); //4
            Numbers.GetProductAccurate(1, 1.11111).ShouldBe(1.11111); //5
            Numbers.GetProductAccurate(1, 1.111111).ShouldBe(1.111111); //6
            Numbers.GetProductAccurate(1, 1.1111111).ShouldBe(1.1111111); //7
            Numbers.GetProductAccurate(1, 1.11111111).ShouldBe(1.11111111); //8
            Numbers.GetProductAccurate(1, 1.111111111).ShouldBe(1.111111111); //9
            Numbers.GetProductAccurate(1, 1.1111111111).ShouldBe(1.1111111111); //10
            Numbers.GetProductAccurate(1, 1.11111111111).ShouldBe(1.11111111111); //11
            Numbers.GetProductAccurate(1, 1.111111111111).ShouldBe(1.111111111111); //12
            Numbers.GetProductAccurate(1, 1.1111111111111).ShouldBe(1.1111111111111); //13
            Numbers.GetProductAccurate(1, 1.11111111111111).ShouldBe(1.11111111111111); //14
            Numbers.GetProductAccurate(1, 1.111111111111111).ShouldBe(1.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetProductAccurate(1, 1.1111111111111111).ShouldBe(1.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetProductAccurate(1, 1.11111111111111111).ShouldBe(1.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetProductAccurate(0, 1).ShouldBe(0); //0
            Numbers.GetProductAccurate(0, 1.1).ShouldBe(0); //1
            Numbers.GetProductAccurate(0, 1.11).ShouldBe(0); //2
            Numbers.GetProductAccurate(0, 1.111).ShouldBe(0); //3
            Numbers.GetProductAccurate(0, 1.1111).ShouldBe(0); //4
            Numbers.GetProductAccurate(0, 1.11111).ShouldBe(0); //5
            Numbers.GetProductAccurate(0, 1.111111).ShouldBe(0); //6
            Numbers.GetProductAccurate(0, 1.1111111).ShouldBe(0); //7
            Numbers.GetProductAccurate(0, 1.11111111).ShouldBe(0); //8
            Numbers.GetProductAccurate(0, 1.111111111).ShouldBe(0); //9
            Numbers.GetProductAccurate(0, 1.1111111111).ShouldBe(0); //10
            Numbers.GetProductAccurate(0, 1.11111111111).ShouldBe(0); //11
            Numbers.GetProductAccurate(0, 1.111111111111).ShouldBe(0); //12
            Numbers.GetProductAccurate(0, 1.1111111111111).ShouldBe(0); //13
            Numbers.GetProductAccurate(0, 1.11111111111111).ShouldBe(0); //14
            Numbers.GetProductAccurate(0, 1.111111111111111).ShouldBe(0); //15 but max length was 14 (<15)
            Numbers.GetProductAccurate(0, 1.1111111111111111).ShouldBe(0); //16 but max length was 14 (<15)
            Numbers.GetProductAccurate(0, 1.11111111111111111).ShouldBe(0); //17 but max length was 14 (<15)
            Numbers.GetProductAccurate(-1, 1).ShouldBe(-1); //0
            Numbers.GetProductAccurate(-1, 1.1).ShouldBe(-1.1); //1
            Numbers.GetProductAccurate(-1, 1.11).ShouldBe(-1.11); //2
            Numbers.GetProductAccurate(-1, 1.111).ShouldBe(-1.111); //3
            Numbers.GetProductAccurate(-1, 1.1111).ShouldBe(-1.1111); //4
            Numbers.GetProductAccurate(-1, 1.11111).ShouldBe(-1.11111); //5
            Numbers.GetProductAccurate(-1, 1.111111).ShouldBe(-1.111111); //6
            Numbers.GetProductAccurate(-1, 1.1111111).ShouldBe(-1.1111111); //7
            Numbers.GetProductAccurate(-1, 1.11111111).ShouldBe(-1.11111111); //8
            Numbers.GetProductAccurate(-1, 1.111111111).ShouldBe(-1.111111111); //9
            Numbers.GetProductAccurate(-1, 1.1111111111).ShouldBe(-1.1111111111); //10
            Numbers.GetProductAccurate(-1, 1.11111111111).ShouldBe(-1.11111111111); //11
            Numbers.GetProductAccurate(-1, 1.111111111111).ShouldBe(-1.111111111111); //12
            Numbers.GetProductAccurate(-1, 1.1111111111111).ShouldBe(-1.1111111111111); //13
            Numbers.GetProductAccurate(-1, 1.11111111111111).ShouldBe(-1.11111111111111); //14
            Numbers.GetProductAccurate(-1, 1.111111111111111).ShouldBe(-1.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetProductAccurate(-1, 1.1111111111111111).ShouldBe(-1.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetProductAccurate(-1, 1.11111111111111111).ShouldBe(-1.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetProductAccurate(1, -1).ShouldBe(-1); //0
            Numbers.GetProductAccurate(1, -1.1).ShouldBe(-1.1); //1
            Numbers.GetProductAccurate(1, -1.11).ShouldBe(-1.11); //2
            Numbers.GetProductAccurate(1, -1.111).ShouldBe(-1.111); //3
            Numbers.GetProductAccurate(1, -1.1111).ShouldBe(-1.1111); //4
            Numbers.GetProductAccurate(1, -1.11111).ShouldBe(-1.11111); //5
            Numbers.GetProductAccurate(1, -1.111111).ShouldBe(-1.111111); //6
            Numbers.GetProductAccurate(1, -1.1111111).ShouldBe(-1.1111111); //7
            Numbers.GetProductAccurate(1, -1.11111111).ShouldBe(-1.11111111); //8
            Numbers.GetProductAccurate(1, -1.111111111).ShouldBe(-1.111111111); //9
            Numbers.GetProductAccurate(1, -1.1111111111).ShouldBe(-1.1111111111); //10
            Numbers.GetProductAccurate(1, -1.11111111111).ShouldBe(-1.11111111111); //11
            Numbers.GetProductAccurate(1, -1.111111111111).ShouldBe(-1.111111111111); //12
            Numbers.GetProductAccurate(1, -1.1111111111111).ShouldBe(-1.1111111111111); //13
            Numbers.GetProductAccurate(1, -1.11111111111111).ShouldBe(-1.11111111111111); //14
            Numbers.GetProductAccurate(1, -1.111111111111111).ShouldBe(-1.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetProductAccurate(1, -1.1111111111111111).ShouldBe(-1.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetProductAccurate(1, -1.11111111111111111).ShouldBe(-1.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetProductAccurate(-1, -1).ShouldBe(1); //0
            Numbers.GetProductAccurate(-1, -1.1).ShouldBe(1.1); //1
            Numbers.GetProductAccurate(-1, -1.11).ShouldBe(1.11); //2
            Numbers.GetProductAccurate(-1, -1.111).ShouldBe(1.111); //3
            Numbers.GetProductAccurate(-1, -1.1111).ShouldBe(1.1111); //4
            Numbers.GetProductAccurate(-1, -1.11111).ShouldBe(1.11111); //5
            Numbers.GetProductAccurate(-1, -1.111111).ShouldBe(1.111111); //6
            Numbers.GetProductAccurate(-1, -1.1111111).ShouldBe(1.1111111); //7
            Numbers.GetProductAccurate(-1, -1.11111111).ShouldBe(1.11111111); //8
            Numbers.GetProductAccurate(-1, -1.111111111).ShouldBe(1.111111111); //9
            Numbers.GetProductAccurate(-1, -1.1111111111).ShouldBe(1.1111111111); //10
            Numbers.GetProductAccurate(-1, -1.11111111111).ShouldBe(1.11111111111); //11
            Numbers.GetProductAccurate(-1, -1.111111111111).ShouldBe(1.111111111111); //12
            Numbers.GetProductAccurate(-1, -1.1111111111111).ShouldBe(1.1111111111111); //13
            Numbers.GetProductAccurate(-1, -1.11111111111111).ShouldBe(1.11111111111111); //14
            Numbers.GetProductAccurate(-1, -1.111111111111111).ShouldBe(1.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetProductAccurate(-1, -1.1111111111111111).ShouldBe(1.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetProductAccurate(-1, -1.11111111111111111).ShouldBe(1.11111111111111); //17 but max length was 14 (<15)
        }

        [Fact(DisplayName = "Number Sum using integers test")]
        public void SumUsingIntegersTest()
        {
            Numbers.GetSumUsingIntegers(1, 1).ShouldBe(2);
            Numbers.GetSumUsingIntegers(1.1, 1.1).ShouldBe(2.2);
            Numbers.GetSumUsingIntegers(1.111, 1.111).ShouldBe(2.222); //3
            Numbers.GetSumUsingIntegers(1.1111, 1.1111).ShouldBe(2.2222); //4
            Numbers.GetSumUsingIntegers(1.11111, 1.11111).ShouldBe(2.22222); //5
            Numbers.GetSumUsingIntegers(1.111111, 1.111111).ShouldBe(2.222222); //6
            Numbers.GetSumUsingIntegers(1.1111111, 1.1111111).ShouldBe(2.2222222); //7
            Numbers.GetSumUsingIntegers(1.11111111, 1.11111111).ShouldBe(2.22222222); //8
            Numbers.GetSumUsingIntegers(1.111111111, 1.111111111).ShouldBe(2.222222222); //9
            Numbers.GetSumUsingIntegers(1.1111111111, 1.1111111111).ShouldBe(2.2222222222); //10
            Numbers.GetSumUsingIntegers(1.11111111111, 1.11111111111).ShouldBe(2.22222222222); //11
            Numbers.GetSumUsingIntegers(1.111111111111, 1.111111111111).ShouldBe(2.222222222222); //12
            Numbers.GetSumUsingIntegers(1.1111111111111, 1.1111111111111).ShouldBe(2.2222222222222); //13
            Numbers.GetSumUsingIntegers(1.11111111111111, 1.11111111111111).ShouldBe(2.22222222222222); //14
            Numbers.GetSumUsingIntegers(1.111111111111111, 1.111111111111111).ShouldBe(2.22222222222222); //15 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.1111111111111111, 1.1111111111111111).ShouldBe(2.22222222222222); //16 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.11111111111111111, 1.11111111111111111).ShouldBe(2.22222222222222); //17 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.0, 1.111).ShouldBe(2.111); //3
            Numbers.GetSumUsingIntegers(1.0, 1.1111).ShouldBe(2.1111); //4
            Numbers.GetSumUsingIntegers(1.0, 1.11111).ShouldBe(2.11111); //5
            Numbers.GetSumUsingIntegers(1.0, 1.111111).ShouldBe(2.111111); //6
            Numbers.GetSumUsingIntegers(1.0, 1.1111111).ShouldBe(2.1111111); //7
            Numbers.GetSumUsingIntegers(1.0, 1.11111111).ShouldBe(2.11111111); //8
            Numbers.GetSumUsingIntegers(1.0, 1.111111111).ShouldBe(2.111111111); //9
            Numbers.GetSumUsingIntegers(1.0, 1.1111111111).ShouldBe(2.1111111111); //10
            Numbers.GetSumUsingIntegers(1.0, 1.11111111111).ShouldBe(2.11111111111); //11
            Numbers.GetSumUsingIntegers(1.0, 1.111111111111).ShouldBe(2.111111111111); //12
            Numbers.GetSumUsingIntegers(1.0, 1.1111111111111).ShouldBe(2.1111111111111); //13
            Numbers.GetSumUsingIntegers(1.0, 1.11111111111111).ShouldBe(2.11111111111111); //14
            Numbers.GetSumUsingIntegers(1.0, 1.111111111111111).ShouldBe(2.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.0, 1.1111111111111111).ShouldBe(2.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.0, 1.11111111111111111).ShouldBe(2.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.111, 1.0).ShouldBe(2.111); //3
            Numbers.GetSumUsingIntegers(1.1111, 1.0).ShouldBe(2.1111); //4
            Numbers.GetSumUsingIntegers(1.11111, 1.0).ShouldBe(2.11111); //5
            Numbers.GetSumUsingIntegers(1.111111, 1.0).ShouldBe(2.111111); //6
            Numbers.GetSumUsingIntegers(1.1111111, 1.0).ShouldBe(2.1111111); //7
            Numbers.GetSumUsingIntegers(1.11111111, 1.0).ShouldBe(2.11111111); //8
            Numbers.GetSumUsingIntegers(1.111111111, 1.0).ShouldBe(2.111111111); //9
            Numbers.GetSumUsingIntegers(1.1111111111, 1.0).ShouldBe(2.1111111111); //10
            Numbers.GetSumUsingIntegers(1.11111111111, 1.0).ShouldBe(2.11111111111); //11
            Numbers.GetSumUsingIntegers(1.111111111111, 1.0).ShouldBe(2.111111111111); //12
            Numbers.GetSumUsingIntegers(1.1111111111111, 1.0).ShouldBe(2.1111111111111); //13
            Numbers.GetSumUsingIntegers(1.11111111111111, 1.0).ShouldBe(2.11111111111111); //14
            Numbers.GetSumUsingIntegers(1.111111111111111, 1.0).ShouldBe(2.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.1111111111111111, 1.0).ShouldBe(2.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.11111111111111111, 1.0).ShouldBe(2.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(-1.0, 1.111).ShouldBe(0.111); //3
            Numbers.GetSumUsingIntegers(-1.0, 1.1111).ShouldBe(0.1111); //4
            Numbers.GetSumUsingIntegers(-1.0, 1.11111).ShouldBe(0.11111); //5
            Numbers.GetSumUsingIntegers(-1.0, 1.111111).ShouldBe(0.111111); //6
            Numbers.GetSumUsingIntegers(-1.0, 1.1111111).ShouldBe(0.1111111); //7
            Numbers.GetSumUsingIntegers(-1.0, 1.11111111).ShouldBe(0.11111111); //8
            Numbers.GetSumUsingIntegers(-1.0, 1.111111111).ShouldBe(0.111111111); //9
            Numbers.GetSumUsingIntegers(-1.0, 1.1111111111).ShouldBe(0.1111111111); //10
            Numbers.GetSumUsingIntegers(-1.0, 1.11111111111).ShouldBe(0.11111111111); //11
            Numbers.GetSumUsingIntegers(-1.0, 1.111111111111).ShouldBe(0.111111111111); //12
            Numbers.GetSumUsingIntegers(-1.0, 1.1111111111111).ShouldBe(0.1111111111111); //13
            Numbers.GetSumUsingIntegers(-1.0, 1.11111111111111).ShouldBe(0.11111111111111); //14
            Numbers.GetSumUsingIntegers(-1.0, 1.111111111111111).ShouldBe(0.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(-1.0, 1.1111111111111111).ShouldBe(0.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(-1.0, 1.11111111111111111).ShouldBe(0.11111111111111); //17 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.111, -1.111).ShouldBe(0); //3
            Numbers.GetSumUsingIntegers(1.1111, -1.1111).ShouldBe(0); //4
            Numbers.GetSumUsingIntegers(1.11111, -1.11111).ShouldBe(0); //5
            Numbers.GetSumUsingIntegers(1.111111, -1.111111).ShouldBe(0); //6
            Numbers.GetSumUsingIntegers(1.1111111, -1.1111111).ShouldBe(0); //7
            Numbers.GetSumUsingIntegers(1.11111111, -1.11111111).ShouldBe(0); //8
            Numbers.GetSumUsingIntegers(1.111111111, -1.111111111).ShouldBe(0); //9
            Numbers.GetSumUsingIntegers(1.1111111111, -1.1111111111).ShouldBe(0); //10
            Numbers.GetSumUsingIntegers(1.11111111111, -1.11111111111).ShouldBe(0); //11
            Numbers.GetSumUsingIntegers(1.111111111111, -1.111111111111).ShouldBe(0); //12
            Numbers.GetSumUsingIntegers(1.1111111111111, -1.1111111111111).ShouldBe(0); //13
            Numbers.GetSumUsingIntegers(1.11111111111111, -1.11111111111111).ShouldBe(0); //14
            Numbers.GetSumUsingIntegers(1.111111111111111, -1.111111111111111).ShouldBe(0); //15 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.1111111111111111, -1.1111111111111111).ShouldBe(0); //16 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(1.11111111111111111, -1.11111111111111111).ShouldBe(0); //17 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(-1.111, 1.0).ShouldBe(-0.111); //3
            Numbers.GetSumUsingIntegers(-1.1111, 1.0).ShouldBe(-0.1111); //4
            Numbers.GetSumUsingIntegers(-1.11111, 1.0).ShouldBe(-0.11111); //5
            Numbers.GetSumUsingIntegers(-1.111111, 1.0).ShouldBe(-0.111111); //6
            Numbers.GetSumUsingIntegers(-1.1111111, 1.0).ShouldBe(-0.1111111); //7
            Numbers.GetSumUsingIntegers(-1.11111111, 1.0).ShouldBe(-0.11111111); //8
            Numbers.GetSumUsingIntegers(-1.111111111, 1.0).ShouldBe(-0.111111111); //9
            Numbers.GetSumUsingIntegers(-1.1111111111, 1.0).ShouldBe(-0.1111111111); //10
            Numbers.GetSumUsingIntegers(-1.11111111111, 1.0).ShouldBe(-0.11111111111); //11
            Numbers.GetSumUsingIntegers(-1.111111111111, 1.0).ShouldBe(-0.111111111111); //12
            Numbers.GetSumUsingIntegers(-1.1111111111111, 1.0).ShouldBe(-0.1111111111111); //13
            Numbers.GetSumUsingIntegers(-1.11111111111111, 1.0).ShouldBe(-0.11111111111111); //14
            Numbers.GetSumUsingIntegers(-1.111111111111111, 1.0).ShouldBe(-0.11111111111111); //15 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(-1.1111111111111111, 1.0).ShouldBe(-0.11111111111111); //16 but max length was 14 (<15)
            Numbers.GetSumUsingIntegers(-1.11111111111111111, 1.0).ShouldBe(-0.11111111111111); //17 but max length was 14 (<15)
        }

        [Fact(DisplayName = "Number 2 number test")]
        public void NumberToNumberTest()
        {
            float a = 100.1234567f;

            double b = Numbers.ToDouble(a); // default is 4
            double c = Numbers.ToDouble(a, 2);

            float? a1 = a;
            double b1 = Numbers.ToDouble(a1); // default is 4
            double c1 = Numbers.ToDouble(a1, 2);

            Assert.Throws<ArgumentOutOfRangeException>(() => Numbers.ToDouble(a1, 16));

            int dp1 = Numbers.GetDecimalPlaces(a);
            int dp2 = Numbers.GetDecimalPlaces(b);
            int dp3 = Numbers.GetDecimalPlaces(c);
            int dp4 = Numbers.GetDecimalPlaces(b1);
            int dp5 = Numbers.GetDecimalPlaces(c1);

            Assert.Equal(4, dp2);
            Assert.Equal(4, dp4);
            Assert.Equal(2, dp3);
            Assert.Equal(2, dp5);

            b = Numbers.ToDouble(a, dp1);
            b1 = Numbers.ToDouble(a1, dp1);
            dp2 = Numbers.GetDecimalPlaces(b);
            dp4 = Numbers.GetDecimalPlaces(b1);

            Assert.Equal(dp1, dp2);
            Assert.Equal(dp1, dp4);

            decimal number1 = Numbers.ToDecimal(a);
            Assert.Equal(a.ToString(), number1.ToString());
        }
    }
}