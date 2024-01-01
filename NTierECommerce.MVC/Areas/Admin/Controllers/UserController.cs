using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRole> _roleManager;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppUserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var getRoles = _roleManager.Roles.Select(x => new AppUserRole
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            

            var userList = _userManager.Users.Select(x => new AppUser
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address
            }).ToList();

            List<UserListVM> list = new List<UserListVM>();

            foreach (var item in userList)
            {
                var getMyRoles = await _userManager.GetRolesAsync(item);

                UserListVM userListVM = new UserListVM();
                userListVM.ID = item.Id;
                userListVM.UserName = item.UserName;
                userListVM.Email = item.Email;
                userListVM.PhoneNumber = item.PhoneNumber;
                userListVM.Address = item.Address;
                userListVM.MyRoles = getMyRoles.ToList();
                userListVM.Roles = getRoles;

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
                AppUser appUser = new AppUser()
                {
                    UserName = userRegisterVM.UserName,
                    Email = userRegisterVM.Email,
                    PhoneNumber = userRegisterVM.PhoneNumber,
                    Address = userRegisterVM.Address
                };

                await _userManager.CreateAsync(appUser,userRegisterVM.Password);
                return RedirectToAction("Index", "User");
            }

            return View();  
        }

        public async Task<IActionResult> Details(int id)
        {
            var getUser = await GetAppUser(id);
            if(getUser != null)
            {
                UserRegisterVM userRegisterVM = new UserRegisterVM()
                {
                    ID = getUser.Id,
                    UserName = getUser.UserName,
                    Email = getUser.Email,
                    PhoneNumber = getUser.PhoneNumber,
                    Address = getUser.Address
                };

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
                UserRegisterVM userRegisterVM = new UserRegisterVM()
                {
                    ID = getUser.Id,
                    UserName = getUser.UserName,
                    Email = getUser.Email,
                    PhoneNumber = getUser.PhoneNumber,
                    Address = getUser.Address
                };

                return View(userRegisterVM);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserRegisterVM userRegisterVM)
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

        public async Task<IActionResult> Delete(int id)
        {
            await _userManager.DeleteAsync(await GetAppUser(id));
            return RedirectToAction("Index","User");
        }

        public async Task<IActionResult> RoleUpdate(int userid, int roleid)
        {
            var getAppUserRole = await GetAppUserRole(roleid);
            await _userManager.AddToRoleAsync(await GetAppUser(userid), getAppUserRole.Name);
            return RedirectToAction("Index","User");
        }

        public async Task<AppUser> GetAppUser(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<AppUserRole> GetAppUserRole(int id)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(x=>x.Id == id);
        }


    }
}
