using Models.Response.Messages;

namespace Infra.CrossCutting.Exceptions
{
    public class CustomizedException : Exception
    {
        public ExceptionType ExceptionType {  get; }
        protected string tracking {  get; }

        protected CustomizedException(ExceptionType ExceptionType, string message) : base(message)
        {
           this.ExceptionType = ExceptionType;
           this.tracking = Guid.NewGuid().ToString("N");
        }

        protected CustomizedException(ExceptionType ExceptionType) : base()
        {
           this.ExceptionType = ExceptionType;
           this.tracking = Guid.NewGuid().ToString("N");
        }

        public static CustomizedException ofTimeOut(string message = null) {
            return of(ExceptionType.TIMEOUT, message);
        }

        public static CustomizedException ofBadGateway(string message = null) {
            return of(ExceptionType.BAD_GATEWAY, message);
        }

        public static CustomizedException ofServiceUnavailable(string message = null) {
            return of(ExceptionType.SERVICE_UNAVAILABLE, message);
        }

        public static CustomizedException ofInfraestructure(string message = null) {
            return of(ExceptionType.INFRASTRUCTURE, message);
        }

        public static CustomizedException of(string message = null) {
            return of(ExceptionType.EXCEPTION, message);
        }

        private static CustomizedException of(ExceptionType errorType, string message = null) {
            var errorDetails = message ?? ResponseMessages.Messages[errorType];
            return new CustomizedException(errorType, errorDetails);
        }
    }
}
