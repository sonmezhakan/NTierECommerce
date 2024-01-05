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
		private readonly ICategoryRepository _categoryRepository;
		private readonly IProductRepository _productRepository;

		public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, IProductRepository productRepository)
		{
			_logger = logger;
			_categoryRepository = categoryRepository;
			_productRepository = productRepository;
		}
		
		public async Task<IActionResult> Index(int? categoryid)
		{

			if (categoryid != null && await _categoryRepository.GetByActive((int)categoryid) == true)
			{
				//Kategoriye göre aktif ürünleri getir
				var getProducts = _productRepository.GetAllCategoryById((int)categoryid);

				//Aktif kategorileri getir
				var getCategories = _categoryRepository.GetAllActive();

				//getProducts ve getCategories olarak parametre verilen metottan bize aynı view model üzerinden hem ürün hemde kategori döndürüyor.
				var getProductAndCategory = ProductAndCategoryList(ProductIndexList(getProducts.ToList()), CategoryIndexListVM(getCategories.ToList()));

				return View(getProductAndCategory);
			}
			else if (categoryid == null)
			{
				//Aktif ürünleri getir
				var getProducts = _productRepository.GetAllActive();

				//Aktif kategorileri getir
				var getCategories = _categoryRepository.GetAllActive();

				//getProducts ve getCategories olarak parametre verilen metottan bize aynı view model üzerinden hem ürün hemde kategori döndürüyor.
				var getProductAndCategory = ProductAndCategoryList(ProductIndexList(getProducts.ToList()), CategoryIndexListVM(getCategories.ToList()));

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


		//Product tipindeki nesneyi ProductIndexListVM'e çeviriyor
		public List<ProductIndexListVM> ProductIndexList(List<Product> getProducts)
		{
			List<ProductIndexListVM> products = getProducts.Select(product => new ProductIndexListVM
			{
				ID = product.Id,
				ProductName = product.ProductName,
				UnitPrice = product.UnitPrice,
				ImagePath = product.ImagePath
			}).ToList();

			return products;
		}

		//Category tipindeki nesneyi CategoryIndexListVM'e çeviriyor
		public List<CategoryIndexListVM> CategoryIndexListVM(List<Category> getCategories)
		{

			List<CategoryIndexListVM> categories = getCategories.Select(category => new CategoryIndexListVM
			{
				ID = category.Id,
				CategoryName = category.CategoryName
			}).ToList();

			return categories;
		}

		//ProductIndexListVM ve CategoryIndexListVM tipindeki listeleri alıp ProductAndCategoryIndexListVM tipine çeviriyor
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