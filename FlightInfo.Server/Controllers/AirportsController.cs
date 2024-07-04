using FlightInfo.Common.Enums;
using FlightInfo.Common.Interfaces.Services;
using FlightInfo.Common.Models.Error;
using FlightInfo.Common.Models.Request;
using FlightInfo.Common.Models.View;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FlightInfo.Server.Controllers
{
    [Route("api")]
    [ApiController]
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
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "OK", typeof(AirportDistanceViewModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid or missing parameter(s)!", typeof(ErrorList))]
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
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "OK", typeof(AirportDistanceViewModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid or missing parameter(s)!", typeof(ErrorList))]
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