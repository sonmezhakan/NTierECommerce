using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class UserUpdateVM
    {
        [Display(Name = "ID :")]
        public int ID { get; set; }

        [Display(Name = "Address :")]
        [MaxLength(500)]
        public string Address { get; set; }
    }
}
