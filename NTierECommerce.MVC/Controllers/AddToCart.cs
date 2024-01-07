using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Helpers;
using NTierECommerce.MVC.Models;

namespace NTierECommerce.MVC.Controllers
{
    public class AddToCart : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AddToCart(IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id, int inputQuantity)
        {
            Cart cartSession;

            var getProductList =await _productRepository.GetAllActive();
            var product = getProductList.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                CartItem cartItem = new CartItem();
                cartItem.Id = product.Id;
                cartItem.ProductName = product.ProductName;
                cartItem.UnitPrice = Math.Round(product.UnitPrice, 2);
                cartItem.Quantity = inputQuantity;
                cartItem.ImagePath = product.ImagePath;

                var getCategory = await _categoryRepository.GetById(product.CategoryId);
                cartItem.CategoryName = getCategory.CategoryName;

                if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null)
                {
                    if(ProductStockControl(product.UnitsInStock, cartItem.Quantity) == true)
                    {
                        //Eğer sepet adında herhangi bir session yok ise yenisini oluşturuyor.
                        cartSession = new Cart();
                        cartSession.AddItem(cartItem);

                        SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
                    }
                }
                else
                {
                    //Eğer sepet adında herhangi bir session var ise onu cartSession a aktarıyor.
                    cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");                  

                    if (cartSession._myCart.ContainsKey(id))
                    {
                        cartItem.Quantity += cartSession._myCart[id].Quantity;
                        if(ProductStockControl(product.UnitsInStock, cartItem.Quantity) == true)
                        {
                            cartSession.UpdateItem(cartItem);
                        }                        
                    }
                    else if(!cartSession._myCart.ContainsKey(id) && ProductStockControl(product.UnitsInStock, cartItem.Quantity) == true)
                    {
                        cartSession.AddItem(cartItem);
                    }

                    SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
                }
                
                return RedirectToAction("Index", "Product", new { productid = id });
            }
            return View();
        }

        //Sepetteki ürün miktarının ürün stok adetinden fazla olup olmadığını kontrol eden metot
        public bool ProductStockControl(int unitsInStock, int cartQuantity)
        {
            if(cartQuantity > unitsInStock)
            {
                TempData["StockError"] = "Sepete eklemek istediğiniz miktar ürünün stok miktarından fazla! Sepette en fazla " + unitsInStock + " olabilir!";
                return false;
            }
            
            return true;
        }
    }
}
