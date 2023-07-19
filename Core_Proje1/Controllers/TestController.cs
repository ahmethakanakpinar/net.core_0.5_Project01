using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
