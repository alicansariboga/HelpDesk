using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.ViewComponents.LayoutViewComponents
{
    public class _LayoutRightSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
