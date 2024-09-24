package com.example.models.response;

public class ApiReturnGenericResponse<T> extends ApiReturn {

    private T Data;

    protected ApiReturnGenericResponse(T data) {
        super(null, false);
        this.Data = data;
    }

    protected ApiReturnGenericResponse(String message, boolean errorOccurred, T data) {
        super(message, errorOccurred);
        this.Data = data;
    }

    protected ApiReturnGenericResponse<T> Success(T data)
    {
        return new ApiReturnGenericResponse(null, false, data);
    }

    protected ApiReturnGenericResponse<T> Error(T data)
    {
        return new ApiReturnGenericResponse(null, true, data);
    }
}