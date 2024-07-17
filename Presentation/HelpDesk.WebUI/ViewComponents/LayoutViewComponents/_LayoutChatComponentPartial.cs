using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.ViewComponents.LayoutViewComponents
{
    public class _LayoutChatComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
