using FlightInfo.Common.Interfaces.Configurations;
using RestSharp;

namespace FlightInfo.Common.Models.Configurations
{
    public abstract class ConfigurationBase : IConfigurationApiService
    {
        public string Resource { get; set ; }
        public Method Method { get; set; }
    }
}
