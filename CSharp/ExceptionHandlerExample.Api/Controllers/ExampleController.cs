using Aplication.IServices;
using Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Response;

namespace BusinessRegister.Presentation.Controllers
{
    [ApiController]
    [Route("examples")]
    public class ExampleController : BaseController
    {
        readonly IExampleService exampleService;

        public ExampleController(IExampleService exampleService)
        {
            this.exampleService = exampleService;
        }

        [HttpGet, Route("timeout")]
        public async Task<IActionResult> SimulateTimeoutExeption()
        {
            var response = await exampleService.SimulateTimeoutExeption();

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet, Route("badgateway")]
        public async Task<IActionResult> SimulateBadGatewayExeption()
        {
            var response = await exampleService.SimulateBadGatewayExeption();

            return Ok(response.AsSuccessResponse());
        }

        [HttpGet, Route("success")]
        public async Task<IActionResult> SimulateSuccessResponse()
        {
            return Ok(true.AsSuccessResponse());
        }

        [HttpGet, Route("businesserror")]
        public IActionResult SimulateBusinessErrorWithNotification()
        {
            var response = exampleService.SimulateBusinessErrorWithNotification();

            return Ok(response.AsSuccessResponse());
        }
    }
}