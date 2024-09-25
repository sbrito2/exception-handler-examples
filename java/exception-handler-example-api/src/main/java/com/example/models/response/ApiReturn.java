package com.example.models.response;

public class ApiReturn {
    private String message;
    private boolean errorOccurred;
    private boolean hasNotifications;

    public boolean isHasNotifications() {
        return hasNotifications;
    }

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

    protected ApiReturn (String message, boolean errorOccurred, boolean hasNotifications) {
        this.message = message;
        this.errorOccurred = errorOccurred;
        this.hasNotifications = hasNotifications;
    }
}