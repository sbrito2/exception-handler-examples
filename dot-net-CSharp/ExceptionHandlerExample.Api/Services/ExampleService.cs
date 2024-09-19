using BusinessRegister.Aplication.IServices;
using Infra.CrossCutting.Exceptions;

namespace BusinessRegister.Application.Services
{
    public class ExampleService : IExampleService
    {
        public Task<bool> SimulateTimeoutExeption()
        {
            throw new TimeoutException();
        }

        public Task<bool> SimulateBadGatewayExeption()
        {
            throw CustomizedException.ofBadGateway("Partner integration failed here!");
        }
    }
}
