package com.example.models.response;

public class ApiReturn {
    private String message;
    private boolean errorOccurred;

    public String getMessage() {
        return message;
    }

    public boolean isErrorOccurred() {
        return errorOccurred;
    }

    protected ApiReturn (String message, boolean errorOccurred) {
        this.message = message;
        this.errorOccurred = errorOccurred;
    }
}