using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.ViewComponents.Message
{
    public class MessageList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
