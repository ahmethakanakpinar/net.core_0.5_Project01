using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
