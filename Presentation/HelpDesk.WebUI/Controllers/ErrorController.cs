using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    [AllowAnonymous]
    [Route("Error")]
    public class ErrorController : Controller
    {
        [Route("Err404")]
        public IActionResult Err404() // Page Not Found
        {
            return View();
        }
        [Route("Err403")]
        public IActionResult Err403() // Forbidden
        {
            return View();
        }
        [Route("Err401")]
        public IActionResult Err401() // Unauthorized // Access Denied
        {
            return View();
        }
        [Route("Err500")]
        public IActionResult Err500() // Internal Server Error
        {
            return View();
        }
    }
}
