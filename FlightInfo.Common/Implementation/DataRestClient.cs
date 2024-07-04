using System.Threading.Tasks;
using FlightInfo.Common.Interfaces.DataClient;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using FlightInfo.Common.Exceptions;
using System.Collections.Generic;

namespace FlightInfo.Common.Implementation
{
    public abstract class DataRestClient<TRequest,TResponse> : IDataClient<TRequest, TResponse>
    {
        public async Task<TResponse> ExecuteAsync(string resource, Method method, TRequest model)
        {
            using (var client = new RestClient()) 
            {
                var request = new RestRequest(resource, method);
                SetRequestParams(request, model);
                var response = await client.ExecuteAsync(request);
                return ResponseHandler(response);
            }
        }
        protected virtual void SetRequestParams(RestRequest request, TRequest model) { }

        protected virtual TResponse ResponseHandler(RestResponse response) {

            var okStatus = new List<HttpStatusCode> { HttpStatusCode.OK };

            if (!okStatus.Contains(response.StatusCode))
            {
                ExceptionHandling(response);
                throw new ApiServiceException($"Something went wrong! Take look to status code: {response.StatusCode}");
            }

            return JsonConvert.DeserializeObject<TResponse>(response?.Content);
        }

        protected virtual void ExceptionHandling(RestResponse response) { }
    }
}
