using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels;
using NTierECommerce.MVC.Models.ViewModels.Category;
using System.Data;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var getCategoryList = await _categoryRepository.GetAll();
            var categoryList = getCategoryList.Select(x => new Category
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description,
                IsActive = x.IsActive
            });

            List<CategoryListVM> list = _mapper.Map<List<CategoryListVM>>(categoryList);


            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryVM categoryVM)
        {
            if(ModelState.IsValid)
            {
                Category category = _mapper.Map<Category>(categoryVM);

                await _categoryRepository.Create(category);
                return RedirectToAction("Index", "Category");
            }
            TempData["Error"] = "Kategori Eklenemedi!";
            return View(categoryVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var getCategory = await GetCategory(id);
            if (getCategory != null)
            {
                CategoryVM categoryVM = _mapper.Map<CategoryVM>(getCategory);
                return View(categoryVM);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
			var getCategory = await GetCategory(id);
			if (getCategory != null)
			{
                CategoryVM categoryVM = _mapper.Map<CategoryVM>(getCategory);
				return View(categoryVM);
			}
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryVM categoryVM)
        {
            if(ModelState.IsValid)
            {
                Category category = _mapper.Map<Category>(categoryVM);
                await _categoryRepository.Update(category);
            }
            return View(categoryVM);
        }

        public async Task<IActionResult> IsActivePassive(int id)
        {
            await _categoryRepository.Delete(await GetCategory(id));

            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> IsActiveActive(int id)
        {
            await _categoryRepository.IsActiveActive(await GetCategory(id));

            return RedirectToAction("Index", "Category");
        }


        public async Task<IActionResult> Destroy(int id)
        {
           await _categoryRepository.DestroyData(await GetCategory(id));

            return RedirectToAction("Index", "Category");
        }

        //Sürekli Olarak GetById metotu kullanılıyordu. Kod tekrarını azaltmak için aşağıdaki metot oluşturulmuştur.
        public async Task<Category> GetCategory(int id)
        {
            return await _categoryRepository.GetById(id);
        }
    }
    
    
}
