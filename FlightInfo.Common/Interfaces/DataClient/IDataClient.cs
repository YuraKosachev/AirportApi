using System.Threading.Tasks;
using RestSharp;

namespace FlightInfo.Common.Interfaces.DataClient
{
    public interface IDataClient<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(string resource, Method method, TRequest model);
    }
}
