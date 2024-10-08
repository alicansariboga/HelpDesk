﻿using HelpDesk.DTO.MailDtos;
using HelpDesk.DTO.TicketDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HelpDesk.WebUI.Controllers
{
    public class MailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
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
        [Route("Mail/Inbox/Detail/{id}")]
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
        [Route("Mail/Outbox/Detail/{id}")]
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
    }
}
