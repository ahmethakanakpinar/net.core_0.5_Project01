using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje1.Controllers
{
    public class WriterAdminMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessage());

        public IActionResult ReceiverMessageList()
        {
            var adminemail = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(adminemail);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            var adminemail = "admin@gmail.com";
            var values = _writerMessageManager.GetListSenderMessage(adminemail);
            return View(values);
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
