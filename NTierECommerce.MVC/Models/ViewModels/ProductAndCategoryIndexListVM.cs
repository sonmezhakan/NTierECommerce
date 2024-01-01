using NTierECommerce.MVC.Models.ViewModels.Category;
using NTierECommerce.MVC.Models.ViewModels.Product;

namespace NTierECommerce.MVC.Models.ViewModels
{
    public class ProductAndCategoryIndexListVM
	{
        public List<ProductIndexListVM> ProductIndexListVMs { get; set; }
        public List<CategoryIndexListVM> CategoryIndexListVMs { get; set; }
    }
}
