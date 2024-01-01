using Microsoft.AspNetCore.Mvc;

namespace NTierECommerce.MVC.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AccessDenied()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}
