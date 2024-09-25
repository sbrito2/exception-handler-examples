package com.example.infrastructure.notifications;

import com.example.infrastructure.notifications.Enums.NotificationType;

public class Notification {

    private NotificationType type;
    private String message;

    public Notification(NotificationType type, String message) {
        this.type = type;
        this.message = message;
    }

    public Notification(String message) {
        this.type = NotificationType.VALIDATION_ERROR;
        this.message = message;
    }

    public NotificationType getType() {
        return type;
    }

    public String getMessage() {
        return message;
    }

    public static Notification InexistentId(String message) {
        return new Notification(NotificationType.BUSINESS_ERROR, message);
    }

    public static Notification ValidationError(String message) {
        return new Notification(NotificationType.VALIDATION_ERROR, message);
    }
}
