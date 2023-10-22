using BusinessLayer.Concrete;
using Core_Proje1.Areas.Writer.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        private readonly UserManager<WriterUser>  _userManager;

        public WriterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _writerManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteWriter(int id)
        {
            var user = _writerManager.TGetByID(id);
            _writerManager.TDelete(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWriter(UserRegisterViewModel p)
        {
            if (!ModelState.IsValid)
            {
                // ModelState içindeki hataları görüntüle
                foreach (var key in ModelState.Keys)
                {
                    var modelError = ModelState[key];
                    foreach (var error in modelError.Errors)
                    {
                        // Hata mesajını logla veya hata mesajını başka bir şekilde görüntüle
                        Console.WriteLine($"Hata: {key} - {error.ErrorMessage}");
                    }
                }
                // Hata mesajlarına göre işlem yapabilirsiniz
            }
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                p.ImageUrl = imagename;
            }
            else
            {
                p.ImageUrl = "";
            }
            if (ModelState.IsValid)
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageUrl = p.ImageUrl,
                    PhoneNumber = p.PhoneNumber
                };
                var result = await _userManager.CreateAsync(w, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Writer");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

    }
}
