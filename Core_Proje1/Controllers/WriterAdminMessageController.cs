using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class WriterAdminMessageController : Controller
    {
        public IActionResult ReceiverMessageList()
        {
            return View();
        }
        public IActionResult SenderMessageList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(int i)
        {
            return View();
        }
    }
}
