using Newtonsoft.Json;

namespace FlightInfo.Common.Models.Error
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
