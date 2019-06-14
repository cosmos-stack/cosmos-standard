using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos
{
    /// <summary>
    /// Object Mapper Meta Interface
    /// </summary>
    public interface IObjectMapper
    {
        /// <summary>
        /// Map to
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <returns></returns>
        TTo MapTo<TFrom, TTo>(TFrom fromObject);

        /// <summary>
        /// Map to
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="toInstance"></param>
        /// <returns></returns>
        TTo MapTo<TFrom, TTo>(TFrom fromObject, TTo toInstance);
    }
}
