using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using System.Data;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class UserRoleController : Controller
    {
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly IMapper _mapper;

        public UserRoleController(RoleManager<AppUserRole> roleManager,IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var roleList = await _roleManager.Roles.ToListAsync();

            List<AppUserRoleListVM> list = _mapper.Map<List<AppUserRoleListVM>>(roleList);

            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUserRoleVM appUserRoleVM)
        {
            if(ModelState.IsValid)
            {
                AppUserRole appUserRole = _mapper.Map<AppUserRole>(appUserRoleVM);

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
                AppUserRoleVM appUserRoleVM = _mapper.Map<AppUserRoleVM>(getAppUserRole);
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
                AppUserRoleVM appUserRoleVM = _mapper.Map<AppUserRoleVM>(getAppUserRole);

                return View(appUserRoleVM);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserRoleVM appUserRoleVM)
        {
            //todo: bir kere güncelleme işlemi yapılınca otomatik olarak veritabanındaki ConcurrencyStamp propertysini dolduruyor. Bu yüzden 2.sefer güncelleme işlemi yapılamıyorEv
            if(ModelState.IsValid)
            {
                AppUserRole appUserRole = _mapper.Map<AppUserRole>(appUserRoleVM);

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
