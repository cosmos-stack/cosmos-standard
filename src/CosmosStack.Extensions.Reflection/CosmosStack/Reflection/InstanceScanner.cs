using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// Instance Scanner<br />
    /// 实例扫描器
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public abstract class InstanceScanner<TClass> : TypeScanner
    {
        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// 创建一个新的 <see cref="InstanceScanner{TClass}"/> 实例。
        /// </summary>
        protected InstanceScanner() { }

        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// 创建一个新的 <see cref="InstanceScanner{TClass}"/> 实例。
        /// </summary>
        /// <param name="scannerName"></param>
        protected InstanceScanner(string scannerName) : base(scannerName) { }

        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// 创建一个新的 <see cref="InstanceScanner{TClass}"/> 实例。
        /// </summary>
        /// <param name="baseType"></param>
        protected InstanceScanner(Type baseType) : base(baseType) { }

        /// <summary>
        /// Create a new <see cref="InstanceScanner{TClass}"/> instance.<br />
        /// 创建一个新的 <see cref="InstanceScanner{TClass}"/> 实例。
        /// </summary>
        /// <param name="scannerName"></param>
        /// <param name="baseType"></param>
        protected InstanceScanner(string scannerName, Type baseType) : base(scannerName, baseType) { }

        /// <summary>
        /// Scan, and return instances.<br />
        /// 扫描，并返回实例集合。
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TClass> ScanAndReturnInstances() =>
            Scan().Select(type => type.CreateInstance<TClass>());
    }
}