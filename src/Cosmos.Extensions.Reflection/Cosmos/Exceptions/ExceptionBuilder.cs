#if !NET451 && !NET452

using System;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Exception builder
    /// </summary>
    public static class ExceptionBuilder
    {
        /// <summary>
        /// Create a new builder for of <typeparamref name="TException"/> <see cref="ExceptionBuilder{TException}"/>.<br />
        /// If you want to use this feature, please add following xml-node in your csproj file:<br />
        /// &lt;PreserveCompilationContext&gt;true&lt;/PreserveCompilationContext&gt;<br />
        /// This feature is supported by LanX, the author of NCC Natasha.<br />
        /// <br />
        /// 创建一个用于构建 <typeparamref name="TException"/> <see cref="ExceptionBuilder{TException}"/> 的 builder。<br />
        /// 如果你想使用此功能，需要在 csproj 文件中添加下述 Xml 节点：<br />
        /// &lt;PreserveCompilationContext&gt;true&lt;/PreserveCompilationContext&gt;<br />
        /// 本功能由 NCC Natasha 的作者 LanX 提供支持。
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IFluentExceptionBuilder<TException> Create<TException>() where TException : Exception
            => new ExceptionBuilder<TException>();
    }
}

#endif