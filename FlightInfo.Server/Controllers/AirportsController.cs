using FlightInfo.Common.Enums;
using FlightInfo.Common.Interfaces.Services;
using FlightInfo.Common.Models.Error;
using FlightInfo.Common.Models.Request;
using FlightInfo.Common.Models.Response;
using FlightInfo.Common.Models.View;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace FlightInfo.Server.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class AirportsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public AirportsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        /// <summary>
        /// Get airport info by iata code
        /// </summary>
        /// <param name="iata">airport iata code</param>
        /// <response code="200">Get airport info</response>
        /// <response code="400">Wrong parameter</response>
        /// <response code="500">Oops! something went wrong</response>
        [HttpGet]
        [ProducesResponseType(typeof(AirportInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorList), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(500)]
        [Route("airport/{iata}")]
        public async Task<IActionResult> GetAirportInfo(string iata)
        {
            var request = new AirportInfoRequest { Name = iata };
            var info = await _flightService.GetAirportInfoByNameAsync(request);
            return Ok(info);
        }

        /// <summary>
        /// Get distance between airports
        /// </summary>
        /// <param name="iataFrom">airport from iata code</param>
        /// <param name="iataTo">airport to iata code</param>
        /// <param name="unitMeasuare">distance unit of measuare </param>
        /// <response code="200">Get distance between airpots</response>
        /// <response code="400">Wrong parameters</response>
        /// <response code="500">Oops! something went wrong</response>
        [HttpGet]
        [ProducesResponseType(typeof(AirportDistanceViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorList), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(500)]
        [Route("airport/distance/{iataFrom}/{iataTo}/{unitMeasuare}")]
        public async Task<IActionResult> GetDistanceInfo(string iataFrom, string iataTo, DistanceUnitMeasuare unitMeasuare)
        {
            var from = new AirportInfoRequest { Name = iataFrom };
            var to = new AirportInfoRequest { Name = iataTo };
            var distanceInfo = await _flightService.GetAirportsDistance(from, to, unitMeasuare);
            return Ok(distanceInfo);
        }
    }
}