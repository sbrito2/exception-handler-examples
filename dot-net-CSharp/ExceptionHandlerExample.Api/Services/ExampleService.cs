using BusinessRegister.Aplication.IServices;

namespace BusinessRegister.Application.Services
{
    public class ExampleService : IExampleService
    {
        public Task<bool> SimulateExample()
        {
            throw new TimeoutException();
        }
    }
}
