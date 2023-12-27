using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private readonly RoleManager<AppUserRole> _roleManager;

        public UserRoleController(RoleManager<AppUserRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roleList = await _roleManager.Roles.Select(x => new AppUserRole
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();

            List<AppUserRoleListVM> list = new List<AppUserRoleListVM>();

            foreach (var role in roleList) 
            {
                AppUserRoleListVM appUserRoleVM = new AppUserRoleListVM();
                appUserRoleVM.ID = role.Id;
                appUserRoleVM.Name = role.Name;
                appUserRoleVM.Description = role.Description;

                list.Add(appUserRoleVM);
            }

            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUserRoleListVM appUserRoleVM)
        {
            if(ModelState.IsValid)
            {
                AppUserRole appUserRole = new AppUserRole()
                {
                    Id = appUserRoleVM.ID,
                    Name = appUserRoleVM.Name,
                    Description = appUserRoleVM.Description
                };

                await _roleManager.CreateAsync(appUserRole);
                return RedirectToAction("Index", "UserRole");
            }
            return View(appUserRoleVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var getAppUserRole = await GetAppUserRole(id);
            if (getAppUserRole != null)
            {
                AppUserRoleVM appUserRoleVM = new AppUserRoleVM()
                {
                    ID = getAppUserRole.Id,
                    Name = getAppUserRole.Name,
                    Description = getAppUserRole.Description
                };
                return View(appUserRoleVM);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _roleManager.DeleteAsync(await GetAppUserRole(id));
            return RedirectToAction("Index", "UserRole");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var getAppUserRole = await GetAppUserRole(id);
            if (getAppUserRole != null)
            {
                AppUserRoleVM appUserRoleVM = new AppUserRoleVM()
                {
                    ID = getAppUserRole.Id,
                    Name = getAppUserRole.Name,
                    Description = getAppUserRole.Description
                };

                return View(appUserRoleVM);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserRoleVM appUserRoleVM)
        {
            //todo: bir kere güncelleme işlemi yapılınca otomatik olarak veritabanındaki ConcurrencyStamp propertysini dolduruyor. Bu yüzden 2.sefer güncelleme işlemi yapılamıyor
            if(ModelState.IsValid)
            {
                AppUserRole appUserRole = new AppUserRole()
                {
                    Id = appUserRoleVM.ID,
                    Name = appUserRoleVM.Name,
                    Description = appUserRoleVM.Description
                };

                await _roleManager.UpdateAsync(appUserRole);
                return RedirectToAction("Index", "UserRole");
            }
            return View(appUserRoleVM);
        }


        public async Task<AppUserRole> GetAppUserRole(int id)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
