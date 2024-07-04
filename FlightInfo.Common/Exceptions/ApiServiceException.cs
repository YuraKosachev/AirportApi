using System;

namespace FlightInfo.Common.Exceptions
{
    public class ApiServiceException : Exception
    {
        public ApiServiceException(string message) : base(message) { }
    }
}
