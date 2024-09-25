using Infra.CrossCutting.Notifications.Enums;

namespace Infra.CrossCutting.Notifications
{
    public class NotificationContext 
    {
        public IList<Notification> notifications { get; set; }
        public bool HasNotifications => notifications.Any();

        public NotificationContext()
        {
            this.notifications = new List<Notification>();
        }

        public void Add(NotificationType type, string message)
        {
            this.notifications.Add(new Notification(type, message));
        }

        public void Add(Notification notification)
        {
            this.notifications.Add(notification);
        }

        public void Add(IList<Notification> notifications)
        {
            this.notifications.Concat(notifications);
        }

        public void AddNotFoundNotification(string message)
        {
            this.notifications.Add(new Notification().InexistentId<Notification>(message));
        }

        public void AddValidationErrorNotification(string message)
        {
            this.notifications.Add(new Notification().ValidationError<Notification>(message));
        }
    }
}