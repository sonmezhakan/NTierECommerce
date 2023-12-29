using Microsoft.AspNetCore.Mvc;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.MVC.Areas.Admin.Models.ViewModels;

namespace NTierECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categoryList = _categoryRepository.GetAll().Select(x => new Category
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description,
                IsActive = x.IsActive
            });

            List<CategoryListVM> list = new List<CategoryListVM>();


            foreach (var item in categoryList)
            {
                CategoryListVM categoryListVM = new CategoryListVM();
                categoryListVM.ID = item.Id;
                categoryListVM.CategoryName = item.CategoryName;
                categoryListVM.Description = item.Description;
                categoryListVM.IsActive = item.IsActive;

                list.Add(categoryListVM);
            }

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
                Category category = new Category() { 
                CategoryName = categoryVM.CategoryName,
                Description = categoryVM.Description,
                IsActive = categoryVM.IsActive
                };

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
                CategoryVM categoryVM = new CategoryVM()
                {
                    ID = getCategory.Id,
                    CategoryName = getCategory.CategoryName,
                    Description = getCategory.Description,
                    IsActive = getCategory.IsActive
                };
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
				CategoryVM categoryVM = new CategoryVM()
				{
					ID = getCategory.Id,
					CategoryName = getCategory.CategoryName,
					Description = getCategory.Description,
					IsActive = getCategory.IsActive
				};
				return View(categoryVM);
			}
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryVM categoryVM)
        {
            if(ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Id = categoryVM.ID,
                    CategoryName = categoryVM.CategoryName,
                    Description = categoryVM.Description,
                    IsActive = categoryVM.IsActive,
                };
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
