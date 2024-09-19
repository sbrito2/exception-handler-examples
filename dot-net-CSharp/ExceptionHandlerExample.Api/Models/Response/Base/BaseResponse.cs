
using Models.Response.Messages;

namespace Response.Base
{
    public class BaseResponse
    {
        public string Message { get; set; }

        public bool ErrorOccurred { get; set; }
        public BaseResponse()
        {
        }

        public T Success<T>(string message = null) where T : BaseResponse
        {
            this.Message = message;
            return (T)this;
        }

        public T Error<T>(string message = null) where T : BaseResponse
        {
            this.Message = message;
            this.ErrorOccurred = true;
            return (T)this;
        }
    }
}
