using System.Runtime.CompilerServices;
#if !NET452
using Collections.Pooled;
#endif

namespace Cosmos.Disposables;

/*
 * Reference to: InCerryGit/Dispose.Scope
 *  GitHub: https://github.com/InCerryGit/Dispose.Scope
 *  Author: InCerry
 *  LICENSE: MIT
 */

public sealed class DisposableScope : DisposableBase, IDisposable
{
    internal static readonly AsyncLocal<DisposableScope> Current = new();
    internal readonly DisposableScope Before;
#if NET452
    internal readonly List<IDisposable> CurrentScopedDisposables;
#else
    internal readonly PooledList<IDisposable> CurrentScopedDisposables;
#endif

    /// <summary>
    /// Raise an exception when call UseDisposableScope, no DisposableScope is found in context, default is true. <br />
    /// 当调用 UseDisposableScope 时，发现上下文中没有找到 DisposableScope 时，是否抛出异常，默认为 true。
    /// </summary>
    public static bool RaiseExceptionIfNoScope { get; set; } = true;

    /// <summary>
    /// Current <see cref="DisposableScope"/> Option. <br />
    /// 当前的 <see cref="DisposableScope"/> 选项。
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public DisposableScopeOption Option { get; }

    public DisposableScope() : this(DisposableScopeOption.Required, 8) { }

    public DisposableScope(DisposableScopeOption option, int size)
    {
        Option = option;
        Before = Current.Value;
        switch (option)
        {
            case DisposableScopeOption.Suppress:
                Current.Value = null;
                break;

            case DisposableScopeOption.RequiresNew:
#if NET452
                CurrentScopedDisposables = new List<IDisposable>(size);
#else
                CurrentScopedDisposables = new PooledList<IDisposable>(size);
#endif
                Current.Value = this;
                break;

            case DisposableScopeOption.Required:
            default:
                if (Current.Value is null)
                {
#if NET452
                    CurrentScopedDisposables = new List<IDisposable>(size);
#else
                    CurrentScopedDisposables = new PooledList<IDisposable>(size);
#endif
                    Current.Value = this;
                }

                break;
        }
    }

    private void AddToScope(IDisposable disposable)
    {
        CurrentScopedDisposables.Add(disposable);
    }

    private void RemoveFromScope(IDisposable disposable)
    {
        CurrentScopedDisposables.Remove(disposable);
    }

    public static void Register(IDisposable disposable)
    {
        if (disposable is null)
            return;
        if (Current.Value is null)
        {
            if (RaiseExceptionIfNoScope)
            {
                throw new InvalidOperationException("Register failed: no DisposableScope found in context.");
            }

            return;
        }

        Current.Value.AddToScope(disposable);
    }

    public static void Unregister(IDisposable disposable)
    {
        if (disposable is null)
            return;
        if (Current.Value is null)
        {
            if (RaiseExceptionIfNoScope)
            {
                throw new InvalidOperationException("Unregister failed: no DisposableScope found in context.");
            }

            return;
        }

        Current.Value.RemoveFromScope(disposable);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DisposableScope BeginScope(DisposableScopeOption option = DisposableScopeOption.Required, int size = 8)
    {
        return new DisposableScope(option, size);
    }

    protected override void OnDispose()
    {
        if (CurrentScopedDisposables != null)
        {
            for (var index = 0; index < CurrentScopedDisposables.Count; index++)
            {
                CurrentScopedDisposables[index].Dispose();
            }

            CurrentScopedDisposables.Clear();
#if !NET452
            CurrentScopedDisposables.Dispose();
#endif
        }

        Current.Value = Before;
    }
}