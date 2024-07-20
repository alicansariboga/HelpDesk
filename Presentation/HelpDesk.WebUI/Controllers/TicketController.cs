using HelpDesk.DTO.TicketDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace HelpDesk.WebUI.Controllers
{
    public class TicketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TicketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7099/api/Tickets/TicketListByUserId?id=" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTicketDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketDto createTicketDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTicketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7099/api/Tickets/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Ticket");
            }
            return View();
        }
    }
}
