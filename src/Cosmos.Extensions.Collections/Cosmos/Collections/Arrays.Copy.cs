using System;

namespace Cosmos.Collections
{
    public enum ArrayCopyOptions
    {
        Length = 0,
        SinceIndex = 1
    }

    /// <summary>
    /// Array utilities
    /// </summary>
    public static partial class Arrays
    {
        /// <summary>
        /// Cloning of a one-dimensional array
        /// </summary>
        public static T[] Copy<T>(T[] bytes)
        {
            var newBytes = new T[bytes.Length];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }

        /// <summary>
        /// Cloning of a two-dimensional array
        /// </summary>
        public static T[,] Copy<T>(T[,] bytes)
        {
            int width = bytes.GetLength(0),
                height = bytes.GetLength(1);
            var newBytes = new T[width, height];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }

        /// <summary>
        /// Cloning of three-dimensional array
        /// </summary>
        public static T[,,] Copy<T>(T[,,] bytes)
        {
            int x = bytes.GetLength(0),
                y = bytes.GetLength(1),
                z = bytes.GetLength(2);
            var newBytes = new T[x, y, z];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }

        /// <summary>
        /// Cloning of four-dimensional array
        /// </summary>
        public static T[,,,] Copy<T>(T[,,,] bytes)
        {
            int x = bytes.GetLength(0),
                y = bytes.GetLength(1),
                z = bytes.GetLength(2),
                m = bytes.GetLength(3);
            var newBytes = new T[x, y, z, m];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }

        /// <summary>
        /// Cloning of five-dimensional array
        /// </summary>
        public static T[,,,,] Copy<T>(T[,,,,] bytes)
        {
            int x = bytes.GetLength(0),
                y = bytes.GetLength(1),
                z = bytes.GetLength(2),
                m = bytes.GetLength(3),
                n = bytes.GetLength(4);
            var newBytes = new T[x, y, z, m, n];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }

        /// <summary>
        /// Cloning of six-dimensional array
        /// </summary>
        public static T[,,,,,] Copy<T>(T[,,,,,] bytes)
        {
            int x = bytes.GetLength(0),
                y = bytes.GetLength(1),
                z = bytes.GetLength(2),
                m = bytes.GetLength(3),
                n = bytes.GetLength(4),
                o = bytes.GetLength(5);
            var newBytes = new T[x, y, z, m, n, o];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }

        /// <summary>
        /// Cloning of seven-dimensional array
        /// </summary>
        public static T[,,,,,,] Copy<T>(T[,,,,,,] bytes)
        {
            int x = bytes.GetLength(0),
                y = bytes.GetLength(1),
                z = bytes.GetLength(2),
                m = bytes.GetLength(3),
                n = bytes.GetLength(4),
                o = bytes.GetLength(5),
                p = bytes.GetLength(6);
            var newBytes = new T[x, y, z, m, n, o, p];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }
    }

    public static partial class ArraysExtensions
    {
        /// <summary>
        /// Cloning of a one-dimensional array from an <see cref="T:System.Array" /> starting at the specified source index
        /// and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.
        /// The length and the indexes are specified as 64-bit integers.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="numericVal"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] bytes, int numericVal, ArrayCopyOptions options = ArrayCopyOptions.Length)
        {
            var arrayLength = options switch
            {
                ArrayCopyOptions.Length => numericVal,
                ArrayCopyOptions.SinceIndex => bytes.Length - numericVal,
                _ => numericVal
            };

            if (arrayLength <= 0)
            {
#if NET452
                return new T[0];
#else
                return Array.Empty<T>();
#endif
            }

            var array = new T[arrayLength];

            switch (options)
            {
                case ArrayCopyOptions.Length:
                    Array.Copy(bytes, array, numericVal);
                    break;

                case ArrayCopyOptions.SinceIndex:
                    Array.Copy(bytes, numericVal, array, 0, arrayLength);
                    break;

                default:
                    Array.Copy(bytes, array, numericVal);
                    break;
            }

            return array;
        }

        /// <summary>
        /// Cloning of a one-dimensional array from an <see cref="T:System.Array" /> starting at the specified source index
        /// and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.
        /// The length and the indexes are specified as 64-bit integers.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="numericVal"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] bytes, long numericVal, ArrayCopyOptions options = ArrayCopyOptions.Length)
        {
            var arrayLength = options switch
            {
                ArrayCopyOptions.Length => numericVal,
                ArrayCopyOptions.SinceIndex => bytes.Length - numericVal,
                _ => numericVal
            };

            if (arrayLength <= 0)
            {
#if NET452
                return new T[0];
#else
                return Array.Empty<T>();
#endif
            }

            var array = new T[arrayLength];

            switch (options)
            {
                case ArrayCopyOptions.Length:
                    Array.Copy(bytes, array, numericVal);
                    break;

                case ArrayCopyOptions.SinceIndex:
                    Array.Copy(bytes, numericVal, array, 0, arrayLength);
                    break;

                default:
                    Array.Copy(bytes, array, numericVal);
                    break;
            }

            return array;
        }

