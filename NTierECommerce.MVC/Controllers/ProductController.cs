using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.MVC.Models;
using NTierECommerce.MVC.Models.ViewModels.Product;
using NTierECommerce.MVC.Helpers;

namespace NTierECommerce.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int? productid)
        {
            var getProduct = await _productRepository.GetById((int)productid);
            if (getProduct != null && getProduct.IsActive == true)
            {
                ProductDetailVM productDetailVM = new ProductDetailVM()
                {
                    ID = getProduct.Id,
                    ProductName = getProduct.ProductName,
                    UnitPrice = getProduct.UnitPrice,
                    ImagePath = getProduct.ImagePath,
                    UnitsInStock = getProduct.UnitsInStock,
                };

                var getRelatedProducts = _productRepository.GetRelatedProducts(4);

                List<ProductDetailVM> productDetailVMs = getRelatedProducts.Select(product => new ProductDetailVM
                {
                    ID = product.Id,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    ImagePath = product.ImagePath,
                    UnitsInStock = product.UnitsInStock
                }).ToList();


                ProductPageVM productPageVM = new ProductPageVM()
                {
                    ProductDetailVM = productDetailVM,
                    RelatedProducts = productDetailVMs
                };

                return View(productPageVM);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

       

        
    }
}
