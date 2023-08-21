using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.SkillCount = c.Skills.Count();
            ViewBag.NotReadMessagesCount = c.Messages.Where(x => x.Status == false).Count();
            ViewBag.ReadMessagesCount = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.ExperiencesCount = c.Experiences.Count();
            return View();
        }
    }
}
