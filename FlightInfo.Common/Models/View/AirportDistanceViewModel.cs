using FlightInfo.Common.Enums;
using FlightInfo.Common.Models.Response;
using Newtonsoft.Json;

namespace FlightInfo.Common.Models.View
{
    public class AirportDistanceViewModel
    {
        [JsonProperty("iata_from")]
        public string IataFrom { get; set; }

        [JsonProperty("iata_to")]
        public string IataTo { get; set; }

        [JsonProperty("location_from")]
        public Location LocationFrom { get; set; }

        [JsonProperty("location_to")]
        public Location LocationTo { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("distance_unit_measuare")]
        public DistanceUnitMeasuare DistanceUnitMeasuare { get; set; }
    }
}
