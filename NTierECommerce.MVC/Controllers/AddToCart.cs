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

        public AddToCart(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id, int inputQuantity)
        {
            Cart cartSession;

            var product = _productRepository.GetAllActive().FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                CartItem cartItem = new CartItem();
                cartItem.Id = product.Id;
                cartItem.ProductName = product.ProductName;
                cartItem.UnitPrice = Math.Round(product.UnitPrice, 2);
                cartItem.Quantity = inputQuantity;

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
