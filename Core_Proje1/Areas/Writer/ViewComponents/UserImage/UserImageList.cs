using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Areas.Writer.ViewComponents.UserImage
{
    public class UserImageList: ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public UserImageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = values.ImageUrl;
            return View();
        }
    }
}
