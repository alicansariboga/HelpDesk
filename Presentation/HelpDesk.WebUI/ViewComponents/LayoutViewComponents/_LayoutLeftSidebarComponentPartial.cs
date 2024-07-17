using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.ViewComponents.LayoutViewComponents
{
    public class _LayoutLeftSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
