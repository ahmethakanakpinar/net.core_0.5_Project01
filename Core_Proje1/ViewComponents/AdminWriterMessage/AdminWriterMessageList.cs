using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.AdminWriterMessage
{
    public class AdminWriterMessageList : ViewComponent
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessage());
        private readonly UserManager<WriterUser> _userManager;

        public AdminWriterMessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var usermail = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(usermail).OrderByDescending(x=>x.WriterMessageID).Take(5).ToList();
            return View(values);
        }
    }
}
