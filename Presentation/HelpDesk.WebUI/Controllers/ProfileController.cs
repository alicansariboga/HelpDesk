using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
