using System.Threading.Tasks;

namespace Cosmos.Domain.Services.Abstractions {
    /// <summary>
    /// Interface for entry api service
    /// </summary>
    /// <typeparam name="TParams"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IEntryApiServiceBase<in TParams, TResult> : IDomainService {
        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        TResult Execute(TParams @params);

        /// <summary>
        /// Execute async
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        Task<TResult> ExecuteAsync(TParams @params);
    }
}