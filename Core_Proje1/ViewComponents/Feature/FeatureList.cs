using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
