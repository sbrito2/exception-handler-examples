namespace BusinessRegister.Aplication.IServices
{
    public interface IExampleService
    {
        Task<bool> SimulateTimeoutExeption();

        Task<bool> SimulateBadGatewayExeption();        
    }
}