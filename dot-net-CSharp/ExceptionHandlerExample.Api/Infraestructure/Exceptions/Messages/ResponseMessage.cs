
using Exceptions.Enums;

namespace Models.Response.Messages
{
    public static class ResponseMessages
    {
        public static IDictionary<ExceptionType, string> Messages = new Dictionary<ExceptionType, string>()
        {
            { ExceptionType.TIMEOUT, "Timeout, please try again later." },
            { ExceptionType.BAD_GATEWAY, "Bad Gateway, please try again later." },
            { ExceptionType.SERVICE_UNAVAILABLE, "Service Unavailable, please try again later." },
            { ExceptionType.INFRASTRUCTURE, "Infra Internal Server Error." },
            { ExceptionType.EXCEPTION, "General Internal Server Error." }
        };
    }
}