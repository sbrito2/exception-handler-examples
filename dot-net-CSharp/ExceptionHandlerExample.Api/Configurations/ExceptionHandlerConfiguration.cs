using Microsoft.AspNetCore.Diagnostics;
using Infra.CrossCutting.Exceptions;
using System.Net;
using Response;
using Newtonsoft.Json;

namespace API.Configurations
{
    public class ExceptionHandlerConfiguration : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandlerConfiguration> logger;

        public ExceptionHandlerConfiguration(ILogger<ExceptionHandlerConfiguration> logger)
        {
            this.logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An unhandled exception has occurred.");

            switch (exception)
            {
                case CustomizedException customizedException:
                    if (customizedException.ExeptionType == ExeptionType.TIMEOUT) {
                       await HandleRequestTimeoutResultAsync(httpContext, customizedException);
                       return true;
                    }
                    
                    if (customizedException.ExeptionType == ExeptionType.BAD_GATEWAY) {
                        await HandleBadGatewayResultAsync(httpContext, customizedException);
                        return true;
                    }
                    
                    if (customizedException.ExeptionType == ExeptionType.SERVICE_UNAVAILABLE) {
                        await HandleServiceUnavailablenResultAsync(httpContext, customizedException);
                        return true;
                    }
                    break;
                case TimeoutException:
                    var timeoutException = CustomizedException.ofTimeOut();
                    await HandleRequestTimeoutResultAsync(httpContext, timeoutException);
                    return true;
                default:
                    break;
            }

            await HandleExceptionAsync(httpContext);
            return true;
        }

        private Task HandleRequestTimeoutResultAsync(HttpContext context, CustomizedException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.RequestTimeout, ex.Message);
        }

        private Task HandleBadGatewayResultAsync(HttpContext context, CustomizedException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.BadGateway, ex.Message);
        }

        private Task HandleServiceUnavailablenResultAsync(HttpContext context, CustomizedException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.ServiceUnavailable, ex.Message);
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            return WriteResponseAsync(context, HttpStatusCode.InternalServerError);
        }

        private Task WriteResponseAsync(HttpContext context, HttpStatusCode statusCode, string message = null)
        {
            string result;
            context.Response.StatusCode = (int) statusCode;
            result = JsonConvert.SerializeObject(false.AsErrorResponse(message));
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}