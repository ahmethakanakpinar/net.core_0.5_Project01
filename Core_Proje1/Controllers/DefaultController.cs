using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DefaultController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        //[HttpPost]
        //public PartialViewResult SendMessage(Message p)
        //{

        //    p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    p.Status = true;
        //    messageManager.TAdd(p);
        //    return PartialView();
        //}
        [HttpPost]
        public IActionResult SendMessage(Message p)
        {
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;
            messageManager.TAdd(p);

            // Başarılı bir işlem sonrasında başka bir sayfaya yönlendirme yapabilirsiniz
            return RedirectToAction("Index");
        }
    }
}
