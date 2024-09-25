namespace Response
{
    public static class GenericResponseExtensions
    {
        public static GenericResponse<object> AsSuccessGenericResponse(this object data)
        {
            return new GenericResponse<object>(data);
        }

        public static GenericResponse<object> AsSuccessResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).Success(message);
        }

        public static GenericResponse<object> AsErrorResponse(this object data, string message = null)
        {
            return new GenericResponse<object>(data).Error(message);
        }
    }
}
