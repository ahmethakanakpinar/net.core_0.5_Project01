﻿using BusinessLayer.Concrete;
using Core_Proje1.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin, Writer")]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null) 
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            if(p.OldPassword != null)
            {
                await _userManager.ChangePasswordAsync(user, p.OldPassword, p.Password);
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                //return Redirect("/Writer/Profile/Index");
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
