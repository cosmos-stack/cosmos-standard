/*
 * Reference to
 *     https://github.com/brminnick/AsyncAwaitBestPractices
 *     Author:Brandon Minnick
 *     MIT

 */
namespace Cosmos.Asynchronous;

public static class ValueTaskFire
{
    /// <summary>
    /// Safety execute the ValueTask without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
    /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="exceptionAction"></param>
    /// <param name="continueOnCapturedContext"></param>
    public static void SafeFireAndForget(ValueTask task, Action<Exception> exceptionAction = null,
        bool continueOnCapturedContext = false)
    {
        TaskFire.HandleSafeFireAndForget(task, continueOnCapturedContext, exceptionAction);
    }

    /// <summary>
    /// Safety execute the ValueTask without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
    /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="exceptionAction"></param>
    /// <param name="continueOnCapturedContext"></param>
    /// <typeparam name="TException"></typeparam>
    public static void SafeFireAndForget<TException>(ValueTask task, Action<TException> exceptionAction = null, bool continueOnCapturedContext = false)
        where TException : Exception
    {
        TaskFire.HandleSafeFireAndForget(task, continueOnCapturedContext, exceptionAction);
    }
}

public static class ValueTaskFireExtensions
{
    /// <summary>
    /// Safety execute the ValueTask without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
    /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="exceptionAction"></param>
    /// <param name="continueOnCapturedContext"></param>
    public static void SafeFireAndForget(this ValueTask task, Action<Exception> exceptionAction = null, bool continueOnCapturedContext = false)
    {
        ValueTaskFire.SafeFireAndForget(task, exceptionAction, continueOnCapturedContext);
    }

    /// <summary>
    /// Safety execute the ValueTask without waiting for it to complete before moving to the next line of code; commonly known as "Fire and Forget".<br />
    /// Inspired by John Thiriet's blog post, "Removing Async Void": https://jhonthiriet.com/removing-async-void/.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="exceptionAction"></param>
    /// <param name="continueOnCapturedContext"></param>
    /// <typeparam name="TException"></typeparam>
    public static void SafeFireAndForget<TException>(this ValueTask task, Action<TException> exceptionAction = null, bool continueOnCapturedContext = false)
        where TException : Exception
    {
        ValueTaskFire.SafeFireAndForget(task, exceptionAction, continueOnCapturedContext);
    }
}