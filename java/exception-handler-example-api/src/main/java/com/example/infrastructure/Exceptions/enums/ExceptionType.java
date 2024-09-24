package com.example.infrastructure.Exceptions.enums;

public enum ExceptionType {
    TIMEOUT("Timeout, please try again later."),
    BAD_GATEWAY("Timeout, please try again later."),
    SERVICE_UNAVAILABLE("Timeout, please try again later."),
    INFRASTRUCTURE("Timeout, please try again later."),
    EXCEPTION("Timeout, please try again later.");

    private String message;

    private ExceptionType(String message) {
        this.message = message;
    }

    public String getMessage() {
        return message;
    }
}
