using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Dashboard")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
