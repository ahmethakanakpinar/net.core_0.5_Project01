using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
