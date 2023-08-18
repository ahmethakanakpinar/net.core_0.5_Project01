using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IActionResult Index()
        {
            @ViewBag.Default1 = "Liste";
            @ViewBag.Default2 = "Feature";
            @ViewBag.Default3 = "Başlık";
            var values = featureManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddFeature() 
        {
            @ViewBag.Default1 = "Ekle";
            @ViewBag.Default2 = "Feature";
            @ViewBag.Default3 = "Başlık";
            return View();
        }
        [HttpPost]
        public IActionResult AddFeature(Feature feature) 
        {
            featureManager.TAdd(feature);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id) 
        {
            @ViewBag.Default1 = "Düzenle";
            @ViewBag.Default2 = "Feature";
            @ViewBag.Default3 = "Başlık";
            var values = featureManager.TGetByID(id);
            return View(values); 
        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature feature) 
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index");
        }
        
    }
}
