using BusinessRegister.Aplication.IServices;
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

        [HttpGet, Route("simulations")]
        public async Task<IActionResult> GetCompanyAsync()
        {
            var response = await exampleService.SimulateExample();

            return Ok(response.AsSuccessResponse());
        }
    }
}