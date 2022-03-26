namespace Cosmos.Conversions.Common;

public static class CustomConvertManager
{
    private static readonly Dictionary<(Type, Type), Func<object, object>> _customConvertHandlers;
    private static readonly Dictionary<(Type, Type), Func<object, bool>> _customConvertCheckers;

    static CustomConvertManager()
    {
        _customConvertHandlers = new Dictionary<(Type, Type), Func<object, object>>();
        _customConvertCheckers = new Dictionary<(Type, Type), Func<object, bool>>();
    }

    public static bool TryGetChecker(Type sinceType, Type toType, out Func<object, bool> checker)
    {
        checker = NotFunc;
        if (sinceType is null || toType is null) return false;
        return _customConvertCheckers.TryGetValue((sinceType, toType), out checker);
    }

    public static bool TryGetConvertHandler(Type sinceType, Type toType, out Func<object, object> handler)
    {
        handler = NullFunc;
        if (sinceType is null || toType is null) return false;
        return _customConvertHandlers.TryGetValue((sinceType, toType), out handler);
    }
        
    private static Func<object, bool> NotFunc => _ => false;

    private static Func<object, object> NullFunc => _ => default;

    public static void Register(Type sinceType, Type toType, Func<object, bool> checker, Func<object, object> handler)
    {
        if (sinceType is null || toType is null) return;
        if (_customConvertHandlers.ContainsKey((sinceType, toType)) || _customConvertCheckers.ContainsKey((sinceType, toType))) return;
        _customConvertHandlers.Add((sinceType, toType), handler);
        _customConvertCheckers.Add((sinceType, toType), checker);
    }

    public static void RegisterOrOverride(Type sinceType, Type toType, Func<object, bool> checker, Func<object, object> handler)
    {
        if (sinceType is null || toType is null) return;
        _customConvertHandlers[(sinceType, toType)] = handler;
        _customConvertCheckers[(sinceType, toType)] = checker;
    }
}