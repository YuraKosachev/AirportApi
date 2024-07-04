using FlightInfo.Common.Implementation;
using FlightInfo.Common.Interfaces.Providers;
using FlightInfo.Common.Models.Configurations;
using FlightInfo.Common.Models.Request;
using FlightInfo.Common.Models.Response;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Threading.Tasks;

namespace FlightInfo.Provider.ApiProviders
{
    public class AirportInfoByNameApiProvider : CteleportDataRestClient<AirportInfoRequest, AirportInfo>, IAirportInfoByNameApiProvider
    {
        private readonly ApiServicesConfiguration _configuration;
        public AirportInfoByNameApiProvider(IOptions<ApiServicesConfiguration> configuration)
        {
            _configuration = configuration?.Value;
        }
        public async Task<AirportInfo> GetAirportInfoByNameAsync(AirportInfoRequest request)
        {
            return await ExecuteAsync(_configuration.Cteleport.AirportInfoByIata.Resource,
                _configuration.Cteleport.AirportInfoByIata.Method,
                request);
        }

        protected override void SetRequestParams(RestRequest request, AirportInfoRequest model)
        {
            base.SetRequestParams(request, model);

            if (!string.IsNullOrEmpty(model.Name))
                request.AddParameter("iata", model.Name, ParameterType.UrlSegment);
        }
    }
}
