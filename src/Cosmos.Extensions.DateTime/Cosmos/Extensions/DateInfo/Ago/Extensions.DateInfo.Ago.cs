using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static class DateInfoAgoExtensions
    {
        public static string ToAgo(this DateInfo date)
        {
            return (DateTime.Now - date).ToAgo();
        }
    }
}
