using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Models.ViewModels;
using NuGet.Protocol;

namespace NTierECommerce.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.FindByNameAsync(loginVM.UserName) != null)
                {
                    var getUser = await _userManager.FindByNameAsync(loginVM.UserName);
                    
                    
                    var result = await _signInManager.PasswordSignInAsync(getUser, loginVM.Password,true,true);
					var emailConfirm = await _userManager.IsEmailConfirmedAsync(getUser);
					if (result.Succeeded && emailConfirm == true)
                    {
						return RedirectToAction("Index", "Home");
					}
                    else if(result.Succeeded && emailConfirm == false)
                    {
						await _signInManager.SignOutAsync();//PasswordSignInAsycn metotu şifre olduğunda giriş işlemini yapıyor. O yüzden mail onaylı değil ise çıkış yaptırmak gerekiyor.

						TempData["Error"] = "Lütfen Mailiniz Onaylayınız!";
						return RedirectToAction("Index", "Login");
					}
                    else
                    {
						TempData["Error"] = "Şifre Hatalı!";
						return View(loginVM);
					}
                }
                else
                {
                    TempData["Error"] = "Böyle bir kullanıcı adı bulunmamaktadır!";
                    return View(loginVM);
                }
            }
            TempData["Error"] = "Lütfen gerekli alanları doldurunuz!";
            return View(loginVM);
        }

		
	}
}
