using Models.Response.Messages;

namespace Infra.CrossCutting.Exceptions
{
    public class CustomizedException : Exception
    {
        public InternalErrorType internalErrorType {  get; }
        protected string tracking {  get; }

        protected CustomizedException(InternalErrorType internalErrorType, string message) : base(message)
        {
           this.internalErrorType = internalErrorType;
           this.tracking = Guid.NewGuid().ToString("N");
        }

        protected CustomizedException(InternalErrorType internalErrorType) : base()
        {
           this.internalErrorType = internalErrorType;
           this.tracking = Guid.NewGuid().ToString("N");
        }

        public static CustomizedException ofTimeOut(string message = null) {
            return of(InternalErrorType.TIMEOUT, message);
        }

        public static CustomizedException ofBadGateway(string message = null) {
            return of(InternalErrorType.BAD_GATEWAY, message);
        }

        public static CustomizedException ofServiceUnavailable(string message = null) {
            return of(InternalErrorType.SERVICE_UNAVAILABLE, message);
        }

        public static CustomizedException ofInfraestructure(string message = null) {
            return of(InternalErrorType.INFRASTRUCTURE, message);
        }

        public static CustomizedException of(string message = null) {
            return of(InternalErrorType.EXCEPTION, message);
        }

        private static CustomizedException of(InternalErrorType errorType, string message = null) {
            var errorDetails = message ?? ResponseMessages.Messages[errorType];
            return new CustomizedException(errorType, errorDetails);
        }
    }
}
