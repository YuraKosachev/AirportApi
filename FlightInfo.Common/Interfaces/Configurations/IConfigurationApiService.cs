using RestSharp;

namespace FlightInfo.Common.Interfaces.Configurations
{
    public interface IConfigurationApiService
    {
        string Resource { get; set; }
        Method Method { get; set; }
    }
}
