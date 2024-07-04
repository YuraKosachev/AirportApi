using FlightInfo.Common.Constants;
using FlightInfo.Common.Enums;
using FlightInfo.Common.Models.Response;
using System;

namespace FlightInfo.Common.Extensions
{
    public static class GeoLocatorExtension
    {
        public static double DistanceTo(this Location from, Location to, DistanceUnitMeasuare distanceUnitMeasuare) 
        {
            var baseRad = Math.PI * from.Lat / 180;
            var targetRad = Math.PI * to.Lat / 180;
            var theta = from.Lon - to.Lon;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (distanceUnitMeasuare)
            {
                case DistanceUnitMeasuare.KM: //Kilometers
                    return dist * CoeffConstants.KMCoeff;
                case DistanceUnitMeasuare.NML: //Nautical Miles 
                    return dist * CoeffConstants.NMLCoeff;
            }

            return dist;
        }
    }
}
