﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.BLL.Concretes;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels.MyCart;
using NTierECommerce.MVC.Models.ViewModels.MyOrder;

namespace NTierECommerce.MVC.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
        }
		public async Task<IActionResult> Index()
		{
			var getUser = await _userManager.FindByNameAsync(User.Identity.Name);
			if (getUser != null)
			{
				UserRegisterVM registerVM = new UserRegisterVM()
				{
					ID = getUser.Id,
					UserName = getUser.UserName,
					Email = getUser.Email,
					Address = getUser.Address,
					PhoneNumber = getUser.PhoneNumber
				};

				return View(registerVM);
			}
			TempData["Error"] = "Kullanıcı Hatası!";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
		{

			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					Id = userRegisterVM.ID,
					UserName = userRegisterVM.UserName,
					Email = userRegisterVM.Email,
					PhoneNumber = userRegisterVM.PhoneNumber,
					Address = userRegisterVM.Address
				};

				//todo:Şifre değiştirme ve güncelleme işlemleri yapılacak.

			}
			return View();
		}

		public IActionResult AccessDenied()
		{
			return RedirectToAction("Index", "Home");
		}
	}
}
