using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        UserMessageManager messageManager = new UserMessageManager(new EfUserMessageDal());
        public IViewComponentResult Invoke()
        {
            var values = messageManager.TGetList();
            return View(values);
        }
    }
}
