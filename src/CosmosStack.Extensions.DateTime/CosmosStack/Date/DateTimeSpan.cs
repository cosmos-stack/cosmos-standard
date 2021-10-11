using System;
using System.Runtime.InteropServices;
using CosmosStack.Conversions.Common;
using CosmosStack.Reflection;
using NodaTime;

// ReSharper disable InconsistentNaming

/*
 * Reference to:
 *     FluentDateTime
 *     Author: Simon Cropp
 *     GitHub: https://github.com/FluentDateTime/FluentDateTime/blob/master/src/FluentDateTime/DateTimeSpan.cs
 *     NO LICENSE
 */

namespace CosmosStack.Date
{
    /// <summary>
    /// DateTime span
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DateTimeSpan : IEquatable<DateTimeSpan>, IComparable<TimeSpan>, IComparable<DateTimeSpan>
    {
        /// <summary>
        /// Days per year
        /// </summary>
        public const int DAYS_PER_YEAR = 365;
        
        static DateTimeSpan()
        {
            // to register DateTimeSpan ConvertHandler and Checker into CustomConvertManager
            CustomConvertManager.RegisterOrOverride(
                TypeClass.StringClazz, 
                typeof(DateTimeSpan), 
                StringConvBeHandler,
                StringConvToHandler);
        }

        /// <summary>
        /// Months
        /// </summary>
        public int Months { get; set; }

        /// <summary>
        /// Years
        /// </summary>
        public int Years { get; set; }

        /// <summary>
        /// Time span
        /// </summary>
        public TimeSpan TimeSpan { get; set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(DateTimeSpan other) => this == other;

        /// <summary>
        /// Adds two <see cref="DateTimeSpan"/> according operator +.
        /// </summary>
        /// <param name="number">The number to add to this <see cref="DateTimeSpan"/>.</param>
        /// <returns>The result of the addition.</returns>
        public DateTimeSpan Add(DateTimeSpan number) => AddInternal(this, number);

        /// <summary>
        /// Returns a new <see cref="DateTimeSpan"/> that adds the value of the specified <see cref="TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> to add to this <see cref="DateTimeSpan"/>.</param>
        /// <returns>The result of the addition.</returns>
        public DateTimeSpan Add(TimeSpan timeSpan) => AddInternal(this, timeSpan);

        /// <summary>
        /// Subtracts the number according operator -.
        /// </summary>
        /// <param name="dateTimeSpan">The matrix to subtract from this <see cref="DateTimeSpan"/>.</param>
        /// <returns>The result of the subtraction.</returns>
        public DateTimeSpan Subtract(DateTimeSpan dateTimeSpan) => SubtractInternal(this, dateTimeSpan);

        #region Operators
        
        /// <summary>
        /// Overload of the operator +
        /// </summary>
        /// <param name="left">The left hand <see cref="DateTimeSpan"/>.</param>
        /// <param name="right">The right hand <see cref="DateTimeSpan"/>.</param>
        /// <returns>The result of the addition.</returns>
        public static DateTimeSpan operator +(DateTimeSpan left, DateTimeSpan right)
        {
            return AddInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator +
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator +(DateTimeSpan left, TimeSpan right)
        {
            return AddInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator +
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator +(TimeSpan left, DateTimeSpan right)
        {
            return AddInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator +
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator +(DateTimeSpan left, Period right)
        {
            return AddInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator +
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator +(Period left, DateTimeSpan right)
        {
            return AddInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator +
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator +(DateTimeSpan left, Duration right)
        {
            return AddInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator +
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator +(Duration left, DateTimeSpan right)
        {
            return AddInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="left">The left hand <see cref="DateTimeSpan"/>.</param>
        /// <param name="right">The right hand <see cref="DateTimeSpan"/>.</param>
        /// <returns>The result of the subtraction.</returns>
        public static DateTimeSpan operator -(DateTimeSpan left, DateTimeSpan right)
        {
            return SubtractInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator -(TimeSpan left, DateTimeSpan right)
        {
            return SubtractInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator -(DateTimeSpan left, TimeSpan right)
        {
            return SubtractInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator -(Period left, DateTimeSpan right)
        {
            return SubtractInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator -(DateTimeSpan left, Period right)
        {
            return SubtractInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator -(Duration left, DateTimeSpan right)
        {
            return SubtractInternal(left, right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DateTimeSpan operator -(DateTimeSpan left, Duration right)
        {
            return SubtractInternal(left, right);
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        public static bool operator ==(DateTimeSpan left, DateTimeSpan right)
        {
            return left.Years == right.Years &&
                   left.Months == right.Months &&
                   left.TimeSpan == right.TimeSpan;
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(TimeSpan left, DateTimeSpan right)
        {
            return (DateTimeSpan) left == right;
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(DateTimeSpan left, TimeSpan right)
        {
            return left == (DateTimeSpan) right;
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Period left, DateTimeSpan right)
        {
            return (DateTimeSpan) left == right;
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(DateTimeSpan left, Period right)
        {
            return left == (DateTimeSpan) right;
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Duration left, DateTimeSpan right)
        {
            return (DateTimeSpan) left == right;
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(DateTimeSpan left, Duration right)
        {
            return left == (DateTimeSpan) right;
        }

        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        public static bool operator !=(DateTimeSpan left, DateTimeSpan right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(TimeSpan left, DateTimeSpan right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(DateTimeSpan left, TimeSpan right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Period left, DateTimeSpan right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(DateTimeSpan left, Period right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Duration left, DateTimeSpan right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(DateTimeSpan left, Duration right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Overload of the operator -
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeSpan operator -(DateTimeSpan value)
        {
            return value.Negate();
        }

        /// <summary>
        /// Overload of the operator &lt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(DateTimeSpan left, DateTimeSpan right)
        {
            return (TimeSpan) left < (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &lt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(DateTimeSpan left, TimeSpan right)
        {
            return (TimeSpan) left < right;
        }

        /// <summary>
        /// Overload of the operator &lt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(TimeSpan left, DateTimeSpan right)
        {
            return left < (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &lt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(DateTimeSpan left, Period right)
        {
            return (TimeSpan) left < right.AsTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &lt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Period left, DateTimeSpan right)
        {
            return left.AsTimeSpan() < (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &lt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(DateTimeSpan left, Duration right)
        {
            return (TimeSpan) left < right.ToTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &lt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Duration left, DateTimeSpan right)
        {
            return left.ToTimeSpan() < (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &lt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(DateTimeSpan left, DateTimeSpan right)
        {
            return (TimeSpan) left <= (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &lt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(DateTimeSpan left, TimeSpan right)
        {
            return (TimeSpan) left <= right;
        }

        /// <summary>
        /// Overload of the operator &lt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(TimeSpan left, DateTimeSpan right)
        {
            return left <= (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &lt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(DateTimeSpan left, Period right)
        {
            return (TimeSpan) left <= right.AsTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &lt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Period left, DateTimeSpan right)
        {
            return left.AsTimeSpan() <= (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &lt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(DateTimeSpan left, Duration right)
        {
            return (TimeSpan) left <= right.ToTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &lt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Duration left, DateTimeSpan right)
        {
            return left.ToTimeSpan() <= (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(DateTimeSpan left, DateTimeSpan right)
        {
            return (TimeSpan) left > (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(DateTimeSpan left, TimeSpan right)
        {
            return (TimeSpan) left > right;
        }

        /// <summary>
        /// Overload of the operator &gt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(TimeSpan left, DateTimeSpan right)
        {
            return left > (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(DateTimeSpan left, Period right)
        {
            return (TimeSpan) left > right.AsTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &gt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Period left, DateTimeSpan right)
        {
            return left.AsTimeSpan() > (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(DateTimeSpan left, Duration right)
        {
            return (TimeSpan) left > right.ToTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &gt;
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Duration left, DateTimeSpan right)
        {
            return left.ToTimeSpan() > (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(DateTimeSpan left, DateTimeSpan right)
        {
            return (TimeSpan) left >= (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(DateTimeSpan left, TimeSpan right)
        {
            return (TimeSpan) left >= right;
        }

        /// <summary>
        /// Overload of the operator &gt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(TimeSpan left, DateTimeSpan right)
        {
            return left >= (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(DateTimeSpan left, Period right)
        {
            return (TimeSpan) left >= right.AsTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &gt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Period left, DateTimeSpan right)
        {
            return left.AsTimeSpan() >= (TimeSpan) right;
        }

        /// <summary>
        /// Overload of the operator &gt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(DateTimeSpan left, Duration right)
        {
            return (TimeSpan) left >= right.ToTimeSpan();
        }

        /// <summary>
        /// Overload of the operator &gt; or equals to
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Duration left, DateTimeSpan right)
        {
            return left.ToTimeSpan() >= (TimeSpan) right;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="DateTimeSpan"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="dateTimeSpan">The DateTimeSpan.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TimeSpan(DateTimeSpan dateTimeSpan)
        {
            var daysFromYears = DAYS_PER_YEAR * dateTimeSpan.Years;
            var daysFromMonths = 30 * dateTimeSpan.Months;
            var days = daysFromMonths + daysFromYears;
            return new TimeSpan(days, 0, 0, 0) + dateTimeSpan.TimeSpan;
        }

        /// <summary>
        /// Performs an implicit conversion from a <see cref="TimeSpan"/> to <see cref="DateTimeSpan"/>.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> that will be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateTimeSpan(TimeSpan timeSpan)
        {
            return new() {TimeSpan = timeSpan};
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="DateTimeSpan"/> to <see cref="Period"/>.
        /// </summary>
        /// <param name="dateTimeSpan"></param>
        /// <returns></returns>
        public static implicit operator Period(DateTimeSpan dateTimeSpan)
        {
            return Period.FromTicks(dateTimeSpan.Ticks);
        }

        /// <summary>
        /// Performs an implicit conversion from a <see cref="Period"/> to <see cref="DateTimeSpan"/>.
        /// </summary>
        /// <param name="period">The <see cref="Period"/> that will be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateTimeSpan(Period period)
        {
            return new()
            {
                Years = period.Years,
                Months = period.Months,
                TimeSpan = TimeSpan.FromTicks(period.Ticks)
            };
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="DateTimeSpan"/> to <see cref="Duration"/>.
        /// </summary>
        /// <param name="dateTimeSpan"></param>
        /// <returns></returns>
        public static implicit operator Duration(DateTimeSpan dateTimeSpan)
        {
            return Duration.FromTimeSpan(dateTimeSpan.TimeSpan);
        }

        /// <summary>
        /// Performs an implicit conversion from a <see cref="Duration"/> to <see cref="DateTimeSpan"/>.
        /// </summary>
        /// <param name="duration">The <see cref="Duration"/> that will be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateTimeSpan(Duration duration)
        {
            return new() {TimeSpan = duration.ToTimeSpan()};
        }

        #endregion

        #region Clone

        /// <summary>
        /// Creates a new object that is a copy of the current instance. <br />
        /// 克隆当前实例
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new DateTimeSpan
            {
                TimeSpan = TimeSpan,
                Months = Months,
                Years = Years
            };
        }
        
        #endregion

        #region Override Methods
        
        /// <inheritdoc />
        public override string ToString()
        {
            return ((TimeSpan) this).ToString();
        }

        public string ToString(string format)
        {
            return ((TimeSpan) this).ToString(format);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return ((TimeSpan) this).ToString(format, provider);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();
            if (type == typeof(DateTimeSpan))
            {
                return this == (DateTimeSpan) obj;
            }

            if (type == typeof(TimeSpan))
            {
                return this == (TimeSpan) obj;
            }

            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return Months.GetHashCode() ^ Years.GetHashCode() ^ TimeSpan.GetHashCode();
        }

        #endregion
        
        #region DateTimeSpan ops others

        static DateTimeSpan AddInternal(DateTimeSpan left, TimeSpan right)
        {
            return new()
            {
                Months = left.Months,
                Years = left.Years,
                TimeSpan = left.TimeSpan + right
            };
        }

        static DateTimeSpan SubtractInternal(DateTimeSpan left, TimeSpan right)
        {
            return new()
            {
                Months = left.Months,
                Years = left.Years,
                TimeSpan = left.TimeSpan - right
            };
        }

        static DateTimeSpan AddInternal(DateTimeSpan left, Period right)
        {
            return left + right.AsDateTimeSpan();
        }

        static DateTimeSpan SubtractInternal(DateTimeSpan left, Period right)
        {
            return left - right.AsDateTimeSpan();
        }

        static DateTimeSpan AddInternal(DateTimeSpan left, Duration right)
        {
            return left + right.ToTimeSpan();
        }

        static DateTimeSpan SubtractInternal(DateTimeSpan left, Duration right)
        {
            return left - right.ToTimeSpan();
        }
        
        #endregion

        #region Others ops DateTimeSpan
        
        internal static DateTimeSpan SubtractInternal(TimeSpan left, DateTimeSpan right)
        {
            return new()
            {
                Months = -right.Months,
                Years = -right.Years,
                TimeSpan = left - right.TimeSpan
            };
        }

        static DateTimeSpan SubtractInternal(Period left, DateTimeSpan right)
        {
            return left.AsDateTimeSpan() - right;
        }

        static DateTimeSpan SubtractInternal(Duration left, DateTimeSpan right)
        {
            return left.ToTimeSpan() - right;
        }
        
        #endregion

        #region DateTimeSpan ops DateTimeSpan
        
        static DateTimeSpan AddInternal(DateTimeSpan left, DateTimeSpan right)
        {
            return new()
            {
                Years = left.Years + right.Years,
                Months = left.Months + right.Months,
                TimeSpan = left.TimeSpan + right.TimeSpan
            };
        }

        static DateTimeSpan SubtractInternal(DateTimeSpan left, DateTimeSpan right)
        {
            return new()
            {
                Years = left.Years - right.Years,
                Months = left.Months - right.Months,
                TimeSpan = left.TimeSpan - right.TimeSpan
            };
        }
        
        #endregion
        
        #region Fields Getters
        
        /// <summary>
        /// Gets the number of ticks that represent the value of the current <see cref="TimeSpan"/> structure. <br />
        /// 获取表示当前 <see cref="TimeSpan"/> 结构值的刻度数。
        /// </summary>
        public long Ticks => ((TimeSpan) this).Ticks;

        /// <summary>
        /// Gets days <br />
        /// 获取天
        /// </summary>
        public int Days => ((TimeSpan) this).Days;

        /// <summary>
        /// Gets Hours <br />
        /// 获取小时
        /// </summary>
        public int Hours => ((TimeSpan) this).Hours;

        /// <summary>
        /// Gets milliseconds <br />
        /// 获取毫秒
        /// </summary>
        public int Milliseconds => ((TimeSpan) this).Milliseconds;

        /// <summary>
        /// Gets minutes <br />
        /// 获取分钟
        /// </summary>
        public int Minutes => ((TimeSpan) this).Minutes;

        /// <summary>
        /// Gets seconds <br />
        /// 获取秒
        /// </summary>
        public int Seconds => ((TimeSpan) this).Seconds;

        /// <summary>
        /// Total days <br />
        /// 总计天数
        /// </summary>
        public double TotalDays => ((TimeSpan) this).TotalDays;

        /// <summary>
        /// Total hours <br />
        /// 总计小时
        /// </summary>
        public double TotalHours => ((TimeSpan) this).TotalHours;

        /// <summary>
        /// Total milliseconds <br />
        /// 总计毫秒
        /// </summary>
        public double TotalMilliseconds => ((TimeSpan) this).TotalMilliseconds;

        /// <summary>
        /// Total minutes <br />
        /// 总计分钟
        /// </summary>
        public double TotalMinutes => ((TimeSpan) this).TotalMinutes;

        /// <summary>
        /// Total seconds <br />
        /// 总计秒数
        /// </summary>
        public double TotalSeconds => ((TimeSpan) this).TotalSeconds;
        
        #endregion
        
        #region CompareTo
        
        /// <inheritdoc />
        public int CompareTo(TimeSpan other)
        {
            return ((TimeSpan) this).CompareTo(other);
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object value)
        {
            if (value is TimeSpan timeSpan)
            {
                return ((TimeSpan) this).CompareTo(timeSpan);
            }

            throw new ArgumentException("Value must be a TimeSpan", "value");
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareTo(DateTimeSpan value)
        {
            return ((TimeSpan) this).CompareTo(value);
        }

        #endregion

        /// <summary>
        /// Negate <br />
        /// 取负值
        /// </summary>
        /// <returns></returns>
        public TimeSpan Negate()
        {
            return new DateTimeSpan
            {
                TimeSpan = -TimeSpan,
                Months = -Months,
                Years = -Years
            };
        }
    }
}