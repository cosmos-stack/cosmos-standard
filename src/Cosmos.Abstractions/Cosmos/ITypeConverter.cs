using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos
{
    public interface ITypeConverter<in TFrom, out TTo>
    {
        TTo To(TFrom from);
    }
}
