using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ObjectExtensions
    {
        public static bool IsOn(this byte source, params byte[] list)
        {
            return IsOn<byte>(source, list);
        }

        public static bool IsOn(this short source, params short[] list)
        {
            return IsOn<short>(source, list);
        }

        public static bool IsOn<T>(this T source, params T[] list) where T : IComparable
        {
            for (var i = 0; i < list.Length; i++)
            {
                if (list[i].CompareTo(source) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsOn<T>(this T source, IEnumerable<T> list) where T : IComparable
        {
            foreach (var item in list)
            {
                if (item.CompareTo(source) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsOn<T>(this T source, HashSet<T> list) where T : IComparable
        {
            return list.Contains(source);
        }

        public static bool IsOnIgnoreCase(this string source, params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (source.EqualsIgnoreCase(list[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
