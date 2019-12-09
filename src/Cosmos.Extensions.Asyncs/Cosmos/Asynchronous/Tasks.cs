using System.Threading.Tasks;

namespace Cosmos.Asynchronous {
    /// <summary>
    /// Task utilities
    /// </summary>
    public static class Tasks {
#if NET451
        private static readonly Task _completedTask = Task.FromResult(true);
#endif
        /// <summary>
        /// Gets a task that has been completed successfully.
        /// </summary>
        /// <returns></returns>
        public static Task CompletedTask() {
#if NET451
            return _completedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}