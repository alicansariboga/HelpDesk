﻿using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
