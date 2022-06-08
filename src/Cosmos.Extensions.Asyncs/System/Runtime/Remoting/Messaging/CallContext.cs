#if !NETFRAMEWORK

using System.Collections.Concurrent;

namespace System.Runtime.Remoting.Messaging;

/// <summary>
/// CallContext for .NET Standard and .NET Core
/// for more info: http://www.cazzulino.com/callcontext-netstandard-netcore.html
/// </summary>
public static class CallContext
{
    private static readonly ConcurrentDictionary<string, AsyncLocal<object>> State;

    static CallContext()
    {
        State = new ConcurrentDictionary<string, AsyncLocal<object>>();
    }

#pragma warning disable CS8601

    /// <summary>
    /// Set data
    /// </summary>
    /// <param name="name"></param>
    /// <param name="data"></param>
    public static void SetData(string name, object data) =>
        State.GetOrAdd(name, _ => new AsyncLocal<object>()).Value = data;

#pragma warning restore CS8601

    /// <summary>
    /// Get data
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static object GetData(string name) =>
        State.TryGetValue(name, out var data) ? data.Value : null;
}

#endif