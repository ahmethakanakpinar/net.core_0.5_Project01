using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
