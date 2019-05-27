using System;
using System.Globalization;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateInfoExtensions
    {
        public static bool IsBetween(this DateInfo date, DateInfo from, DateInfo to, bool includeBoundary = true)
        {
            var dtRef = date.DateTimeRef;
            var fromRef = from.DateTimeRef;
            var toRef = to.DateTimeRef;
            return dtRef.IsBetween(fromRef, toRef, includeBoundary);
        }

        public static bool IsDateBetweenWithBoundary(this DateInfo date, DateInfo min, DateInfo max)
        {
            var dtRef = date.DateTimeRef;
            var minRef = min.DateTimeRef;
            var maxRef = max.DateTimeRef;
            return dtRef.IsDateBetweenWithBoundary(minRef, maxRef);
        }

        public static bool IsDateBetweenWithoutBoundary(this DateInfo date, DateInfo min, DateInfo max)
        {
            var dtRef = date.DateTimeRef;
            var minRef = min.DateTimeRef;
            var maxRef = max.DateTimeRef;
            return dtRef.IsDateBetweenWithoutBoundary(minRef, maxRef);
        }
    }
}
