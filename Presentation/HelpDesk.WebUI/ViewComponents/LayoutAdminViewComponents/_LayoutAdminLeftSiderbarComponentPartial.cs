using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.ViewComponents.LayoutAdminViewComponents
{
    public class _LayoutAdminLeftSiderbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
