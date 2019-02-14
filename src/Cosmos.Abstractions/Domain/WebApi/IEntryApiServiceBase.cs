using System.Threading.Tasks;

namespace Cosmos.Abstractions.Domain.WebApi
{
    public interface IEntryApiServiceBase<in TParams, TResult> : IDomainService
    {
        TResult Execute(TParams @params);
        Task<TResult> ExecuteAsync(TParams @params);
    }
}
