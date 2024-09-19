namespace Infra.CrossCutting.Exceptions
{
    public enum InternalErrorType
    {
        TIMEOUT,
        /**
        * Erro de dominio retornado pela chamada de uma API externa
        */
        BAD_GATEWAY,
        /**
        * Erro de configuracao de ambiente do appsettings
        */
        SERVICE_UNAVAILABLE,
        /**
        * Erro de infraestrutura
        */
        INFRASTRUCTURE,
        /**
        * Exception inesperada
        */
        EXCEPTION
    }
}
