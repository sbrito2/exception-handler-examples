using Infra.CrossCutting.Notifications;

namespace Services.Base
{
    public class Service
    {
        protected readonly NotificationContext notificationContext;
       
        public Service(NotificationContext notificationContext)
        {
            this.notificationContext = notificationContext;
        }
    }
}