using Models.Response.Messages;

namespace Infra.CrossCutting.Exceptions
{
    public class CustomizedException : Exception
    {
        public ExeptionType ExeptionType {  get; }
        protected string tracking {  get; }

        protected CustomizedException(ExeptionType ExeptionType, string message) : base(message)
        {
           this.ExeptionType = ExeptionType;
           this.tracking = Guid.NewGuid().ToString("N");
        }

        protected CustomizedException(ExeptionType ExeptionType) : base()
        {
           this.ExeptionType = ExeptionType;
           this.tracking = Guid.NewGuid().ToString("N");
        }

        public static CustomizedException ofTimeOut(string message = null) {
            return of(ExeptionType.TIMEOUT, message);
        }

        public static CustomizedException ofBadGateway(string message = null) {
            return of(ExeptionType.BAD_GATEWAY, message);
        }

        public static CustomizedException ofServiceUnavailable(string message = null) {
            return of(ExeptionType.SERVICE_UNAVAILABLE, message);
        }

        public static CustomizedException ofInfraestructure(string message = null) {
            return of(ExeptionType.INFRASTRUCTURE, message);
        }

        public static CustomizedException of(string message = null) {
            return of(ExeptionType.EXCEPTION, message);
        }

        private static CustomizedException of(ExeptionType errorType, string message = null) {
            var errorDetails = message ?? ResponseMessages.Messages[errorType];
            return new CustomizedException(errorType, errorDetails);
        }
    }
}
