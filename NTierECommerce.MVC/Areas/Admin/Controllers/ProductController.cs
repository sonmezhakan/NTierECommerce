using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var productList  = _productRepository.GetAll().Select(x=> new Product
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                IsActive = x.IsActive,
            });

            List<ProductListVM> products = new List<ProductListVM>();

            foreach (var item in productList)
            {
                ProductListVM productListVM = new ProductListVM();
                productListVM.ID = item.Id;
                productListVM.ProductName = item.ProductName;
                productListVM.UnitPrice = item.UnitPrice;
                productListVM.IsActive = item.IsActive;

                var getCategory = await GetCategory(item.CategoryId);
                productListVM.CategoryName = getCategory.CategoryName;

                products.Add(productListVM);
            }
            return View(products);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductVM productVM)
        {
            if(ModelState.IsValid)
            {
                Product product = new Product()
                {
                    CategoryId = productVM.CategoryId,
                    ProductName = productVM.ProductName,
                    UnitPrice = productVM.UnitPrice,
                    IsActive = productVM.IsActive,
                    //Görsel zorunlu oluğu için default olarak bir resim linki aşağıda ekleniyor
                    ImagePath = "https://media.licdn.com/dms/image/C4D0BAQEAGXVsnKe6Uw/company-logo_200_200/0/1633955568753/galatasaray_logo?e=2147483647&v=beta&t=qAEvuY7yW6LNJyFx2hqYmhuKxeaXmU0uZJRuUngLQeU"
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
            if(getProduct != null)
            {
                var getCategory = await GetCategory(id);
                ProductDetailVM productDetailVM = new ProductDetailVM()
                {
                    ID = getProduct.Id,
                    CategoryName = getCategory.CategoryName,
                    ProductName = getProduct.ProductName,
                    UnitPrice = getProduct.UnitPrice,
                    IsActive = getProduct.IsActive
                };
                return View(productDetailVM);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var getProduct = await GetProduct(id);
            if (getProduct != null)
            {
                ProductVM productVM = new ProductVM()
                {
                    ID = getProduct.Id,
                    CategoryId = getProduct.CategoryId,
                    ProductName = getProduct.ProductName,
                    UnitPrice = getProduct.UnitPrice,
                    IsActive = getProduct.IsActive
                };
                return View(productVM);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductVM productVM)
        {
            if(ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Id = productVM.ID,
                    CategoryId = productVM.CategoryId,
                    ProductName = productVM.ProductName,
                    UnitPrice = productVM.UnitPrice,
                    IsActive = productVM.IsActive,
                    Status = Entities.Enums.DataStatus.Updated,
                    UpdatedComputerName = "Test Updated",
                    UpdatedIpAddress = "localhost updated",
                    UpdatedDate = DateTime.Now,
                    //Görsel zorunlu oluğu için default olarak bir resim linki aşağıda ekleniyor
                    ImagePath = "https://media.licdn.com/dms/image/C4D0BAQEAGXVsnKe6Uw/company-logo_200_200/0/1633955568753/galatasaray_logo?e=2147483647&v=beta&t=qAEvuY7yW6LNJyFx2hqYmhuKxeaXmU0uZJRuUngLQeU"
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
