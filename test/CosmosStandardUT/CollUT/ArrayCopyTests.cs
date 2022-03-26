using Cosmos.Collections;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ArrayUT.Copy")]
    public class ArrayCopyTests
    {
        [Fact(DisplayName = "Arrays.Copy - One to Seven dimensional array test")]
        public void ArraysCopyOneToSevenDimensionalArrayTest()
        {
            var one = new[] {1, 2, 3};
            var two = new[,] {{1, 2, 3}, {1, 2, 3}};
            var three = new[,,] {{{1}, {2}, {3}}, {{1}, {2}, {3}}};
            var four = new[,,,] {{{{1}, {2}, {3}}}};
            var five = new[,,,,] {{{{{1}, {2}, {3}}}}};
            var six = new[,,,,,] {{{{{{1}, {2}, {3}}}}}};
            var seven = new[,,,,,,] {{{{{{{1}, {2}, {3}}}}}}};

            var oneCopy = Arrays.Copy(one);
            var twoCopy = Arrays.Copy(two);
            var threeCopy = Arrays.Copy(three);
            var fourCopy = Arrays.Copy(four);
            var fiveCopy = Arrays.Copy(five);
            var sixCopy = Arrays.Copy(six);
            var sevenCopy = Arrays.Copy(seven);

            Assert.Equal(one, oneCopy);
            Assert.Equal(two, twoCopy);
            Assert.Equal(three, threeCopy);
            Assert.Equal(four, fourCopy);
            Assert.Equal(five, fiveCopy);
            Assert.Equal(six, sixCopy);
            Assert.Equal(seven, sevenCopy);

            Assert.NotStrictEqual(one, oneCopy);
            Assert.NotStrictEqual(two, twoCopy);
            Assert.NotStrictEqual(three, threeCopy);
            Assert.NotStrictEqual(four, fourCopy);
            Assert.NotStrictEqual(five, fiveCopy);
            Assert.NotStrictEqual(six, sixCopy);
            Assert.NotStrictEqual(seven, sevenCopy);
        }

        [Fact(DisplayName = "Arrays.Copy extensions - One to Seven dimensional array test")]
        public void ExtensionMethodsForArraysCopyOneToSevenDimensionalArrayTest()
        {
            var one = new[] {1, 2, 3};
            var two = new[,] {{1, 2, 3}, {1, 2, 3}};
            var three = new[,,] {{{1}, {2}, {3}}, {{1}, {2}, {3}}};
            var four = new[,,,] {{{{1}, {2}, {3}}}};
            var five = new[,,,,] {{{{{1}, {2}, {3}}}}};
            var six = new[,,,,,] {{{{{{1}, {2}, {3}}}}}};
            var seven = new[,,,,,,] {{{{{{{1}, {2}, {3}}}}}}};

            var oneCopy = one.Copy();
            var twoCopy = two.Copy();
            var threeCopy = three.Copy();
            var fourCopy = four.Copy();
            var fiveCopy = five.Copy();
            var sixCopy = six.Copy();
            var sevenCopy = seven.Copy();

            Assert.Equal(one, oneCopy);
            Assert.Equal(two, twoCopy);
            Assert.Equal(three, threeCopy);
            Assert.Equal(four, fourCopy);
            Assert.Equal(five, fiveCopy);
            Assert.Equal(six, sixCopy);
            Assert.Equal(seven, sevenCopy);

            Assert.NotStrictEqual(one, oneCopy);
            Assert.NotStrictEqual(two, twoCopy);
            Assert.NotStrictEqual(three, threeCopy);
            Assert.NotStrictEqual(four, fourCopy);
            Assert.NotStrictEqual(five, fiveCopy);
            Assert.NotStrictEqual(six, sixCopy);
            Assert.NotStrictEqual(seven, sevenCopy);
        }

        [Fact(DisplayName = "Array.Copy extensions with int length test")]
        public void ExtensionMethodsForArrayShortcutCopyWithIntLengthTest()
        {
            var one = new[] {1, 2, 3};
            var two = new[,] {{1, 2, 3}, {1, 2, 3}};
            var three = new[,,] {{{1}, {2}, {3}}, {{1}, {2}, {3}}};
            var four = new[,,,] {{{{1}, {2}, {3}}}};
            var five = new[,,,,] {{{{{1}, {2}, {3}}}}};
            var six = new[,,,,,] {{{{{{1}, {2}, {3}}}}}};
            var seven = new[,,,,,,] {{{{{{{1}, {2}, {3}}}}}}};

            var oneTarget = new int[3];
            var twoTarget = new int[2, 3];
            var threeTarget = new int[2, 3, 1];
            var fourTarget = new int[1, 1, 3, 1];
            var fiveTarget = new int[1, 1, 1, 3, 1];
            var sixTarget = new int[1, 1, 1, 1, 3, 1];
            var sevenTarget = new int[1, 1, 1, 1, 1, 3, 1];

            Assert.NotEqual(one, oneTarget);
            Assert.NotEqual(two, twoTarget);
            Assert.NotEqual(three, threeTarget);
            Assert.NotEqual(four, fourTarget);
            Assert.NotEqual(five, fiveTarget);
            Assert.NotEqual(six, sixTarget);
            Assert.NotEqual(seven, sevenTarget);

            one.Copy(oneTarget, one.Length);
            two.Copy(twoTarget, two.Length);
            three.Copy(threeTarget, three.Length);
            four.Copy(fourTarget, four.Length);
            five.Copy(fiveTarget, five.Length);
            six.Copy(sixTarget, six.Length);
            seven.Copy(sevenTarget, seven.Length);

            Assert.Equal(one, oneTarget);
            Assert.Equal(two, twoTarget);
            Assert.Equal(three, threeTarget);
            Assert.Equal(four, fourTarget);
            Assert.Equal(five, fiveTarget);
            Assert.Equal(six, sixTarget);
            Assert.Equal(seven, sevenTarget);

            Assert.NotStrictEqual(one, oneTarget);
            Assert.NotStrictEqual(two, twoTarget);
            Assert.NotStrictEqual(three, threeTarget);
            Assert.NotStrictEqual(four, fourTarget);
            Assert.NotStrictEqual(five, fiveTarget);
            Assert.NotStrictEqual(six, sixTarget);
            Assert.NotStrictEqual(seven, sevenTarget);
        }

        [Fact(DisplayName = "Array.Copy extensions with int length and index test")]
        public void ExtensionMethodsForArrayShortcutCopyWithIntLengthAndIndexTest()
        {
            var one = new[] {1, 2, 3};
            var two = new[,] {{1, 2, 3}, {1, 2, 3}};
            var three = new[,,] {{{1}, {2}, {3}}, {{1}, {2}, {3}}};
            var four = new[,,,] {{{{1}, {2}, {3}}}};
            var five = new[,,,,] {{{{{1}, {2}, {3}}}}};
            var six = new[,,,,,] {{{{{{1}, {2}, {3}}}}}};
            var seven = new[,,,,,,] {{{{{{{1}, {2}, {3}}}}}}};

            var oneTarget = new int[3];
            var twoTarget = new int[2, 3];
            var threeTarget = new int[2, 3, 1];
            var fourTarget = new int[1, 1, 3, 1];
            var fiveTarget = new int[1, 1, 1, 3, 1];
            var sixTarget = new int[1, 1, 1, 1, 3, 1];
            var sevenTarget = new int[1, 1, 1, 1, 1, 3, 1];

            Assert.NotEqual(one, oneTarget);
            Assert.NotEqual(two, twoTarget);
            Assert.NotEqual(three, threeTarget);
            Assert.NotEqual(four, fourTarget);
            Assert.NotEqual(five, fiveTarget);
            Assert.NotEqual(six, sixTarget);
            Assert.NotEqual(seven, sevenTarget);

            one.Copy(0, oneTarget, 0, one.Length);
            two.Copy(0, twoTarget, 0, two.Length);
            three.Copy(0, threeTarget, 0, three.Length);
            four.Copy(0, fourTarget, 0, four.Length);
            five.Copy(0, fiveTarget, 0, five.Length);
            six.Copy(0, sixTarget, 0, six.Length);
            seven.Copy(0, sevenTarget, 0, seven.Length);

            Assert.Equal(one, oneTarget);
            Assert.Equal(two, twoTarget);
            Assert.Equal(three, threeTarget);
            Assert.Equal(four, fourTarget);
            Assert.Equal(five, fiveTarget);
            Assert.Equal(six, sixTarget);
            Assert.Equal(seven, sevenTarget);

            Assert.NotStrictEqual(one, oneTarget);
            Assert.NotStrictEqual(two, twoTarget);
            Assert.NotStrictEqual(three, threeTarget);
            Assert.NotStrictEqual(four, fourTarget);
            Assert.NotStrictEqual(five, fiveTarget);
            Assert.NotStrictEqual(six, sixTarget);
            Assert.NotStrictEqual(seven, sevenTarget);
        }

        [Fact(DisplayName = "Array.Copy extensions with long length test")]
        public void ExtensionMethodsForArrayShortcutCopyWithLongLengthTest()
        {
            var one = new[] {1, 2, 3};
            var two = new[,] {{1, 2, 3}, {1, 2, 3}};
            var three = new[,,] {{{1}, {2}, {3}}, {{1}, {2}, {3}}};
            var four = new[,,,] {{{{1}, {2}, {3}}}};
            var five = new[,,,,] {{{{{1}, {2}, {3}}}}};
            var six = new[,,,,,] {{{{{{1}, {2}, {3}}}}}};
            var seven = new[,,,,,,] {{{{{{{1}, {2}, {3}}}}}}};

            var oneTarget = new int[3];
            var twoTarget = new int[2, 3];
            var threeTarget = new int[2, 3, 1];
            var fourTarget = new int[1, 1, 3, 1];
            var fiveTarget = new int[1, 1, 1, 3, 1];
            var sixTarget = new int[1, 1, 1, 1, 3, 1];
            var sevenTarget = new int[1, 1, 1, 1, 1, 3, 1];

            Assert.NotEqual(one, oneTarget);
            Assert.NotEqual(two, twoTarget);
            Assert.NotEqual(three, threeTarget);
            Assert.NotEqual(four, fourTarget);
            Assert.NotEqual(five, fiveTarget);
            Assert.NotEqual(six, sixTarget);
            Assert.NotEqual(seven, sevenTarget);

            one.Copy(oneTarget, one.LongLength);
            two.Copy(twoTarget, two.LongLength);
            three.Copy(threeTarget, three.LongLength);
            four.Copy(fourTarget, four.LongLength);
            five.Copy(fiveTarget, five.LongLength);
            six.Copy(sixTarget, six.LongLength);
            seven.Copy(sevenTarget, seven.LongLength);

            Assert.Equal(one, oneTarget);
            Assert.Equal(two, twoTarget);
            Assert.Equal(three, threeTarget);
            Assert.Equal(four, fourTarget);
            Assert.Equal(five, fiveTarget);
            Assert.Equal(six, sixTarget);
            Assert.Equal(seven, sevenTarget);

            Assert.NotStrictEqual(one, oneTarget);
            Assert.NotStrictEqual(two, twoTarget);
            Assert.NotStrictEqual(three, threeTarget);
            Assert.NotStrictEqual(four, fourTarget);
            Assert.NotStrictEqual(five, fiveTarget);
            Assert.NotStrictEqual(six, sixTarget);
            Assert.NotStrictEqual(seven, sevenTarget);
        }

        [Fact(DisplayName = "Array.Copy extensions with long length and index test")]
        public void ExtensionMethodsForArrayShortcutCopyWithLongLengthAndIndexTest()
        {
            var one = new[] {1, 2, 3};
            var two = new[,] {{1, 2, 3}, {1, 2, 3}};
            var three = new[,,] {{{1}, {2}, {3}}, {{1}, {2}, {3}}};
            var four = new[,,,] {{{{1}, {2}, {3}}}};
            var five = new[,,,,] {{{{{1}, {2}, {3}}}}};
            var six = new[,,,,,] {{{{{{1}, {2}, {3}}}}}};
            var seven = new[,,,,,,] {{{{{{{1}, {2}, {3}}}}}}};

            var oneTarget = new int[3];
            var twoTarget = new int[2, 3];
            var threeTarget = new int[2, 3, 1];
            var fourTarget = new int[1, 1, 3, 1];
            var fiveTarget = new int[1, 1, 1, 3, 1];
            var sixTarget = new int[1, 1, 1, 1, 3, 1];
            var sevenTarget = new int[1, 1, 1, 1, 1, 3, 1];

            Assert.NotEqual(one, oneTarget);
            Assert.NotEqual(two, twoTarget);
            Assert.NotEqual(three, threeTarget);
            Assert.NotEqual(four, fourTarget);
            Assert.NotEqual(five, fiveTarget);
            Assert.NotEqual(six, sixTarget);
            Assert.NotEqual(seven, sevenTarget);

            one.Copy(0, oneTarget, 0, one.LongLength);
            two.Copy(0, twoTarget, 0, two.LongLength);
            three.Copy(0, threeTarget, 0, three.LongLength);
            four.Copy(0, fourTarget, 0, four.LongLength);
            five.Copy(0, fiveTarget, 0, five.LongLength);
            six.Copy(0, sixTarget, 0, six.LongLength);
            seven.Copy(0, sevenTarget, 0, seven.LongLength);

            Assert.Equal(one, oneTarget);
            Assert.Equal(two, twoTarget);
            Assert.Equal(three, threeTarget);
            Assert.Equal(four, fourTarget);
            Assert.Equal(five, fiveTarget);
            Assert.Equal(six, sixTarget);
            Assert.Equal(seven, sevenTarget);

            Assert.NotStrictEqual(one, oneTarget);
            Assert.NotStrictEqual(two, twoTarget);
            Assert.NotStrictEqual(three, threeTarget);
            Assert.NotStrictEqual(four, fourTarget);
            Assert.NotStrictEqual(five, fiveTarget);
            Assert.NotStrictEqual(six, sixTarget);
            Assert.NotStrictEqual(seven, sevenTarget);
        }

        [Fact(DisplayName = "Array.ConstrainedCopy extensions test")]
        public void ExtensionMethodForArrayShortcutCopyWithConstrainedTest()
        {
            var one = new[] {1, 2, 3};
            var two = new[,] {{1, 2, 3}, {1, 2, 3}};
            var three = new[,,] {{{1}, {2}, {3}}, {{1}, {2}, {3}}};
            var four = new[,,,] {{{{1}, {2}, {3}}}};
            var five = new[,,,,] {{{{{1}, {2}, {3}}}}};
            var six = new[,,,,,] {{{{{{1}, {2}, {3}}}}}};
            var seven = new[,,,,,,] {{{{{{{1}, {2}, {3}}}}}}};

            var oneTarget = new int[3];
            var twoTarget = new int[2, 3];
            var threeTarget = new int[2, 3, 1];
            var fourTarget = new int[1, 1, 3, 1];
            var fiveTarget = new int[1, 1, 1, 3, 1];
            var sixTarget = new int[1, 1, 1, 1, 3, 1];
            var sevenTarget = new int[1, 1, 1, 1, 1, 3, 1];

            Assert.NotEqual(one, oneTarget);
            Assert.NotEqual(two, twoTarget);
            Assert.NotEqual(three, threeTarget);
            Assert.NotEqual(four, fourTarget);
            Assert.NotEqual(five, fiveTarget);
            Assert.NotEqual(six, sixTarget);
            Assert.NotEqual(seven, sevenTarget);

            one.ConstrainedCopy(0, oneTarget, 0, one.Length);
            two.ConstrainedCopy(0, twoTarget, 0, two.Length);
            three.ConstrainedCopy(0, threeTarget, 0, three.Length);
            four.ConstrainedCopy(0, fourTarget, 0, four.Length);
            five.ConstrainedCopy(0, fiveTarget, 0, five.Length);
            six.ConstrainedCopy(0, sixTarget, 0, six.Length);
            seven.ConstrainedCopy(0, sevenTarget, 0, seven.Length);

            Assert.Equal(one, oneTarget);
            Assert.Equal(two, twoTarget);
            Assert.Equal(three, threeTarget);
            Assert.Equal(four, fourTarget);
            Assert.Equal(five, fiveTarget);
            Assert.Equal(six, sixTarget);
            Assert.Equal(seven, sevenTarget);

            Assert.NotStrictEqual(one, oneTarget);
            Assert.NotStrictEqual(two, twoTarget);
            Assert.NotStrictEqual(three, threeTarget);
            Assert.NotStrictEqual(four, fourTarget);
            Assert.NotStrictEqual(five, fiveTarget);
            Assert.NotStrictEqual(six, sixTarget);
            Assert.NotStrictEqual(seven, sevenTarget);
        }

        [Fact(DisplayName = "Array.BlockCopy extensions test")]
        public void ExtensionMethodForArrayShortcutCopyWithBlockTest()
        {
            var one = new[] {(byte) 1, (byte) 2, (byte) 3};
            var two = new[,] {{(byte) 1, (byte) 2, (byte) 3}, {(byte) 1, (byte) 2, (byte) 3}};
            var three = new[,,] {{{(byte) 1}, {(byte) 2}, {(byte) 3}}, {{(byte) 1}, {(byte) 2}, {(byte) 3}}};
            var four = new[,,,] {{{{(byte) 1}, {(byte) 2}, {(byte) 3}}}};
            var five = new[,,,,] {{{{{(byte) 1}, {(byte) 2}, {(byte) 3}}}}};
            var six = new[,,,,,] {{{{{{(byte) 1}, {(byte) 2}, {(byte) 3}}}}}};
            var seven = new[,,,,,,] {{{{{{{(byte) 1}, {(byte) 2}, {(byte) 3}}}}}}};

            var oneTarget = new byte[3];
            var twoTarget = new byte[2, 3];
            var threeTarget = new byte[2, 3, 1];
            var fourTarget = new byte[1, 1, 3, 1];
            var fiveTarget = new byte[1, 1, 1, 3, 1];
            var sixTarget = new byte[1, 1, 1, 1, 3, 1];
            var sevenTarget = new byte[1, 1, 1, 1, 1, 3, 1];

            Assert.NotEqual(one, oneTarget);
            Assert.NotEqual(two, twoTarget);
            Assert.NotEqual(three, threeTarget);
            Assert.NotEqual(four, fourTarget);
            Assert.NotEqual(five, fiveTarget);
            Assert.NotEqual(six, sixTarget);
            Assert.NotEqual(seven, sevenTarget);

            one.Copy(0, oneTarget, 0, one.Length);
            two.Copy(0, twoTarget, 0, two.Length);
            three.Copy(0, threeTarget, 0, three.Length);
            four.Copy(0, fourTarget, 0, four.Length);
            five.Copy(0, fiveTarget, 0, five.Length);
            six.Copy(0, sixTarget, 0, six.Length);
            seven.Copy(0, sevenTarget, 0, seven.Length);

            Assert.Equal(one, oneTarget);
            Assert.Equal(two, twoTarget);
            Assert.Equal(three, threeTarget);
            Assert.Equal(four, fourTarget);
            Assert.Equal(five, fiveTarget);
            Assert.Equal(six, sixTarget);
            Assert.Equal(seven, sevenTarget);

            Assert.NotStrictEqual(one, oneTarget);
            Assert.NotStrictEqual(two, twoTarget);
            Assert.NotStrictEqual(three, threeTarget);
            Assert.NotStrictEqual(four, fourTarget);
            Assert.NotStrictEqual(five, fiveTarget);
            Assert.NotStrictEqual(six, sixTarget);
            Assert.NotStrictEqual(seven, sevenTarget);
        }

        [Fact(DisplayName = "Array.Copy self extensions test")]
        public void ExtensionMethodForArrayAndCopySelfTest()
        {
            var one = new[] {1, 2, 3};
            var oneTarget = one.Copy(one.Length, ArrayCopyOptions.Length);
            Assert.Equal(one, oneTarget);
            Assert.NotStrictEqual(one, oneTarget);

            var oneDudu = one.Copy(one.LongLength, ArrayCopyOptions.Length);
            Assert.Equal(one, oneDudu);
            Assert.NotStrictEqual(one, oneDudu);

            var oneGuaGua = one.Copy(0, ArrayCopyOptions.SinceIndex);
            Assert.Equal(one, oneGuaGua);
            Assert.NotStrictEqual(one, oneGuaGua);

            var oneSusu = one.Copy(0L, ArrayCopyOptions.SinceIndex);
            Assert.Equal(one, oneSusu);
            Assert.NotStrictEqual(one, oneSusu);

            var oneDance = one.Copy(0, one.Length);
            Assert.Equal(one, oneDance);
            Assert.NotStrictEqual(one, oneDance);
            
            var oneSing = one.Copy(0L, one.LongLength);
            Assert.Equal(one, oneSing);
            Assert.NotStrictEqual(one, oneSing);
        }
    }
}