using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;

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

                            await _userManager.CreateAsync(appUser,userRegisterVM.Password);
                            await _userManager.AddToRoleAsync(appUser, "Member");

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
    }
}
