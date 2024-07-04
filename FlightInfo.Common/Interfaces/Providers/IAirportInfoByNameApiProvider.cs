using FlightInfo.Common.Models.Request;
using FlightInfo.Common.Models.Response;
using System.Threading.Tasks;

namespace FlightInfo.Common.Interfaces.Providers
{
    public interface IAirportInfoByNameApiProvider
    {
        Task<AirportInfo> GetAirportInfoByNameAsync(AirportInfoRequest request);
    }
}
