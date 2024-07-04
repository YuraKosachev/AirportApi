using Newtonsoft.Json;
using System.Collections.Generic;


namespace FlightInfo.Common.Models.Error
{
    public class ErrorList
    {
        [JsonProperty("errors")]
        public IList<Error> Errors { get; set; }
    }
}
