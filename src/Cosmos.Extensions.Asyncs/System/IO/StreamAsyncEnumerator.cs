using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
    internal class StreamAsyncEnumerator : IAsyncEnumerator<byte>
    {
        private readonly Stream _stream;

        private readonly byte[] _buffer;

        private int _bytesRemaining;

        private bool _endOfStream;

        private int _index;

        internal StreamAsyncEnumerator(Stream stream, int bufferSize)
        {
            // Validate parameters.
            if (bufferSize <= 0) throw new ArgumentOutOfRangeException(nameof(bufferSize), $"The {nameof(bufferSize)} parameter must be a positive value.");
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));

            // Assign values.
            _buffer = new byte[bufferSize];
        }

        public async Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            // If at end of stream, return false.
            if (_endOfStream) return false;

            // If the bytes read is 0, then fetch more data.
            if (_bytesRemaining == 0)
            {
                // Read.
                _bytesRemaining = await _stream.ReadAsync(_buffer, 0, _buffer.Length, cancellationToken).ConfigureAwait(false);

                // If the bytes read is zero, then at the end of the stream.
                _endOfStream = _bytesRemaining == 0;

                // Reset the index.
                _index = -1;

                // If end of stream, get out.
                if (_endOfStream) return false;
            }

            // Increment the index.
            ++_index;

            // Decrement the bytes remaining.
            --_bytesRemaining;

            // Return true.
            return true;
        }

        /// <summary>Gets the current element in the iteration.</summary>
        public byte Current
        {
            get
            {
                // If the index is less than zero, then need to move next.
                if (_index < 0) throw new InvalidOperationException("The MoveNext method must be called at least once before calling the Current property.");

                // If at the end of the stream, throw.
                if (_endOfStream) throw new InvalidOperationException("The end of the stream has been reached.");

                // Return the item at the index.
                return _buffer[_index];
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            // Dispose.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Dispose of unmanaged resources.

            // If not disposing, get out.
            if (!disposing) return;

            // Dispose of IDisposable implementations held onto.
        }

        ~StreamAsyncEnumerator()
        {
            // Dispose.
            Dispose(false);
        }

    }
}