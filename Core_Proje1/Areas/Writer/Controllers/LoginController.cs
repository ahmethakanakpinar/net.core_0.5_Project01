using Core_Proje1.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;

        public LoginController(SignInManager<WriterUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
                
                if (result.Succeeded) 
                {
                    return Redirect("/Writer/Default/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                }
            }
            return View();
        }
    }
}
