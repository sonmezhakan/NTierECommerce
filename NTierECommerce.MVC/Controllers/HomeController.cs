using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models;
using NTierECommerce.MVC.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels.Category;
using NTierECommerce.MVC.Models.ViewModels.Product;
using System.Diagnostics;

namespace NTierECommerce.MVC.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryRepository;
		private readonly IProductService _productRepository;

		public HomeController(ILogger<HomeController> logger, IMapper mapper, ICategoryService categoryRepository, IProductService productRepository)
		{
			_logger = logger;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
			_productRepository = productRepository;
		}
		
		public async Task<IActionResult> Index(int? categoryid)
		{

			if (categoryid != null && await _categoryRepository.GetByActive((int)categoryid) == true)
			{
				//Kategoriye göre aktif ürünleri getir
				var getProducts = await _productRepository.GetAllCategoryById((int)categoryid);
				List<ProductIndexListVM> productIndexListVMs = _mapper.Map<List<ProductIndexListVM>>(getProducts);

				//Aktif kategorileri getir
				var getCategories =await _categoryRepository.GetAllActive();
				List<CategoryIndexListVM> categoryIndexListVMs = _mapper.Map<List<CategoryIndexListVM>>(getCategories);

				//getProducts ve getCategories olarak parametre verilen metottan bize aynı view model üzerinden hem ürün hemde kategori döndürüyor.
				var getProductAndCategory = ProductAndCategoryList(productIndexListVMs, categoryIndexListVMs);

				return View(getProductAndCategory);
			}
			else if (categoryid == null)
			{
				//Aktif ürünleri getir
				var getProducts =await _productRepository.GetAllActive();
                List<ProductIndexListVM> productIndexListVMs = _mapper.Map<List<ProductIndexListVM>>(getProducts);

                //Aktif kategorileri getir
                var getCategories = await _categoryRepository.GetAllActive();
                List<CategoryIndexListVM> categoryIndexListVMs = _mapper.Map<List<CategoryIndexListVM>>(getCategories);

                //getProducts ve getCategories olarak parametre verilen metottan bize aynı view model üzerinden hem ürün hemde kategori döndürüyor.
                var getProductAndCategory = ProductAndCategoryList(productIndexListVMs, categoryIndexListVMs);

				return View(getProductAndCategory);
			}
			else
			{

				return RedirectToAction();
			}

		}

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public ProductAndCategoryIndexListVM ProductAndCategoryList(List<ProductIndexListVM> products, List<CategoryIndexListVM> categories)
		{

			ProductAndCategoryIndexListVM productAndCategoryIndexListVM = new ProductAndCategoryIndexListVM()
			{
				ProductIndexListVMs = products,
				CategoryIndexListVMs = categories
			};

			return productAndCategoryIndexListVM;
		}

	}
}