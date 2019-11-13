using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SF.Services.Interfaces.CustomExceptions;
using System;

namespace SF.WebAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {

            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {

            _logger.LogError(context.Exception, "Exception filter intercepted an exception");
            context.ExceptionHandled = true;

            string json;
            if (context.Exception.GetType().IsSerializable)
            {
                json = JsonConvert.SerializeObject(new
                {
                    errorMessage = context.Exception.Message,
                    exception = context.Exception
                }, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    errorMessage = context.Exception.Message,
                    exception = new
                    {
                        ClassName = context.Exception.GetType().FullName,
                        context.Exception.Source,
                        context.Exception.StackTrace
                    }
                }, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }

            var result = new ContentResult { Content = json, ContentType = "application/json" };


            if (context.Exception is ItemNotFoundException)
            {
                result.StatusCode = StatusCodes.Status404NotFound;
            }
            else if (context.Exception is BadArgumentException)
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                result.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (context.Exception is NotImplementedException)
            {
                result.StatusCode = StatusCodes.Status501NotImplemented;
            }
            else if (context.Exception is AccessForbiddenException)
            {
                result.StatusCode = StatusCodes.Status403Forbidden;
            }
            else
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
            }

            context.Result = result;
        }
    }
}
