using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HelpDesk.WebUI.Controllers
{
    [Authorize(Roles = "Member")]
    [Route("Dashboard")]
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
            var token = User.Claims.FirstOrDefault(x => x.Type == "helpDeskToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                return View();
            }
            return RedirectToAction("SignIn", "Login");
        }
    }
}
