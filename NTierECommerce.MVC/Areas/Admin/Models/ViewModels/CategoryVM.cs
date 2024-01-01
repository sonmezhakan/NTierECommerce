using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class CategoryVM
    {
		[Display(Name = "ID :")]
		public int ID { get; set; }

        [Required(ErrorMessage = "(Kategori Adı Boş Geçilemez!)")]
        [Display(Name = "Category Name :")]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [Display(Name = "Description :")]
        [MaxLength (255)]
        public string? Description { get; set; }

		[Display(Name = "Statu :")]
		public bool IsActive { get; set; }
    }

}
