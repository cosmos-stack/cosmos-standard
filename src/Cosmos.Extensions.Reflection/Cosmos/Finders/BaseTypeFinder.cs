using System;
using System.Linq;
using System.Reflection;

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
            Assembly[] assemblies = _allAssemblyFinder.FindAll(true);
            return assemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsDeriveClassFrom<TBaseType>()).Distinct().ToArray();
        }
    }
}