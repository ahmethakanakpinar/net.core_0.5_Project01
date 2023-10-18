using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        public IActionResult SendMessage(WriterMessage p)
        {
            var adminemail = "admin@gmail.com";
            var adminname = "Admin";
            p.Sender = adminemail;
            p.SenderName = adminname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageManager.TAdd(p);
            return View();
        }
    }
}
