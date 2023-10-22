using System.ComponentModel.DataAnnotations;

namespace Core_Proje1.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Lütfen Şifrenizi tekrar Giriniz")]
        [Compare("Password", ErrorMessage ="Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Lütfen Mail Adresinizi Giriniz")]
        public string Mail { get; set; }
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
    


    }
}
