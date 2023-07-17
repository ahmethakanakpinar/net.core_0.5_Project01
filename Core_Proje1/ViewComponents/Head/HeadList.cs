using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core_Proje1.ViewComponents.Head
{
    public class HeadList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
