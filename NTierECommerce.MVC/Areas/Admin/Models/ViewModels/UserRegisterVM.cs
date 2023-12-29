using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class UserRegisterVM
    {
		[Display(Name = "ID :")]
		public int ID { get; set; }

        [Required(ErrorMessage = "(Kullanıcı Adı Boş Geçilemez!)")]
        [Display(Name = "User Name :")]
        [MaxLength(64)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "(Şifre Boş Geçilemez!)")]
        [Display(Name = "Password :")]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required(ErrorMessage = "(Email Boş Geçilemez!)")]
        [Display(Name = "Email :")]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "(Telefon Numarası Boş Geçilemez!)")]
        [Display(Name = "Phone Number :")]
        [MaxLength(11)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address :")]
        [MaxLength(500)]
        public string Address { get; set; }
    }
}
