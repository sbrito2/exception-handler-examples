package com.example.infrastructure.exception.enums;

public enum ExceptionType {
    TIMEOUT("Timeout, please try again later."),
    BAD_GATEWAY("Timeout, please try again later."),
    SERVICE_UNAVAILABLE("Timeout, please try again later."),
    INFRASTRUCTURE("Timeout, please try again later."),
    EXCEPTION("Timeout, please try again later.");

    private final String message;

    private ExceptionType(final String message) {
        this.message = message;
    }

    @Override
    public String toString() {
        return message;
    }
}
