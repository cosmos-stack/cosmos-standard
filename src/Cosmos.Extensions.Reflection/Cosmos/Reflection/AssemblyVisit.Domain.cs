#if !NETFRAMEWORK

using System;
using System.Reflection;
using System.Runtime.Loader;
using Natasha.Framework;

namespace Cosmos.Reflection
{
    public static partial class AssemblyVisit
    {
        public static DomainBase GetDomain(Type type)
        {
            return GetDomain(type.Assembly);
        }

        public static DomainBase GetDomain(Assembly assembly)
        {
            var assemblyDomain = AssemblyLoadContext.GetLoadContext(assembly);

            if (assemblyDomain == AssemblyLoadContext.Default)
            {
                return DomainManagement.Default;
            }

            return (DomainBase)assemblyDomain;
        }
        
        public static void RemoveReferences(Type type)
        {
            RemoveReferences(type.Assembly);
        }

        public static void RemoveReferences(Assembly assembly)
        {
            GetDomain(assembly).RemoveReference(assembly);
        }
        
        public static void DisposeDomain(Type type)
        {
            DisposeDomain(type.Assembly);
        }

        public static void DisposeDomain(Assembly assembly)
        {
            GetDomain(assembly).Dispose();
        }
    }
}

#endif