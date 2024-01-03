using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.Entities.Entities;

namespace NTierECommerce.MVC.Controllers
{
	public class SignoutController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public SignoutController(SignInManager<AppUser> signInManager)
        {
			_signInManager = signInManager;
		}
        public async Task<IActionResult> Index()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index","Home");
		}
	}
}
