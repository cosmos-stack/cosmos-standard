namespace Cosmos.Numeric;

/// <summary>
/// Number Utilities <br />
/// 数值工具
/// </summary>
public static partial class Numbers
{
    /// <summary>
    /// Number to Number Utility <br />
    /// 数值快速计算工具
    /// </summary>
    public static class ToNumber
    {
        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Tens(int input) => input * 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint Tens(uint input) => input * 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long Tens(long input) => input * 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ulong Tens(ulong input) => input * 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Tens(double input) => input * 10;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Hundreds(int input) => input * 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint Hundreds(uint input) => input * 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long Hundreds(long input) => input * 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ulong Hundreds(ulong input) => input * 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Hundreds(double input) => input * 100;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Thousands(int input) => input * 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint Thousands(uint input) => input * 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long Thousands(long input) => input * 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ulong Thousands(ulong input) => input * 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Thousands(double input) => input * 1000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Millions(int input) => input * 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint Millions(uint input) => input * 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long Millions(long input) => input * 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ulong Millions(ulong input) => input * 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Millions(double input) => input * 1_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Billions(int input) => input * 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint Billions(uint input) => input * 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long Billions(long input) => input * 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ulong Billions(ulong input) => input * 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Billions(double input) => input * 1_000_000_000;
    }

    /// <summary>
    /// Number to Number Utility <br />
    /// 数值快速计算工具
    /// </summary>
    public static class ToSelfNumber
    {
        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Tens(ref int input) => input *= 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Tens(ref uint input) => input *= 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Tens(ref long input) => input *= 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Tens(ref ulong input) => input *= 10;

        /// <summary>
        /// 5.Tens() => 50
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Tens(ref double input) => input *= 10;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Hundreds(ref int input) => input *= 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Hundreds(ref uint input) => input *= 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Hundreds(ref long input) => input *= 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Hundreds(ref ulong input) => input *= 100;

        /// <summary>
        /// 4.Hundreds() => 400
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Hundreds(ref double input) => input *= 100;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Thousands(ref int input) => input *= 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Thousands(ref uint input) => input *= 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Thousands(ref long input) => input *= 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Thousands(ref ulong input) => input *= 1000;

        /// <summary>
        /// 3.Thousands() => 3000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Thousands(ref double input) => input *= 1000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Millions(ref int input) => input *= 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Millions(ref uint input) => input *= 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Millions(ref long input) => input *= 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Millions(ref ulong input) => input *= 1_000_000;

        /// <summary>
        /// 2.Millions() => 2000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Millions(ref double input) => input *= 1_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Billions(ref int input) => input *= 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Billions(ref uint input) => input *= 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Billions(ref long input) => input *= 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Billions(ref ulong input) => input *= 1_000_000_000;

        /// <summary>
        /// 1.Billions() => 1000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static void Billions(ref double input) => input *= 1_000_000_000;
    }
}

/// <summary>
/// Extensions for number utilities <br />
/// 数值工具扩展
/// </summary>
public static partial class NumberExtensions
{
    /// <summary>
    /// 5.Tens() => 50
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Tens(this int input) => Numbers.ToNumber.Tens(input);

    /// <summary>
    /// 5.Tens() => 50
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Tens(this uint input) => Numbers.ToNumber.Tens(input);

    /// <summary>
    /// 5.Tens() => 50
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Tens(this long input) => Numbers.ToNumber.Tens(input);

    /// <summary>
    /// 5.Tens() => 50
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Tens(this ulong input) => Numbers.ToNumber.Tens(input);

    /// <summary>
    /// 5.Tens() => 50
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Tens(this double input) => Numbers.ToNumber.Tens(input);

    /// <summary>
    /// 4.Hundreds() => 400
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Hundreds(this int input) => Numbers.ToNumber.Hundreds(input);

    /// <summary>
    /// 4.Hundreds() => 400
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Hundreds(this uint input) => Numbers.ToNumber.Hundreds(input);

    /// <summary>
    /// 4.Hundreds() => 400
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Hundreds(this long input) => Numbers.ToNumber.Hundreds(input);

    /// <summary>
    /// 4.Hundreds() => 400
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Hundreds(this ulong input) => Numbers.ToNumber.Hundreds(input);

    /// <summary>
    /// 4.Hundreds() => 400
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Hundreds(this double input) => Numbers.ToNumber.Hundreds(input);

    /// <summary>
    /// 3.Thousands() => 3000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Thousands(this int input) => Numbers.ToNumber.Thousands(input);

    /// <summary>
    /// 3.Thousands() => 3000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Thousands(this uint input) => Numbers.ToNumber.Thousands(input);

    /// <summary>
    /// 3.Thousands() => 3000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Thousands(this long input) => Numbers.ToNumber.Thousands(input);

    /// <summary>
    /// 3.Thousands() => 3000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Thousands(this ulong input) => Numbers.ToNumber.Thousands(input);

    /// <summary>
    /// 3.Thousands() => 3000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Thousands(this double input) => Numbers.ToNumber.Thousands(input);

    /// <summary>
    /// 2.Millions() => 2000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Millions(this int input) => Numbers.ToNumber.Millions(input);

    /// <summary>
    /// 2.Millions() => 2000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Millions(this uint input) => Numbers.ToNumber.Millions(input);

    /// <summary>
    /// 2.Millions() => 2000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Millions(this long input) => Numbers.ToNumber.Millions(input);

    /// <summary>
    /// 2.Millions() => 2000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Millions(this ulong input) => Numbers.ToNumber.Millions(input);

    /// <summary>
    /// 2.Millions() => 2000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Millions(this double input) => Numbers.ToNumber.Millions(input);

    /// <summary>
    /// 1.Billions() => 1000000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Billions(this int input) => Numbers.ToNumber.Billions(input);

    /// <summary>
    /// 1.Billions() => 1000000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Billions(this uint input) => Numbers.ToNumber.Billions(input);

    /// <summary>
    /// 1.Billions() => 1000000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Billions(this long input) => Numbers.ToNumber.Billions(input);

    /// <summary>
    /// 1.Billions() => 1000000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Billions(this ulong input) => Numbers.ToNumber.Billions(input);

    /// <summary>
    /// 1.Billions() => 1000000000
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Billions(this double input) => Numbers.ToNumber.Billions(input);
}