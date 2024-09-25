

using Response.Base;

namespace Response
{
    public class GenericResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public GenericResponse() { }

        public GenericResponse(T data)
        {
            this.Data = data;
        }

        public virtual GenericResponse<T> Success(string message = null)
        {
            return base.Success<GenericResponse<T>>(message);
        }

        public virtual GenericResponse<T> Error(string message = null)
        {
            return base.Error<GenericResponse<T>>(message);
        }
    }
}
