using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    [Authorize(Roles = "Member")]
    [Route("Profile")]
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(IHttpClientFactory httpClientFactory)
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
