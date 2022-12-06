using System.Runtime.Loader;

namespace Cosmos.Reflection;

/// <summary>
/// Assembly Visit Utilities <br />
/// 程序集访问工具集
/// </summary>
public static partial class AssemblyVisit
{
    public static NatashaDomain GetDomain(Type type)
    {
        return GetDomain(type.Assembly);
    }

    public static NatashaDomain GetDomain(Assembly assembly)
    {
        var assemblyDomain = AssemblyLoadContext.GetLoadContext(assembly);

        if (assemblyDomain == AssemblyLoadContext.Default)
        {
            return DomainManagement.CurrentDomain;
        }

        return (NatashaDomain)assemblyDomain;
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