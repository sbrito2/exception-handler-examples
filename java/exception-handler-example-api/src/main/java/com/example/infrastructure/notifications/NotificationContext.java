package com.example.infrastructure.notifications;

import java.util.Objects;

import com.example.infrastructure.notifications.Enums.NotificationType;

import java.util.ArrayList;

public class NotificationContext {

    public ArrayList<Notification> notifications;

    public NotificationContext() {
        this.notifications = new ArrayList<Notification>();
    }

    public ArrayList<Notification> getNotifications() {
        return notifications;
    }

    public boolean HasNotifications() {
        return Objects.nonNull(this.notifications) && this.notifications.size() > 0;
    }

    public void Add(NotificationType type, String message) {
        this.notifications.add(new Notification(type, message));
    }

    public void Add(Notification notification) {
        this.notifications.add(notification);
    }

    public void Add(ArrayList<Notification> notifications) {
        this.notifications.addAll(notifications);
    }

    public void AddNotFoundNotification(String message) {
        this.notifications.add(Notification.InexistentId(message));
    }

    public void AddValidationErrorNotification(String message) {
        this.notifications.add(Notification.ValidationError(message));
    }
}
