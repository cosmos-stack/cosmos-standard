using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Cosmos.Disposables;

namespace Cosmos
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
        /// Scanned result cache <br />
        /// 结果缓存
        /// </summary>
        protected List<Type> ScannedResultCache { get; private set; } = new List<Type>();

        /// <summary>
        /// Scanned result cached <br />
        /// 标记扫描结果是否已缓存
        /// </summary>
        protected bool ScannedResultCached { get; private set; }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// 创建 <see cref="TypeScanner"/> 新实例
        /// </summary>
        protected TypeScanner() : this(string.Empty) { }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// 创建 <see cref="TypeScanner"/> 新实例
        /// </summary>
        /// <param name="scannerName"></param>
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
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// 创建 <see cref="TypeScanner"/> 新实例
        /// </summary>
        /// <param name="baseType"></param>
        protected TypeScanner(Type baseType) : this(string.Empty, baseType) { }

        /// <summary>
        /// Create a new instance of <see cref="TypeScanner"/> <br />
        /// 创建 <see cref="TypeScanner"/> 新实例
        /// </summary>
        /// <param name="scannerName"></param>
        /// <param name="baseType"></param>
        protected TypeScanner(string scannerName, Type baseType) : this(scannerName)
        {
            BaseType = baseType;
        }

        /// <summary>
        /// Base type <br />
        /// 基础类型
        /// </summary>
        protected Type BaseType { get; }

        /// <summary>
        /// Scan <br />
        /// 扫描
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
        /// Get assemblies <br />
        /// 获取程序集
        /// </summary>
        /// <returns></returns>
        protected virtual Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();

        /// <summary>
        /// Get skip assemblies' namespaces <br />
        /// 获取程序集的命名空间，以便跳过
        /// </summary>
        /// <returns></returns>
        protected virtual string GetSkipAssembliesNamespaces() => DEFAULT_SKIP_ASSEMBLIES;

        /// <summary>
        /// Get limited assemblies' namespaces <br />
        /// 获取程序集的命名空间，以便仅局限在这些命名空间中进行扫描
        /// </summary>
        /// <returns></returns>
        protected virtual string GetLimitedAssembliesNamespaces() => string.Empty;

        /// <summary>
        /// Type filter <br />
        /// 类型过滤器
        /// </summary>
        /// <returns></returns>
        protected abstract Func<Type, bool> TypeFilter();

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
        /// Dispose <br />
        /// 释放
        /// </summary>
        public void Dispose()
        {
            _anonymousDisposableObject.Dispose();
        }
    }
}