using FlightInfo.Common.Enums;
using FlightInfo.Common.Models.Request;
using FlightInfo.Common.Models.Response;
using FlightInfo.Common.Models.View;
using System.Threading.Tasks;

namespace FlightInfo.Common.Interfaces.Services
{
    public interface IFlightService
    {
        Task<AirportInfo> GetAirportInfoByNameAsync(AirportInfoRequest request);
        Task<AirportDistanceViewModel> GetAirportsDistance(AirportInfoRequest from, AirportInfoRequest to, DistanceUnitMeasuare distanceUnitMeasuare);
    }
}
