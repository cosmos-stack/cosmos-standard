namespace Cosmos.Disposables;

/*
 * Reference to: InCerryGit/Dispose.Scope
 *  GitHub: https://github.com/InCerryGit/Dispose.Scope
 *  Author: InCerry
 *  LICENSE: MIT
 */

public enum DisposableScopeOption
{
    /// <summary>
    /// A DisposeScope is required by the scope.
    /// It uses an ambient DisposeScope if one already exists.
    /// Otherwise, it creates a new DisposeScope before entering the scope.
    /// This is the default value. <br />
    /// 在作用域中需要一个 DisposeScope。
    /// 如果 DisposeScope 已经存在，则继续使用上下文中的 DisposeScope。
    /// 如果不存在，则在进入作用域之前创建一个新的 DisposeScope。
    /// 这是默认值。
    /// </summary>
    Required,

    /// <summary>
    /// A new DisposeScope is always created for the scope. <br />
    /// 总是创建一个新的 DisposeScope 用于作用域。
    /// </summary>
    RequiresNew,

    /// <summary>
    /// The ambient DisposeScope context is suppressed when creating the scope.
    /// All operations within the scope are done without an ambient DisposeScope context. <br />
    /// 创建作用域时，禁用上下文中的 DisposeScope。
    /// 所有在作用域中的操作都不会使用上下文中的 DisposeScope。
    /// </summary>
    Suppress,
}