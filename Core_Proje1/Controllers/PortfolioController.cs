using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {

            portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }
        public IActionResult DeletePortfolio(int id) 
        {
            var values = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdatePortfolio(int id) 
        {
            var values = portfolioManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdatePortfolio(Portfolio portfolio)
        {
            portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }
    }
}
