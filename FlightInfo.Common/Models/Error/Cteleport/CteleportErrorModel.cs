//using FlightInfo.Common.Handlers.Json;
using Newtonsoft.Json;

namespace FlightInfo.Common.Models.Error.Cteleport
{
    public class CteleportErrorModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("loc")]
        public string[] Loc { get; set; }

        [JsonProperty("ctx")]
        public Ctx Ctx { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
