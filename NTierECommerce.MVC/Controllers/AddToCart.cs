using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.MVC.Helpers;
using NTierECommerce.MVC.Models;

namespace NTierECommerce.MVC.Controllers
{
    public class AddToCart : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productRepository;
        private readonly ICategoryService _categoryRepository;

        public AddToCart(IMapper mapper, IProductService productRepository,ICategoryService categoryRepository)
        {
            _mapper = mapper;
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
                CartItem cartItem = _mapper.Map<CartItem>(product);
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
