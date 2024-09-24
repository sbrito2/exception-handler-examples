package com.example.infrastructure.Exceptions.base;

import java.util.Objects;

import com.example.infrastructure.Exceptions.enums.ExceptionType;

public class CustomizedException extends RuntimeException implements Trackable {

    protected ExceptionType exceptionType;
    protected String tracking;

    protected CustomizedException(ExceptionType exceptionType, String message) {
        super(message);
        this.tracking = java.util.UUID.randomUUID().toString();
    }

    public static CustomizedException ofTimeOut() {
        return CustomizedException.of(ExceptionType.TIMEOUT);
    }

    public static CustomizedException ofTimeOut(String message) {
        return CustomizedException.of(ExceptionType.TIMEOUT, message);
    }

    public static CustomizedException ofBadGateway() {
        return of(ExceptionType.BAD_GATEWAY);
    }

    public static CustomizedException ofBadGateway(String message) {
        return of(ExceptionType.BAD_GATEWAY, message);
    }

    public static CustomizedException ofServiceUnavailable() {
        return of(ExceptionType.SERVICE_UNAVAILABLE);
    }

    public static CustomizedException ofServiceUnavailable(String message) {
        return of(ExceptionType.SERVICE_UNAVAILABLE, message);
    }

    public static CustomizedException ofInfraestructure() {
        return of(ExceptionType.INFRASTRUCTURE);
    }

    public static CustomizedException ofInfraestructure(String message) {
        return of(ExceptionType.INFRASTRUCTURE, message);
    }

    public static CustomizedException of(String message) {
        return of(ExceptionType.EXCEPTION, message);
    }

    private static CustomizedException of(ExceptionType errorType) {
        return new CustomizedException(errorType, errorType.getMessage());
    }

    private static CustomizedException of(ExceptionType errorType, String message) {
        var errorDetails = !Objects.isNull(message) ? message : errorType.getMessage();
        return new CustomizedException(errorType, errorDetails);
    }

    @Override
    public String getTracking() {
        return tracking;
    }

    public ExceptionType getExceptionType() {
        return exceptionType;
    }
}
