using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class ProductVM
    {
        private decimal _unitPrice;

        [Display(Name = "ID :")]
        public int ID { get; set; }

        [Required(ErrorMessage = "(Kategori Boş Geçilemez!)")]
        [Display(Name = "Category Id :")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "(Ürün Adı Boş Geçilemez!)")]
        [Display(Name = "Product Name :")]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "(Fiyat Boş Geçilemez!)")]
        [Display(Name = "Unit Price :")]
        public decimal UnitPrice { get { return _unitPrice; } set { _unitPrice = Math.Round(value, 2); } }

        [Required(ErrorMessage = "(Stok Boş Geçilemez!)")]
        [Display(Name = "Units In Stock :")]
        public int UnitsInStock { get; set; }

		[Display(Name = "Statu :")]
		public bool IsActive { get; set; }

        [Display(Name = "Image :")]
        [MaxLength(255)]
        public string? ImagePath { get; set; }
    }
}
