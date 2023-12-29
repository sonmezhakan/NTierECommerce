using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class AppUserRoleVM
    {
		[Display(Name = "ID :")]
		public int ID { get; set; }

        [Required(ErrorMessage = "(Role Adı Boş Geçilemez!)")]
        [Display(Name = "Role Name :")]
        [MaxLength(64)]
        public string Name { get; set; }

        [Display(Name = "Description :")]
        [MaxLength(255)]
        public string? Description { get; set; }
    }
}
