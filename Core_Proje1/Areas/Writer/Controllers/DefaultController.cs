using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje1.Areas.Writer.Controllers
{
        [Area("Writer")]
        [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values = _announcementManager.TGetList();
            return View(values);
        }
    }
}
