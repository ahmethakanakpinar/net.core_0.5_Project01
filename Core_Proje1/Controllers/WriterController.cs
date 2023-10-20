using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public IActionResult Index()
        {
            var values = _writerManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteWriter(int id)
        {
            var user = _writerManager.TGetByID(id);
            _writerManager.TDelete(user);
            return RedirectToAction("Index");
        }

    }
}
