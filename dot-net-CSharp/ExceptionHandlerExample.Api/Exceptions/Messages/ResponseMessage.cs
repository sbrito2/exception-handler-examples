using Infra.CrossCutting.Exceptions;

namespace Models.Response.Messages
{
    public static class ResponseMessages
    {
        public static IDictionary<InternalErrorType, string> Messages = new Dictionary<InternalErrorType, string>()
        {
            { InternalErrorType.TIMEOUT, "Timeout, please try again later." },
            { InternalErrorType.BAD_GATEWAY, "Bad Gateway, please try again later." },
            { InternalErrorType.SERVICE_UNAVAILABLE, "Service Unavailable, please try again later." },
            { InternalErrorType.INFRASTRUCTURE, "Infra Internal Server Error." },
            { InternalErrorType.EXCEPTION, "General Internal Server Error." }
        };
    }

}