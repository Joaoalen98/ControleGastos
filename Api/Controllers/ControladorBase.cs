using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ControladorBase : ControllerBase
    {
        protected IActionResult EnviarErro(int statusCode, string msg, object? data = null)
        {
            return StatusCode(statusCode, new
            {
                msg,
                data
            });
        }
    }
}