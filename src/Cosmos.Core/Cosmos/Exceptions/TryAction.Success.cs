namespace Cosmos.Exceptions;

/// <summary>
/// Success Action <br />
/// 成功的 Try Action 组件
/// </summary>
public class SuccessAction : TryAction
{
    private readonly int _hashOfAction;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuccessAction"/> class.
    /// </summary>
    /// <param name="hashOfAction"></param>
    internal SuccessAction(int hashOfAction)
    {
        _hashOfAction = hashOfAction;
    }

    /// <inheritdoc />
    public override bool IsFailure => false;

    /// <inheritdoc />
    public override bool IsSuccess => true;

    /// <inheritdoc />
    public override TryInvokingException Exception => default;

    /// <inheritdoc />
    public override string Cause => string.Empty;

    /// <inheritdoc />
    public override string ToString() => $"SuccessAction<Void>";

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(SuccessAction other) => other is not null && EqualityComparer<int>.Default.Equals(_hashOfAction, other._hashOfAction);

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is SuccessAction success && Equals(success);

    /// <inheritdoc />
    public override int GetHashCode() => EqualityComparer<int>.Default.GetHashCode(_hashOfAction);

    public override void Deconstruct(out bool tryResult, out TryInvokingException exception)
    {
        tryResult = IsSuccess;
        exception = default!;
    }

    /// <inheritdoc />
    public override TryAction Recover(Action<Exception> recoverFunction) => this;

    /// <inheritdoc />
    public override TryAction RecoverWith(Func<Exception, TryAction> recoverFunction) => this;

    /// <inheritdoc />
    public override TryAction Tap(Action successFunction = null, Action<Exception> failureFunction = null)
    {
        successFunction?.Invoke();
        return this;
    }
}