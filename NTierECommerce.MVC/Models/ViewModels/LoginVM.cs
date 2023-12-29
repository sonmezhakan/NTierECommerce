using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "(Kullanıcı adı boş olamaz!)")]
        [Display(Name = "User Name")]
        [MaxLength(64)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "(Şifre boş olamaz!)")]
        [Display(Name = "Password")]
        [MaxLength(64)]
        public string Password { get; set; }
    }
}
