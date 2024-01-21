using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels;
using System.Data;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUserRole> appUserRoles = _roleManager.Roles.Select(x => new AppUserRole
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();


            List<AppUser> appUsers = _userManager.Users.Select(x => new AppUser
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address
            }).ToList();

            List<UserListVM> list = new List<UserListVM>();

            foreach (var item in appUsers)
            {
                var getMyRoles = await _userManager.GetRolesAsync(item);

                UserListVM userListVM = new UserListVM();
                userListVM.ID = item.Id;
                userListVM.UserName = item.UserName;
                userListVM.Email = item.Email;
                userListVM.PhoneNumber = item.PhoneNumber;
                userListVM.Address = item.Address;
                userListVM.MyRoles = getMyRoles.ToList();
                userListVM.Roles = appUserRoles;

                list.Add(userListVM);
            }

            return View(list);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = _mapper.Map<AppUser>(userRegisterVM);

                await _userManager.CreateAsync(appUser, userRegisterVM.Password);
                return RedirectToAction("Index", "User");
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var getUser = await GetAppUser(id);
            if (getUser != null)
            {
                UserRegisterVM userRegisterVM = _mapper.Map<UserRegisterVM>(getUser);

                return View(userRegisterVM);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var getUser = await GetAppUser(id);
            if (getUser != null)
            {
                UserRegisterVM userRegisterVM = _mapper.Map<UserRegisterVM>(getUser);

                return View(userRegisterVM);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateVM userUpdateVM)
        {
            if (ModelState.IsValid)
            {
                var getAppUser = await _userManager.FindByIdAsync(userUpdateVM.ID.ToString());
                if (getAppUser == null) return View();

                getAppUser.Address = userUpdateVM.Address;

                 await _userManager.UpdateAsync(getAppUser);
                //todo:Şifre değiştirme ve güncelleme işlemleri yapılacak.

            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _userManager.DeleteAsync(await GetAppUser(id));
            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> RoleUpdate(int userid, int roleid)
        {
            var getAppUserRole = await GetAppUserRole(roleid);
            await _userManager.AddToRoleAsync(await GetAppUser(userid), getAppUserRole.Name);
            return RedirectToAction("Index", "User");
        }

        public async Task<AppUser> GetAppUser(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<AppUserRole> GetAppUserRole(int id)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}
