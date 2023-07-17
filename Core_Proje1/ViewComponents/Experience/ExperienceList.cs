using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Experience
{
    public class ExperienceList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
