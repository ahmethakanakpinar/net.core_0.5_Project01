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
            var values = featureManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddFeature() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFeature(Feature feature) 
        {
            featureManager.TAdd(feature);
            return RedirectToAction("Index");
        }
        
    }
}
