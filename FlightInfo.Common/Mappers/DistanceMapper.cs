using FlightInfo.Common.Enums;
using FlightInfo.Common.Extensions;
using FlightInfo.Common.Models.Response;
using FlightInfo.Common.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Common.Mappers
{
    public static class DistanceMapper
    {
        public static AirportDistanceViewModel MapToDistance(this AirportInfo from, AirportInfo to, DistanceUnitMeasuare distanceUnitMeasuare)
        {
            if (from == null || to == null)
                return null;

            var result = new AirportDistanceViewModel
            {
                LocationFrom = from.Location,
                LocationTo = to.Location,
                IataFrom = from.Iata,
                IataTo = to.Iata,
                Distance = from.Location.DistanceTo(to.Location, distanceUnitMeasuare),
                DistanceUnitMeasuare = distanceUnitMeasuare
            };

            return result;
        }
    }
}
