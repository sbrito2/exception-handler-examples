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
                    if (customizedException.internalErrorType == InternalErrorType.TIMEOUT) {
                       await HandleRequestTimeoutResultAsync(httpContext, customizedException);
                       return true;
                    }
                    
                    if (customizedException.internalErrorType == InternalErrorType.BAD_GATEWAY) {
                        await HandleBadGatewayResultAsync(httpContext, customizedException);
                        return true;
                    }
                    
                    if (customizedException.internalErrorType == InternalErrorType.SERVICE_UNAVAILABLE) {
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
            return WriteResponseAsync(context, HttpStatusCode.RequestTimeout, false.AsErrorResponse(ex.Message));
        }

        private Task HandleBadGatewayResultAsync(HttpContext context, CustomizedException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.BadGateway, false.AsErrorResponse(ex.Message));
        }

        private Task HandleServiceUnavailablenResultAsync(HttpContext context, CustomizedException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.ServiceUnavailable, false.AsErrorResponse(ex.Message));
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            return WriteResponseAsync(context, HttpStatusCode.InternalServerError, false.AsErrorResponse());
        }

        private Task WriteResponseAsync(HttpContext context, HttpStatusCode statusCode, object response)
        {
            string result;
            context.Response.StatusCode = (int) statusCode;
            result = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}