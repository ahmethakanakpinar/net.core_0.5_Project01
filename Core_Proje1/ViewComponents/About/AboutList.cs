using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }
    }
}
