namespace Cosmos.Collections.Internals;

internal class InternalNullIfEmptySkipFirstMoveNextEnumeratorWrapper<T> : IEnumerator<T>
{
    public InternalNullIfEmptySkipFirstMoveNextEnumeratorWrapper(IEnumerator<T> inner)
    {
        // Validate parameters.
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    private bool _skipped;

    private readonly IEnumerator<T> _inner;

    public bool MoveNext()
    {
        // If not skipped, skip and return.
        if (!_skipped)
        {
            // Set to true.
            _skipped = true;

            // Return true.
            return true;
        }

        // Pass through.
        return _inner.MoveNext();
    }

    public void Reset()
    {
        // Reset.
        // NOTE: We do not reset skipped because we
        // already know the call to move next will succeed
        // so there's no reason to check on subsequent calls.
        _inner.Reset();
    }

    public T Current => _inner.Current;

    object IEnumerator.Current => Current;

    public void Dispose() => _inner.Dispose();
}