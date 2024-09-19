using Infra.CrossCutting.Exceptions;

namespace Models.Response.Messages
{
    public static class ResponseMessages
    {
        public static IDictionary<InternalErrorType, string> Messages = new Dictionary<InternalErrorType, string>()
        {
            { InternalErrorType.TIMEOUT, "Por favor tente novamente mais tarde" },
            { InternalErrorType.BAD_GATEWAY, "Por favor, tente novamente mais tarde" },
            { InternalErrorType.SERVICE_UNAVAILABLE, "Por favor, tente novamente mais tarde" },
            { InternalErrorType.INFRASTRUCTURE, "Erro interno de servidor" },
            { InternalErrorType.EXCEPTION, "Erro interno de servidor" }
        };
    }

}