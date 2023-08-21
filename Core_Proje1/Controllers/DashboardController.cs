using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.default1 = "Dashboard";
            ViewBag.default2 = "Dashboard";
            ViewBag.default3 = "Dashboard";
            return View();
        }
    }
}
