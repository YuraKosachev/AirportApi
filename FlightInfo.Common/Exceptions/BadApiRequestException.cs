using FlightInfo.Common.Models.Error;
using System;
using System.Collections.Generic;

namespace FlightInfo.Common.Exceptions
{
    public class BadApiRequestException : Exception
    {
        public List<Error> Errors { get; }
        public BadApiRequestException(List<Error> errors) 
        {
           Errors = errors;
        }

    }
}
