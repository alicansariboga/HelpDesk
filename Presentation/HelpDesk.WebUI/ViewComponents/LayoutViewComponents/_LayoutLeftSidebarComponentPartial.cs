using HelpDesk.DTO.StaffDepartmentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HelpDesk.WebUI.ViewComponents.LayoutViewComponents
{
    public class _LayoutLeftSidebarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _LayoutLeftSidebarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            int userId = Convert.ToInt32(id);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7099/api/StaffDepartments/StaffDepartmentListByUserId?id=" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStaffDepartmentAllDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
