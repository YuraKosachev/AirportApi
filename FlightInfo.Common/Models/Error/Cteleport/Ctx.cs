using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightInfo.Common.Models.Error.Cteleport
{

    public class Ctx
    {
        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }

}
