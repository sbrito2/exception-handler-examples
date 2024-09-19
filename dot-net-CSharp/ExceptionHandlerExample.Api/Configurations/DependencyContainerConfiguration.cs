
using BusinessRegister.Aplication.IServices;
using BusinessRegister.Application.Services;

namespace API.Configurations
{
    public class DependencyContainerConfiguration
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IExampleService, ExampleService>();
        }
    }
}