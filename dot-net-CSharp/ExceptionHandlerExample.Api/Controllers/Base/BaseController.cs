using Microsoft.AspNetCore.Mvc;
using Response;
using Response.Base;
namespace Controllers.Base
{
    [ApiController]
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public override OkObjectResult Ok(object result)
        {
            if (result is FileResponse)
            {
                FileResponse value = (FileResponse)result;
                return base.Ok(value.File);
            }

            if (!(result is BaseResponse))
            {
                return base.Ok(result.AsSuccessResponse());
            }

            return base.Ok(result);
        }
    }
}