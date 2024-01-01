namespace NTierECommerce.MVC.Models.ViewModels.Product
{
    public class ProductPageVM
    {
        public ProductDetailVM ProductDetailVM { get; set; }
        public List<ProductDetailVM> RelatedProducts { get; set; }
    }
}
