using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.MVC.Models;
using NTierECommerce.MVC.Models.ViewModels.Product;
using NTierECommerce.MVC.Helpers;
using AutoMapper;

namespace NTierECommerce.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int? productid)
        {
            var getProduct = await _productRepository.GetById((int)productid);
            if (getProduct != null && getProduct.IsActive == true)
            {
                ProductDetailVM productDetailVM = _mapper.Map<ProductDetailVM>(getProduct);

                var getRelatedProducts = await _productRepository.GetRelatedProducts(4);

                List<ProductDetailVM> productDetailVMs = _mapper.Map<List<ProductDetailVM>>(getRelatedProducts);

                ProductPageVM productPageVM = new ProductPageVM
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
