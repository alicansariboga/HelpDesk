using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
