using System.Collections.Concurrent;
using Cosmos.Reflection.Reflectors.Internals;

namespace Cosmos.Reflection;

/*
 * Modify from NCC AspectCore
 * Source: <see cref="https://github.com/dotnetcore/AspectCore-Framework/blob/master/src/AspectCore.Extensions.Reflection/MethodSignature.cs"/>
 */

/// <summary>
/// Method signature
/// </summary>
public readonly struct MethodSignature
{
    private static readonly ConcurrentDictionary<PairOf<MethodBase, string>, int> Signatures = new();

    private readonly int _signature;

    public int Value => _signature;

#if NET5_0_OR_GREATER
    public string Name { get; init; }
#else
    public string Name { get; }
#endif

    public MethodSignature(MethodBase method) : this(method, method?.Name) { }

    public MethodSignature(MethodBase method, string name)
    {
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        Name = name;
        _signature = Signatures.GetOrAdd(PairOf.New(method, name), GetSignatureCode);
    }

    #region Internal override methods

    public override bool Equals(object obj) => obj is MethodSignature signature && _signature == signature._signature;

    public override int GetHashCode() => _signature;

    #endregion

    #region Internal override operators

    public static bool operator !=(MethodSignature signature, MethodSignature other)
    {
        return signature._signature != other._signature;
    }

    public static bool operator ==(MethodSignature signature, MethodSignature other)
    {
        return signature._signature == other._signature;
    }

    #endregion

    private static int GetSignatureCode(PairOf<MethodBase, string> pair)
    {
        var method = pair.Item1;
        var name = pair.Item2 ?? method.Name;
        unchecked
        {
            var signatureCode = name.GetHashCode();
            var parameterTypes = method.GetParameterTypes();
            if (parameterTypes.Length > 0)
            {
                signatureCode = (signatureCode * 397) ^ parameterTypes.Length.GetHashCode();
                foreach (var paramterType in parameterTypes)
                {
                    if (paramterType.IsGenericParameter)
                        continue;

                    if (paramterType.GetTypeInfo().IsGenericType)
                        signatureCode = GetSignatureCode(signatureCode, paramterType);
                    else
                        signatureCode = (signatureCode * 397) ^ paramterType.GetHashCode();
                }
            }

            if (method.IsGenericMethod)
                signatureCode = (signatureCode * 397) ^ method.GetGenericArguments().Length.GetHashCode();

            return signatureCode;
        }
    }

    private static int GetSignatureCode(int signatureCode, Type genericType)
    {
        signatureCode = (signatureCode * 397) ^ genericType.GetGenericTypeDefinition().GetHashCode();
        signatureCode = (signatureCode * 397) ^ genericType.GenericTypeArguments.Length.GetHashCode();
        foreach (var argument in genericType.GenericTypeArguments)
        {
            if (argument.IsGenericParameter)
                continue;

            if (argument.GetTypeInfo().IsGenericType)
                signatureCode = GetSignatureCode(signatureCode, argument);
            else
                signatureCode = (signatureCode * 397) ^ argument.GetHashCode();
        }

        return signatureCode;
    }
}