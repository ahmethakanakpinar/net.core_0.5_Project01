using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
