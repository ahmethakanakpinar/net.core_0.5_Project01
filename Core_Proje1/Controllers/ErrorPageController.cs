using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
