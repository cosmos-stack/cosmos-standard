using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos
{
    public interface IObjectMapper
    {
        TTo MapTo<TFrom, TTo>(TFrom fromObject);
        TTo MapTo<TFrom, TTo>(TFrom fromObject, TTo toInstance);
    }
}
