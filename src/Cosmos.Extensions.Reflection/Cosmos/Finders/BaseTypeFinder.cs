using System;
using System.Linq;
using Cosmos.Reflection;

namespace Cosmos.Finders
{
    /// <summary>
    /// Base type finder
    /// </summary>
    public abstract class BaseTypeFinder<TBaseType> : BaseFinder<Type>, ITypeFinder
    {
        private readonly IAllAssemblyFinder _allAssemblyFinder;

        protected BaseTypeFinder(IAllAssemblyFinder allAssemblyFinder)
        {
            _allAssemblyFinder = allAssemblyFinder;
        }

        protected override Type[] FindAllItems()
        {
            return _allAssemblyFinder
                   .FindAll(true)
                   .SelectMany(assembly => assembly.GetTypes())
                   .Where(type => TypeReflections.IsTypeDerivedFrom(type, typeof(TBaseType)))
                   .Distinct()
                   .ToArray();
        }
    }
}