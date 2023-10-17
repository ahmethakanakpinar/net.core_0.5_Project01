using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class ContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());

        public IActionResult Index()
        {
            var values = _messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageManager.TGetByID(id);
            _messageManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
