using Newtonsoft.Json;

namespace FlightInfo.Common.Models.Response
{
    public class Location
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}
