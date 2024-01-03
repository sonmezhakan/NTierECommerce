using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTierECommerce.Common;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels;
using System.Web;

namespace NTierECommerce.MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
        {
            if(ModelState.IsValid)
            {
                if(await _userManager.FindByNameAsync(userRegisterVM.UserName) == null)
                {
					if (await _userManager.FindByEmailAsync(userRegisterVM.Email) == null)
                    {
                        if(await _userManager.Users.AnyAsync(x=>x.PhoneNumber == userRegisterVM.PhoneNumber) != true)
                        {
                            AppUser appUser = new AppUser()
                            {
                                UserName = userRegisterVM.UserName,
                                Email = userRegisterVM.Email,
                                PhoneNumber = userRegisterVM.PhoneNumber,
                                Address = userRegisterVM.Address,
                            };

                            var result =  await _userManager.CreateAsync(appUser,userRegisterVM.Password);
                            await _userManager.AddToRoleAsync(appUser, "Member");

                            if(result.Succeeded)
                            {
								await MailSender(appUser);
							}
                            else
                            {
								TempData["Error"] = "bir hata meydana geldi!";
								return View(userRegisterVM);
							}
                            

							return RedirectToAction("Index", "Login");

                        }
                        else
                        {
                            TempData["Error"] = "Böyle bir telefon numarası bulunmaktadır!";
                            return View(userRegisterVM);
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Böyle bir email bulunmaktadır!";
                        return View(userRegisterVM);
                    }
                }
                else
                {
                    TempData["Error"] = "Böyle bir kullanıcı adı bulunmaktadır!";
                    return View(userRegisterVM);
                }
            }
            TempData["Error"] = "Lütfen gerekli alanları doldurunuz!";
            return View(userRegisterVM);
        }

        public async Task<IActionResult> MailSender(AppUser appUser)
        {
			var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
			var encodeToken = HttpUtility.UrlEncode(token.ToString());

			string confirmationLink = Url.Action("Confirmation", "Home", new { id = appUser.Id, token = encodeToken }, Request.Scheme);

			EmailSender.SendEmail(appUser.Email, "Üyelik Aktivasyon", $"Lütfen linki tıklayın. {confirmationLink}");

			TempData["Success"] = "Kayıt Başarılı! Aktivasyon Maili Gönderilmiştir!";

            return View();
		}

		public async Task<IActionResult> Confirmation(string id, string token)
		{
			//kullanıcı var mı?
			var user = await _userManager.FindByIdAsync(id);
			if (user != null)
			{
				var decodeToken = HttpUtility.UrlDecode(token);
				var result = await _userManager.ConfirmEmailAsync(user, decodeToken);

				if (result.Succeeded)
				{
					return RedirectToAction("Login");
				}
			}
			//eğer kullanıcı varsa ilgili kullanıcının EmailConfimation özelliğini true yap.
			return RedirectToAction("Index", "Home");
		}


		public IActionResult Privacy()
		{
			return View();
		}
	}
}
