using HelpDesk.DTO.AppUserDtos;
using HelpDesk.DTO.StaffDepartmentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HelpDesk.WebUI.ViewComponents.LayoutAdminViewComponents
{
    public class _LayoutAdminLeftSiderbarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _LayoutAdminLeftSiderbarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            int userId = Convert.ToInt32(id);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7099/api/AppUsers/" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAppUserDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
