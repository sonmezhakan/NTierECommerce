using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Common;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Helpers;
using NTierECommerce.MVC.Models;
using System.Web;

namespace NTierECommerce.MVC.Controllers
{
	[Authorize]
	public class MyCartController : Controller
	{
        private readonly IMapper _mapper;
        private readonly IOrderService _orderRepository;
		private readonly IOrderDetailService _orderDetailRepository;
		private readonly UserManager<AppUser> _userManager;
		private readonly IShippingAddressService _shippingAddressRepository;
		private readonly IProductService _productRepository;

		public MyCartController(IMapper mapper, IOrderService orderRepository, IOrderDetailService orderDetailRepository, UserManager<AppUser> userManager, IShippingAddressService shippingAddressRepository, IProductService productRepository)
		{
            _mapper = mapper;
            _orderRepository = orderRepository;
			_orderDetailRepository = orderDetailRepository;
			_userManager = userManager;
			_shippingAddressRepository = shippingAddressRepository;
			_productRepository = productRepository;
		}
		public async Task<IActionResult> Index()
		{
			if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
			{
				var sepet = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

				var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
				var getMyAddres = await _shippingAddressRepository.GetByUserIdAddressList(getUser.Id);

				ViewBag.ShippingAddress = getMyAddres.Select(x => new ShippingAddress
				{
					Id = x.Id,
					AddressName = x.AddressName
				}).Select(sa => new SelectListItem
				{
					Text = sa.AddressName,
					Value = sa.Id.ToString()
				}).ToList();
				return View(sepet);
			}
			else
			{
				return View();
			}
		}
		
		[HttpPost]
		public async Task<IActionResult> CompleteCart(int addressId)
		{

			var cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
			
			if (cartSession != null)
			{
				if(await CartProductStockControl(cartSession) == false)
				{
					return View("Index","MyCart");
				}

				var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
				var checkMyAddress = await _shippingAddressRepository.GetByUserIdAndAddressId(getUser.Id, addressId);
				if (checkMyAddress != null)
				{
					
					Order order = new Order()
					{
						OrderDate = DateTime.Now,
						AppUser = getUser,
						ShippingAddress = checkMyAddress,
						ShipperId = 1
					};

					var orderAdded = await _orderRepository.Create(order);

					if (orderAdded == "Kayıt başarılı!")
					{
						int orderId = await _orderRepository.GetByOrderIdSearch(order);

						foreach (var item in cartSession._myCart)
						{
                            OrderDetail orderDetail = new OrderDetail()
                            {
                                OrderId = orderId,
                                ProductId = item.Value.Id,
                                UnitPrice = item.Value.UnitPrice,
                                Quantity = item.Value.Quantity
                            };

                            var orderDetailAdded = await _orderDetailRepository.Create(orderDetail);
							if (orderDetailAdded == "Kayıt başarılı!")
							{
								var getProduct = await _productRepository.GetById(item.Value.Id);
								getProduct.UnitsInStock -= item.Value.Quantity;
								await _productRepository.Update(getProduct);

							}
						}
						await MailSender(getUser, orderId);
						cartSession.AllDelete();

						SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
						return RedirectToAction("Index", "MyOrders");
					}
				}
				else
				{
					TempData["Error"] = "Geçersiz Adres!";
					return View("Index", "MyCart");
				}

			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("Index", "Home");
		}

		
		public IActionResult Delete(int id)
		{
			var cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
			if (cartSession != null)
			{
				if (cartSession._myCart.ContainsKey(id))
				{
					cartSession.DeleteItem(cartSession._myCart[id]);
					SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
				}
			}
			return RedirectToAction("Index", "MyCart");
		}


		public async Task<bool> CartProductStockControl(Cart cart)
		{
			foreach (var item in cart._myCart)
			{
				var getProduct = await _productRepository.GetById(item.Value.Id);
				if (item.Value.Quantity > getProduct.UnitsInStock)
				{
					TempData["Error"] = "Sepetteki " + getProduct.ProductName + " adlı ürününden en fazla " + getProduct.UnitsInStock + " adet sipariş verebilirsiniz!";
					return false;
				}
			}
			return true;
		}
		public async Task<IActionResult> MailSender(AppUser appUser, int orderId)
		{
			string orderLink = Url.Action("Detail", "MyOrders", orderId, Request.Scheme);
			orderLink += "?orderid=" + orderId;
			string emailBody = $@"<p>Siparişiniz alınmıştır! <a href=""{orderLink}"">#{orderId}</a> Numaralı siparişiniz hazırlanmaya başlandı!</p>";
			EmailSender.SendHtmlEmail(appUser.Email, "Siparişiniz Alınmıştır!" , emailBody);

			return View();
		}

	}
}
