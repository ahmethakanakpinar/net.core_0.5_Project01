using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Header
{
    public class HeaderList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