        /// <summary>
        /// Cloning of a one-dimensional array from an <see cref="T:System.Array" /> starting at the specified source index.
        /// Guarantees that all changes are undone if the copy does not succeed completely.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="length"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] bytes, int sourceIndex, int length)
        {
            var array = (bytes.Length - sourceIndex - length) switch
            {
                <= 0 => new T[bytes.Length - sourceIndex],
                > 0 => new T[length]
            };
            
            Array.Copy(bytes, sourceIndex, array, 0, length);
            
            return array;
        }

        /// <summary>
        /// Cloning of a one-dimensional array from an <see cref="T:System.Array" /> starting at the specified source index.
        /// Guarantees that all changes are undone if the copy does not succeed completely.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="length"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Copy<T>(this T[] bytes, long sourceIndex, long length)
        {
            var array = (bytes.Length - sourceIndex - length) switch
            {
                <= 0 => new T[bytes.Length - sourceIndex],
                > 0 => new T[length]
            };
            
            Array.Copy(bytes, sourceIndex, array, 0, length);
            
            return array;
        }

        /// <summary>
        /// Cloning of a one-dimensional array
        /// </summary>
        public static T[] Copy<T>(this T[] bytes)
        {
            return Arrays.Copy(bytes);
        }

        /// <summary>
        /// Cloning of a two-dimensional array
        /// </summary>
        public static T[,] Copy<T>(this T[,] bytes)
        {
            return Arrays.Copy(bytes);
        }

        /// <summary>
        /// Cloning of three-dimensional array
        /// </summary>
        public static T[,,] Copy<T>(this T[,,] bytes)
        {
            return Arrays.Copy(bytes);
        }

        /// <summary>
        /// Cloning of four-dimensional array
        /// </summary>
        public static T[,,,] Copy<T>(this T[,,,] bytes)
        {
            return Arrays.Copy(bytes);
        }

        /// <summary>
        /// Cloning of five-dimensional array
        /// </summary>
        public static T[,,,,] Copy<T>(this T[,,,,] bytes)
        {
            return Arrays.Copy(bytes);
        }

        /// <summary>
        /// Cloning of six-dimensional array
        /// </summary>
        public static T[,,,,,] Copy<T>(this T[,,,,,] bytes)
        {
            return Arrays.Copy(bytes);
        }

        /// <summary>
        /// Cloning of seven-dimensional array
        /// </summary>
        public static T[,,,,,,] Copy<T>(this T[,,,,,,] bytes)
        {
            return Arrays.Copy(bytes);
        }
    }

    public static partial class ArraysShortcutExtensions
    {
        /// <summary>
        /// Copies a range of elements from an <see cref="T:System.Array" /> starting at the specified source index
        /// and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.
        /// The length and the indexes are specified as 64-bit integers.
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="destinationArray"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, Array destinationArray, int length)
        {
            Array.Copy(sourceArray, destinationArray, length);
        }

        /// <summary>
        /// Copies a range of elements from an <see cref="T:System.Array" /> starting at the specified source index
        /// and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.
        /// The length and the indexes are specified as 64-bit integers.
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>
        /// Copies a range of elements from an <see cref="T:System.Array" /> starting at the specified source index
        /// and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.
        /// The length and the indexes are specified as 64-bit integers.
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="destinationArray"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, Array destinationArray, long length)
        {
            Array.Copy(sourceArray, destinationArray, length);
        }

        /// <summary>
        /// Copies a range of elements from an <see cref="T:System.Array" /> starting at the specified source index
        /// and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.
        /// The length and the indexes are specified as 64-bit integers.
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length)
        {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>
        /// Copies a range of elements from an <see cref="T:System.Array" /> starting at the specified source index
        /// and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.
        /// Guarantees that all changes are undone if the copy does not succeed completely.
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        public static void ConstrainedCopy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>
        /// Copies a specified number of bytes from a source array starting at a particular offset to a destination array starting at a particular offset.
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceOffset"></param>
        /// <param name="destinationArray"></param>
        /// <param name="dstOffset"></param>
        /// <param name="count"></param>
        public static void BlockCopy(this Array sourceArray, int sourceOffset, Array destinationArray, int dstOffset, int count)
        {
            Buffer.BlockCopy(sourceArray, sourceOffset, destinationArray, dstOffset, count);
        }
    }
}