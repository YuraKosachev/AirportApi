using RestSharp;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using FlightInfo.Common.Exceptions;
using FlightInfo.Common.Models.Error.Cteleport;
using System.Linq;
using FlightInfo.Common.Extensions;

namespace FlightInfo.Common.Implementation
{
    public abstract class CteleportDataRestClient<TRequest, TResponse> : DataRestClient<TRequest, TResponse>
    {
        protected override void ExceptionHandling(RestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    var content = response?.Content.ReplaceChars(new [] { ("(", "["), (")", "]") });
                    var errors = JsonConvert.DeserializeObject<List<CteleportErrorModel>>(content);
                    throw new BadApiRequestException(errors.Select(err => new Models.Error.Error { Message = err.Message, Type = err.Type }).ToList());
                default:
                    break;

            }

        }
    }
}
