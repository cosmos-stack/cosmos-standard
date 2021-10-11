using System;
using System.Linq;
using TypeReflections = CosmosStack.Reflection.TypeReflections;

namespace CosmosStack.Finders
{
    /// <summary>
    /// Base type finder <br />
    /// 类型查找器基类
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