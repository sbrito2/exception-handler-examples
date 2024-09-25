package com.example.models.response;

public class ApiReturnBuilder {

    public static <T> ApiReturnGenericResponse<T> buildSuccessResponse() {
        return new ApiReturnGenericResponse<T>(null).Success(null);
    }

    public static <T> ApiReturnGenericResponse<T> buildSuccessResponse(T data) {
        return new ApiReturnGenericResponse<T>(data).Success(data);
    }

    public static <T> ApiReturnGenericResponse<T> buildErrorResponse(String message) {
        return new ApiReturnGenericResponse<T>(null).Error(message);
    }
}

