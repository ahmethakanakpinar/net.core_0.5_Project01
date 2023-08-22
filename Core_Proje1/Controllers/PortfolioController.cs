using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.default1 = "Liste";
            ViewBag.default2 = "Portfolio";
            ViewBag.default3 = "Portfolio";
            var values = portfolioManager.TGetList();
            return View(values);
        }
    }
}
