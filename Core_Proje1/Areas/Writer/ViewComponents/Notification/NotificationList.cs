using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Areas.Writer.ViewComponents.Notification
{
    public class NotificationList : ViewComponent
    {
        AnnouncementManager _AnnouncementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values = _AnnouncementManager.TGetList();
            return View(values);
        }
    }
}
