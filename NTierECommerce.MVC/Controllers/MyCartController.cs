using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.MVC.Helpers;
using NTierECommerce.MVC.Models;

namespace NTierECommerce.MVC.Controllers
{
	public class MyCartController : Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
			{
				var sepet = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
				return View(sepet);
			}
			else
			{
				return View();
			}
		}

		[Authorize]
		public IActionResult CompleteCart()
		{
			//todo: sepette bulunan boşaltılacak ve bir Order (Sipariş) oluşturulacak. Sipariş No, Hangi kullanıcı tarafından sipariş alındığı kaydedilecek.
			//todo: OrderDetail tablosuna sipariş ve ürün bilgileri kaydedilecek.
			//todo: kullanıcıya bir sipariş email'i gönderilecek. İçerisinde sipariş numarası ile birlikte.

			return View();
		}
	}
}
