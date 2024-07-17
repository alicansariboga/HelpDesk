using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
