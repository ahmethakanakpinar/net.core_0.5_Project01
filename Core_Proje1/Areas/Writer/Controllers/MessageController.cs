using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessage());

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageManager.GetListReceiverMessage(p);
            return View(messageList);
        }
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = _writerMessageManager.GetListSenderMessage(p);
            return View(messagelist);
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p.Sender = user.Email;
            p.SenderName = user.Name + " " + user.Surname;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " "+ y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage", "Message");
        }
    }
}
