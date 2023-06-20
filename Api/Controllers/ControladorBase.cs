using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ControladorBase : ControllerBase
    {
        protected IActionResult EnviarErro(int statusCode, string msg, object? data)
        {
            return StatusCode(statusCode, new
            {
                msg,
                data
            });
        }
    }
}