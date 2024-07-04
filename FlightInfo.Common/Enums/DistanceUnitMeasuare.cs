using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace FlightInfo.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DistanceUnitMeasuare
    {
        [Description("Kilometers")]
        KM = 0,
        [Description("Miles")]
        ML,
        [Description("NauticalMiles")]
        NML
    }
}
