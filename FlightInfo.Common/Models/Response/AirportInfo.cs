using Newtonsoft.Json;

namespace FlightInfo.Common.Models.Response
{
    public class AirportInfo
    {
        [JsonProperty("iata")]
        public string Iata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_iata")]
        public string CityIata { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_iata")]
        public string CountryIata { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("rating")]
        public int? Rating { get; set; }

        [JsonProperty("hubs")]
        public int? Hubs { get; set; }

        [JsonProperty("timezone_region_name")]
        public string TimezoneRegionName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
