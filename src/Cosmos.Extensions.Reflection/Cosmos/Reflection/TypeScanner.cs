using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Cosmos.Disposables;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type Scanner <br />
    /// 类型扫描器
    /// </summary>
    public abstract class TypeScanner : IDisposable
    {
        // ReSharper disable once InconsistentNaming
        private const string DEFAULT_SKIP_ASSEMBLIES =
            "^System|^Mscorlib|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted";

        private readonly AnonymousDisposableObject _anonymousDisposableObject;

        /// <summary>
        /// Scanned result cache<br />
        /// 扫描结果缓存
        /// </summary>
        protected List<Type> ScannedResultCache { get; private set; } = new();

        /// <summary>
        /// Scanned result cached<br />
        /// 标记是否已缓存扫描结果
        /// </summary>
        protected bool ScannedResultCached { get; private set; }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/>.<br />
        /// 创建一个新的 <see cref="TypeScanner"/> 实例。
        /// </summary>
        protected TypeScanner() : this(string.Empty) { }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/>.<br />
        /// 创建一个新的 <see cref="TypeScanner"/> 实例。
        /// </summary>
        /// <param name="scannerName"></param>
        // ReSharper disable once UnusedParameter.Local
        protected TypeScanner(string scannerName)
        {
            _anonymousDisposableObject = AnonymousDisposableObject.Create(() =>
            {
                ScannedResultCache.Clear();
                ScannedResultCache = null;
                ScannedResultCached = false;
            });
        }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/>.<br />
        /// 创建一个新的 <see cref="TypeScanner"/> 实例。
        /// </summary>
        /// <param name="baseType"></param>
        protected TypeScanner(Type baseType) : this(string.Empty, baseType) { }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/>.<br />
        /// 创建一个新的 <see cref="TypeScanner"/> 实例。
        /// </summary>
        /// <param name="scannerName"></param>
        /// <param name="baseType"></param>
        protected TypeScanner(string scannerName, Type baseType) : this(scannerName)
        {
            BaseType = baseType;
        }

        /// <summary>
        /// Base type <br />
        /// 被扫描的基础类型
        /// </summary>
        protected Type BaseType { get; }

        /// <summary>
        /// Scan.<br />
        /// 执行扫描。
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Type> Scan()
        {
            if (ScannedResultCached)
            {
                foreach (var cachedType in ScannedResultCache)
                    yield return cachedType;
            }
            else
            {
                var assemblies = GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    if (NeedToIgnore(assembly))
                        continue;
                    var types = _typesFilter(assembly);
                    foreach (var type in types)
                    {
                        ScannedResultCache.Add(type);
                        yield return type;
                    }
                }

                ScannedResultCached = true;
            }

            // ReSharper disable once InconsistentNaming
            IEnumerable<Type> _typesFilter(Assembly assembly)
                => assembly.GetExportedTypes().Where(TypeFilter());
        }

        /// <summary>
        /// Get assemblies.<br />
        /// 获取程序集。
        /// </summary>
        /// <returns></returns>
        protected virtual Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();

        /// <summary>
        /// Get skip assemblies' namespaces.<br />
        /// 获取需跳过的命名空间清单，清单所列的命名空间内的类型将不会被合并入结果（并缓存）。
        /// </summary>
        /// <returns></returns>
        protected virtual string GetSkipAssembliesNamespaces() => DEFAULT_SKIP_ASSEMBLIES;

        /// <summary>
        /// Get limited assemblies' namespaces.<br />
        /// 获取指定命名空间下的类型，未被指定的命名空间内的类型将不会被合并入结果（并缓存）。
        /// </summary>
        /// <returns></returns>
        protected virtual string GetLimitedAssembliesNamespaces() => string.Empty;

        /// <summary>
        /// Type filter.<br />
        /// 类型过滤器 
        /// </summary>
        /// <returns></returns>
        protected abstract Func<Type, bool> TypeFilter();

        /// <summary>
        /// 根据 <see cref="GetSkipAssembliesNamespaces"/> 和 <see cref="GetLimitedAssembliesNamespaces"/> 判别扫描所得的程序集是否符合用户期待。
        /// 如何用户期待的程序集，其类型将进一步交由 <see cref="TypeFilter"/> 进行过滤。
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private bool NeedToIgnore(Assembly assembly)
        {
            var skipAssemblies = GetSkipAssembliesNamespaces();
            var limitedAssemblies = GetLimitedAssembliesNamespaces();
            var regexOptions = RegexOptions.IgnoreCase | RegexOptions.Compiled;
            if (string.IsNullOrWhiteSpace(skipAssemblies) && string.IsNullOrWhiteSpace(limitedAssemblies))
                return false;
            if (string.IsNullOrWhiteSpace(limitedAssemblies))
                return Regex.IsMatch(assembly.FullName, skipAssemblies, regexOptions);
            return !Regex.IsMatch(assembly.FullName, limitedAssemblies, regexOptions);
        }

        /// <summary>
        /// Dispose<br />
        /// 释放。
        /// </summary>
        public void Dispose()
        {
            _anonymousDisposableObject.Dispose();
        }
    }
}