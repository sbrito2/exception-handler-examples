
using Aplication.IServices;
using Application.Services;
using Infra.CrossCutting.Notifications;

namespace API.Configurations
{
    public class DependencyContainerConfiguration
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<NotificationContext>();
            serviceCollection.AddTransient<IExampleService, ExampleService>();
            
        }
    }
}