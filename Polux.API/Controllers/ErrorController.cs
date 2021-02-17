using Microsoft.AspNetCore.Mvc;
using Polux.API.Errors;

namespace Polux.API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
