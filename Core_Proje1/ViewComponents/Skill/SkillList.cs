using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Skill
{
    public class SkillList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
