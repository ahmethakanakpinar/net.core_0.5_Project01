using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
