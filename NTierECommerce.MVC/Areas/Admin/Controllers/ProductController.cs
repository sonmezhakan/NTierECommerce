using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.BLL.Concretes;
using NTierECommerce.Common.ImageHelpers;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels.Product;
using System.Data;
using System.IO;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,IMapper mapper)
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
            _mapper = mapper;
        }
		public async Task<IActionResult> Index()
		{
            var categoryList = await _categoryRepository.GetAll();
		
            var getProductList =await _productRepository.GetAll();

            List<ProductDetailVM> products = getProductList.Select(product => new ProductDetailVM
			{
				ID = product.Id,

				ProductName = product.ProductName,
				UnitPrice = product.UnitPrice,
				UnitsInStock = product.UnitsInStock,
				IsActive = product.IsActive,
				ImagePath = product.ImagePath,

				CategoryName = categoryList.FirstOrDefault(x => x.Id == product.CategoryId).CategoryName
            }).ToList();

			
			return View(products);
		}

		public async Task<IActionResult> Add()
		{
			await ViewBagCategloryList();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductVM productVM, IFormFile productImage)
		{
			productVM.ImagePath = await ImageFile(productImage);
			if (productVM.ImagePath != null)
			{
				Product product = _mapper.Map<Product>(productVM);

				await _productRepository.Create(product);
				return RedirectToAction("Index", "Product");
			}


			TempData["Error"] = "Ürün Eklenemedi!";
			return View(productVM);
		}

		public async Task<IActionResult> Details(int id)
		{
			var getProduct = await GetProduct(id);
			if (getProduct != null)
			{
				var getCategory = await GetCategory(getProduct.CategoryId);
                ProductDetailVM productDetailVM = _mapper.Map<ProductDetailVM>(getProduct);
				productDetailVM.CategoryName = getCategory.CategoryName;

				return View(productDetailVM);
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			await ViewBagCategloryList();

			var getProduct = await GetProduct(id);
			if (getProduct != null)
			{
                ProductVM productVM = _mapper.Map<ProductVM>(getProduct);

				return View(productVM);
			}

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(ProductVM productVM, IFormFile productImage)
		{
			var getProduct = await GetProduct(productVM.ID);

			if (productImage != null)
			{
				ImageFileDelete(getProduct.ImagePath);
				productVM.ImagePath = await ImageFile(productImage);
			}
			else
			{
				productVM.ImagePath = getProduct.ImagePath;
			}

            Product product = _mapper.Map<Product>(productVM);

            var result = await _productRepository.Update(product);
			if(result != null) return RedirectToAction("Index", "Product");

            return View(productVM);        
		}

		public async Task<IActionResult> IsActivePassive(int id)
		{
			await _productRepository.Delete(await GetProduct(id));

			return RedirectToAction("Index", "Product");
		}
		public async Task<IActionResult> IsActiveActive(int id)
		{
			await _productRepository.IsActiveActive(await GetProduct(id));

			return RedirectToAction("Index", "Product");
		}

		public async Task<IActionResult> Destroy(int id)
		{
			await _productRepository.DestroyData(await GetProduct(id));

			return RedirectToAction("Index", "Product");
		}

		//ViewBag CategoryList
		public async Task ViewBagCategloryList()
		{
			var getCategoryList =await _categoryRepository.GetAllActive();

            ViewBag.CategoryListItem = getCategoryList.Select(c => new SelectListItem
			{
				Text = c.CategoryName,
				Value = c.Id.ToString()
			});
		}


		//ImageUpload Metot
		public async Task<string> ImageFile(IFormFile formFile)
		{
			if(formFile != null)
			{
                string path = "";
                var imageResult = ImageUploader.Upload(formFile.FileName);

                if (imageResult != "0" )
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", imageResult);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    };

                    return imageResult;
                }
                else
                {
                    TempData["Error"] = "Görsel formatı uygun değil.";
                    return "";
                }
            }
			else
			{
				return "";
			}
		}

		//Ürün resimlerinde değişiklik yapılacağı zaman ilk önce eski resmi silen metot
		public void ImageFileDelete(string imagePath)
		{
			if (!string.IsNullOrEmpty(imagePath) && imagePath != "placeholder.svg")
			{
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", imagePath);

				System.IO.File.Delete(path);
			}
		}


		//Sürekli Olarak GetById metotu kullanılıyordu. Kod tekrarını azaltmak için aşağıdaki metotlar oluşturulmuştur.
		public async Task<Product> GetProduct(int id)
		{
			return await _productRepository.GetById(id);
		}
		public async Task<Category> GetCategory(int id)
		{
			return await _categoryRepository.GetById(id);
		}

	}
}
