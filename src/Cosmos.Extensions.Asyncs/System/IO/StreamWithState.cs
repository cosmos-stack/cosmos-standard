namespace System.IO;

/// <summary>
/// Stream with state
/// </summary>
/// <typeparam name="T"></typeparam>
public class StreamWithState<T> : Stream
{
    private readonly Stream _stream;

    /// <summary>
    /// Create a new instance of <see cref="StreamWithState{T}"/>
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="state"></param>
    public StreamWithState(Stream stream, T state)
    {
        // Validate parameters.
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));

        // Assign values.
        State = state;
    }

    /// <summary>
    /// State
    /// </summary>
    public T State { get; }

    /// <inheritdoc />
    public override void Flush() => _stream.Flush();

    /// <inheritdoc />
    public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

    /// <inheritdoc />
    public override void SetLength(long value) => _stream.SetLength(value);

    /// <inheritdoc />
    public override int Read(byte[] buffer, int offset, int count) => _stream.Read(buffer, offset, count);

    /// <inheritdoc />
    public override void Write(byte[] buffer, int offset, int count) => _stream.Write(buffer, offset, count);

    /// <inheritdoc />
    public override bool CanRead => _stream.CanRead;

    /// <inheritdoc />
    public override bool CanSeek => _stream.CanSeek;

    /// <inheritdoc />
    public override bool CanWrite => _stream.CanWrite;

    /// <inheritdoc />
    public override long Length => _stream.Length;

    /// <inheritdoc />
    public override long Position
    {
        get => _stream.Position;
        set => _stream.Position = value;
    }

    /// <inheritdoc />
    public override bool CanTimeout => _stream.CanTimeout;

    /// <inheritdoc />
    public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken) =>
        _stream.CopyToAsync(destination, bufferSize, cancellationToken);

    /// <inheritdoc />
    public override Task FlushAsync(CancellationToken cancellationToken) => _stream.FlushAsync(cancellationToken);

    /// <inheritdoc />
    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
        _stream.ReadAsync(buffer, offset, count, cancellationToken);

    /// <inheritdoc />
    public override int ReadByte() => _stream.ReadByte();

    /// <inheritdoc />
    public override int ReadTimeout
    {
        get => _stream.ReadTimeout;
        set => _stream.ReadTimeout = value;
    }

    /// <inheritdoc />
    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => _stream.WriteAsync(buffer, offset, count, cancellationToken);

    /// <inheritdoc />
    public override void WriteByte(byte value) => _stream.WriteByte(value);

    /// <inheritdoc />
    public override int WriteTimeout
    {
        get => _stream.WriteTimeout;
        set => _stream.WriteTimeout = value;
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        // Call the base.
        base.Dispose(disposing);

        // Dispose of unmanaged resources.

        // If not disposing, get out.
        if (!disposing) return;

        // Dispose the state, if it is disposable.
        using (State as IDisposable) { }
    }
}