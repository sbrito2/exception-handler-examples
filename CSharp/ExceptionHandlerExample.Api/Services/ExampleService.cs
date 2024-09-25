using Aplication.IServices;
using Exceptions.Base;
using Infra.CrossCutting.Notifications;
using Services.Base;

namespace Application.Services
{
    public class ExampleService : Service, IExampleService
    {
        public ExampleService(NotificationContext notificationContext) : base(notificationContext)
        {
        }

        public Task<bool> SimulateTimeoutExeption()
        {
            throw new TimeoutException();
        }

        public Task<bool> SimulateBadGatewayExeption()
        {
            throw CustomizedException.ofBadGateway("Partner integration failed here!");
        }

        public bool SimulateBusinessErrorWithNotification()
        {
            this.notificationContext.AddValidationErrorNotification("BUSINESS ERROR HERE: validation error.");
            return false; 
        }
    }
}
