using Infra.CrossCutting.Exceptions;

namespace Models.Response.Messages
{
    public static class ResponseMessages
    {
        public static IDictionary<ExeptionType, string> Messages = new Dictionary<ExeptionType, string>()
        {
            { ExeptionType.TIMEOUT, "Timeout, please try again later." },
            { ExeptionType.BAD_GATEWAY, "Bad Gateway, please try again later." },
            { ExeptionType.SERVICE_UNAVAILABLE, "Service Unavailable, please try again later." },
            { ExeptionType.INFRASTRUCTURE, "Infra Internal Server Error." },
            { ExeptionType.EXCEPTION, "General Internal Server Error." }
        };
    }

}