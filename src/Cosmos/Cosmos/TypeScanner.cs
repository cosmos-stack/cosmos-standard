using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Cosmos.Disposables;

namespace Cosmos
{
    public abstract class TypeScanner : IDisposable
    {
        private const string DEFAULT_SKIP_ASSEMBLIES =
            "^System|^Mscorlib|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted";

        private readonly AnonymousDisposableObject _anonymousDisposableObject;

        protected List<Type> ScannedResultCache { get; private set; } = new List<Type>();
        protected bool ScannedResultCached { get; private set; }

        protected TypeScanner() : this(string.Empty) { }

        protected TypeScanner(string scannerName)
        {
            _anonymousDisposableObject = AnonymousDisposableObject.Create(() =>
             {
                 ScannedResultCache.Clear();
                 ScannedResultCache = null;
                 ScannedResultCached = false;
             });
        }

        protected TypeScanner(Type baseType) : this(string.Empty, baseType) { }

        protected TypeScanner(string scannerName, Type baseType) : this(scannerName)
        {
            BaseType = baseType;
        }

        protected Type BaseType { get; }

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

        protected virtual Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();

        protected virtual string GetSkipAssembliesNamespaces() => DEFAULT_SKIP_ASSEMBLIES;

        protected virtual string GetLimitedAssembliesNamespaces() => string.Empty;

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

        public void Dispose()
        {
            _anonymousDisposableObject.Dispose();
        }
    }
}