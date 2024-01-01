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
using System.IO;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;

		public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}
		public async Task<IActionResult> Index()
		{
			var productList = _productRepository.GetAll().Select(x => new Product
			{
				Id = x.Id,
				CategoryId = x.CategoryId,
				ProductName = x.ProductName,
				UnitPrice = x.UnitPrice,
				UnitsInStock = x.UnitsInStock,
				IsActive = x.IsActive,
				ImagePath = x.ImagePath,
			});

			List<ProductListVM> products = new List<ProductListVM>();

			foreach (var item in productList)
			{
				ProductListVM productListVM = new ProductListVM();
				productListVM.ID = item.Id;
				productListVM.ProductName = item.ProductName;
				productListVM.UnitPrice = item.UnitPrice;
				productListVM.UnitsInStock = item.UnitsInStock;
				productListVM.IsActive = item.IsActive;
				productListVM.ImagePath = item.ImagePath;

				var getCategory = await GetCategory(item.CategoryId);
				productListVM.CategoryName = getCategory.CategoryName;

				products.Add(productListVM);
			}
			return View(products);
		}

		public IActionResult Add()
		{
			ViewBagCategloryList();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductVM productVM, IFormFile productImage)
		{
			productVM.ImagePath = await ImageFile(productImage);
			if (productVM.ImagePath != null)
			{
				Product product = new Product()
				{
					CategoryId = productVM.CategoryId,
					ProductName = productVM.ProductName,
					UnitPrice = productVM.UnitPrice,
					UnitsInStock = productVM.UnitsInStock,
					IsActive = productVM.IsActive,
					ImagePath = productVM.ImagePath
				};

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
				ProductDetailVM productDetailVM = new ProductDetailVM()
				{
					ID = getProduct.Id,
					CategoryName = getCategory.CategoryName,
					ProductName = getProduct.ProductName,
					UnitPrice = getProduct.UnitPrice,
					UnitsInStock = getProduct.UnitsInStock,
					IsActive = getProduct.IsActive,
					ImagePath = getProduct.ImagePath
				};
				return View(productDetailVM);
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			ViewBagCategloryList();

			var getProduct = await GetProduct(id);
			if (getProduct != null)
			{
				ProductVM productVM = new ProductVM()
				{
					ID = getProduct.Id,
					CategoryId = getProduct.CategoryId,
					ProductName = getProduct.ProductName,
					UnitPrice = getProduct.UnitPrice,
					UnitsInStock = getProduct.UnitsInStock,
					IsActive = getProduct.IsActive,
					ImagePath = getProduct.ImagePath
				};
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

			if (productVM.ImagePath != null)
			{
				Product product = new Product()
				{
					Id = productVM.ID,
					CategoryId = productVM.CategoryId,
					ProductName = productVM.ProductName,
					UnitPrice = productVM.UnitPrice,
					UnitsInStock = productVM.UnitsInStock,
					IsActive = productVM.IsActive,
					ImagePath = productVM.ImagePath,
				};

				await _productRepository.Update(product);
				return RedirectToAction("Index", "Product");
			}


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
		public void ViewBagCategloryList()
		{
			ViewBag.CategoryListItem = _categoryRepository.GetAllActive().Select(c => new SelectListItem
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
