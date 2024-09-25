package com.example.models.response;

public class ApiReturnGenericResponse<T> extends ApiReturn {

    private T Data;

    public T getData() {
        return Data;
    }

    protected ApiReturnGenericResponse(T data) {
        super(null, false);
        this.Data = data;
    }

    protected ApiReturnGenericResponse(String message, boolean errorOccurred, T data) {
        super(message, errorOccurred);
        this.Data = data;
    }

    protected ApiReturnGenericResponse(String message, boolean errorOccurred, boolean hasNotification, T data) {
        super(message, errorOccurred, hasNotification);
        this.Data = data;
    }

    protected ApiReturnGenericResponse<T> Success(T data)
    {
        return new ApiReturnGenericResponse<T>(null, false, data);
    }

    protected ApiReturnGenericResponse<T> Error(String message)
    {
        return new ApiReturnGenericResponse<T>(message, true, null);
    }

    protected ApiReturnGenericResponse<T> WithNotifications(T data)
    {
        return new ApiReturnGenericResponse<T>(null, true, true, data);
    }
}