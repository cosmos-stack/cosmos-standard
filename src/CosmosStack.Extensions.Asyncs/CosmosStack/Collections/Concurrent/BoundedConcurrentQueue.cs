using System;
using System.Collections.Concurrent;
using System.Threading;

namespace CosmosStack.Collections.Concurrent
{
    /// <summary>
    /// Bounded concurrent queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BoundedConcurrentQueue<T>
    {
        // ReSharper disable once InconsistentNaming
        private const int NON_BOUNDED = -1;
        private readonly ConcurrentQueue<T> _queue = new();
        private readonly int _queueLimit;
        private int _counter;

        /// <summary>
        /// Create a new instance of <see cref="BoundedConcurrentQueue{T}"/>.
        /// </summary>
        public BoundedConcurrentQueue()
        {
            _queueLimit = NON_BOUNDED;
        }

        /// <summary>
        /// Create a new instance of <see cref="BoundedConcurrentQueue{T}"/>.
        /// </summary>
        /// <param name="queueLimit"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public BoundedConcurrentQueue(int queueLimit)
        {
            if (queueLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(queueLimit), "queue limit must be positive");

            _queueLimit = queueLimit;
        }

        /// <summary>
        /// Gets queue count <br />
        /// 获取队内元素总数
        /// </summary>
        public int Count => _queue.Count;

        /// <summary>
        /// Try dequeue <br />
        /// 尝试出队
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryDequeue(out T item)
        {
            if (_queueLimit == NON_BOUNDED)
                return _queue.TryDequeue(out item);

            var result = false;
            try
            {
                //...
            }
            finally // prevent state corrupt while aborting
            {
                if (_queue.TryDequeue(out item))
                {
                    Interlocked.Decrement(ref _counter);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Try enqueue <br />
        /// 尝试入队
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryEnqueue(T item)
        {
            if (_queueLimit == NON_BOUNDED)
            {
                _queue.Enqueue(item);
                return true;
            }

            var result = true;

            try
            {
                //...
            }
            finally
            {
                if (Interlocked.Increment(ref _counter) <= _queueLimit)
                {
                    _queue.Enqueue(item);
                }
                else
                {
                    Interlocked.Decrement(ref _counter);
                    result = false;
                }
            }

            return result;
        }
    }
}