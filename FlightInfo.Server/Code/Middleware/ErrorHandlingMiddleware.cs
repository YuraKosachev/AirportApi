using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System;
using FlightInfo.Common.Exceptions;
using FlightInfo.Common.Models.Error;
using System.Collections.Generic;
using FlightInfo.Common.Constants;


namespace FlightInfo.Server.Code.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var errorList = new ErrorList();

            if (exception is BadApiRequestException)
            {
                statusCode = HttpStatusCode.BadRequest;
                var badRequestEx = exception as BadApiRequestException;
                errorList.Errors = badRequestEx.Errors;
            }
            else if (exception is ApiServiceException || exception is Exception)
            {
                errorList.Errors = new List<Error> { new Error { Message = exception.Message } };
            }

            var result = JsonConvert.SerializeObject(errorList);
            context.Response.ContentType = ContentType.ApplicationJson;
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}