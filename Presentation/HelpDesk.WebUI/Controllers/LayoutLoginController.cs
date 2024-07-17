using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class LayoutLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
