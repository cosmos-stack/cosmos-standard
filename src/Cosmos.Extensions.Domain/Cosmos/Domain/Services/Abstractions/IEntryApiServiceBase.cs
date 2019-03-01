using System.Threading.Tasks;

namespace Cosmos.Domain.Services.Abstractions
{
    public interface IEntryApiServiceBase<in TParams, TResult> : IDomainService
    {
        TResult Execute(TParams @params);
        Task<TResult> ExecuteAsync(TParams @params);
    }
}
