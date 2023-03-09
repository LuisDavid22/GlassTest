using Microsoft.AspNetCore.Mvc;

namespace GlassTest.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Index()
        {       
            return Problem();
        }
    }
}
