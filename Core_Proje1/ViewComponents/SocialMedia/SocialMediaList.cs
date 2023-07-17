using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
