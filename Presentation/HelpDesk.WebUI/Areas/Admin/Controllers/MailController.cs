using HelpDesk.DTO.AppUserDtos;
using HelpDesk.DTO.MailDtos;
using HelpDesk.DTO.TicketDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace HelpDesk.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Mail")]
    public class MailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Inbox")]
        public async Task<IActionResult> Inbox()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7099/api/Mails/MailListByUserId?id=" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResulltMailDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("Outbox")]
        public async Task<IActionResult> Outbox()
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
        [HttpGet]
        [Route("Admin/Mail/Inbox/Detail/{id}")]
        public async Task<IActionResult> InboxDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7099/api/Mails/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResulltMailDto>(jsonData);
                return View(value);
            }
            return View("Error");
        }
        [HttpGet]
        [Route("Admin/Mail/Outbox/Detail/{id}")]
        public async Task<IActionResult> OutboxDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7099/api/Tickets/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultTicketDto>(jsonData);
                return View(value);
            }
            return View("Error");
        }
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
			var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7099/api/AppUsers/" + userId);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<ResultAppUserDto>(jsonData);
                ViewBag.email = value.Email;
				return View();
			}
			return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateMailDto createMailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7099/api/Mails", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Outbox", "Mail");
            }
            return View();
        }
    }
}
