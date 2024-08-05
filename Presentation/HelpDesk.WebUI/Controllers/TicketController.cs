using HelpDesk.DTO.AppUserDtos;
using HelpDesk.DTO.StaffDepartmentDtos;
using HelpDesk.DTO.TicketDtos;
using HelpDesk.DTO.TicketStatusDtos;
using HelpDesk.WebUI.Models;
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
        public async Task<IActionResult> Create()
        {
			var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
			var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7099/api/TicketStatuses/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTicketStatusDto>>(jsonData);
                var responseMessage2 = await client.GetAsync("https://localhost:7099/api/StaffDepartments/StaffDepartmentList/");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResultStaffDepartmentAllDto>>(jsonData2);
				var responseMessage3 = await client.GetAsync($"https://localhost:7099/api/AppUsers/{userId}");
				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				var values3 = JsonConvert.DeserializeObject<ResultAppUserDto>(jsonData3);
                ViewBag.userMail = values3.Email;
				var createTicketViewModel = new CreateTicketViewModel
                {
                    resultTicketStatusDtos = values,
                    resultStaffDepartmentAllDtos = values2,
                };
                return View(createTicketViewModel);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketViewModel createTicketViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTicketViewModel.createTicketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7099/api/Tickets/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Outbox", "Mail");
            }
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7099/api/Tickets/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultTicketDto>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
