using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
