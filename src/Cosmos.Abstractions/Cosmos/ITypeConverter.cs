using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos
{
    /// <summary>
    /// Type Converter Meta Interface
    /// </summary>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    public interface ITypeConverter<in TFrom, out TTo>
    {
        /// <summary>
        /// To
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        TTo To(TFrom from);
    }
}
