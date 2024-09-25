using System.Net;
using Infra.CrossCutting.Notifications.Enums;

namespace Infra.CrossCutting.Notifications
{
    public class Notification
    {
        public NotificationType Type { get; private set; }
        public string Message { get; set; } 

        public Notification(NotificationType type, string message)
        {
            Type = type;
            Message = message;
        }

        public Notification(string message = null)
        {
            Type = NotificationType.VALIDATION_ERROR;
            Message = message;
        }

        public T InexistentId<T>(string message) where T : Notification
        {
            this.Type = NotificationType.BUSINESS_ERROR;
            this.Message = message;
            return (T)this;
        }

        public T ValidationError<T>(string message) where T : Notification
        {
            this.Type = NotificationType.VALIDATION_ERROR;
            this.Message = message;
            return (T)this;
        }
    }
}