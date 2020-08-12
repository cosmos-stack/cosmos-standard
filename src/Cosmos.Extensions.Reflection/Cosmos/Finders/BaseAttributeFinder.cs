using System;
using System.Linq;
using System.Reflection;

namespace Cosmos.Finders
{
    /// <summary>
    /// Attribute type finder
    /// </summary>
    /// <typeparam name="TAttributeType"></typeparam>
    public class BaseAttributeFinder<TAttributeType> : BaseFinder<Type>, ITypeFinder
        where TAttributeType : Attribute
    {
        private readonly IAllAssemblyFinder _allAssemblyFinder;

        public BaseAttributeFinder(IAllAssemblyFinder allAssemblyFinder)
        {
            _allAssemblyFinder = allAssemblyFinder;
        }

        protected override Type[] FindAllItems()
        {
            Assembly[] assemblies = _allAssemblyFinder.FindAll(true);
            return assemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass && !type.IsAbstract && type.HasAttribute<TAttributeType>()).Distinct().ToArray();
        }
    }
}