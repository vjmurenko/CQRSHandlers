using System.Threading.Tasks;

namespace CqrsFramework
{
    public interface IDispatcher
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
    }
}