using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje1.Controllers
{
    [Authorize(Roles = "Admin")]

    public class WriterAdminMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessage());

        public IActionResult ReceiverMessageList()
        {
            var adminemail = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(adminemail).OrderByDescending(x => x.WriterMessageID).ToList();
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            var adminemail = "admin@gmail.com";
            var values = _writerMessageManager.GetListSenderMessage(adminemail).OrderByDescending(x => x.WriterMessageID).ToList();
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
            p.Date = Convert.ToDateTime(DateTime.Now);
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            usernamesurname = (usernamesurname != null) ? usernamesurname : "";
            p.ReceiverName = usernamesurname;
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList", "WriterAdminMessage");

        }
        public IActionResult DeleteMessage(int id)
        {
            var values = _writerMessageManager.TGetByID(id);
            _writerMessageManager.TDelete(values);
            var adminemail = "admin@gmail.com";
            var dizin = (values.Sender == adminemail) ? "SenderMessageList" : "ReceiverMessageList";
            return RedirectToAction(dizin);
        }
    }
}
