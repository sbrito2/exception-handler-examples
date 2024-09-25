package com.example.models.response;

import com.example.infrastructure.notifications.NotificationContext;

public class ApiReturnBuilder {

    public static <T> ApiReturnGenericResponse<T> buildResponse() {
        return new ApiReturnGenericResponse<T>(null).Success(null);
    }

    public static <T> ApiReturnGenericResponse<T> buildResponse(T data) {
        if (data instanceof NotificationContext notifictionContext && notifictionContext.HasNotifications()) {
            return new ApiReturnGenericResponse<T>(data).WithNotifications(data);
        }
        return new ApiReturnGenericResponse<T>(data).Success(data);
    }

    public static <T> ApiReturnGenericResponse<T> buildErrorResponse(String message) {
        return new ApiReturnGenericResponse<T>(null).Error(message);
    }
}

