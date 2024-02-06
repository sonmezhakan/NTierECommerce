using Microsoft.EntityFrameworkCore;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.DAL.Context;
using NTierECommerce.DAL.Repositories.Abstracts;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<string> Create(Category category)
        {
            return await _categoryRepository.Create(category);
        }

        public async Task<string> Delete(Category category)
        {
            return await _categoryRepository.Delete(category);
        }

        public async Task<string> DestroyAllData(List<Category> category)
        {
            return await _categoryRepository.DestroyAllData(category);
        }

        public async Task<string> DestroyData(Category category)
        {
            return await _categoryRepository.DestroyData(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<IEnumerable<Category>> GetAllActive()
        {
            return await _categoryRepository.GetAllActive();
        }

        public async Task<IEnumerable<Category>> GetAllPassive()
        {
            return await _categoryRepository.GetAllPassive();
        }

		public async Task<bool> GetByActive(int id)
		{
            var result = await _categoryRepository.GetAll();

            return result.Any(x => x.Id == id && x.IsActive == true);
		}

		public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<string> IsActiveActive(Category category)
        {
            return await _categoryRepository.IsActiveActive(category);
        }

        public async Task<string> Update(Category category)
        {
            return await _categoryRepository.Update(category);
        }
    }
}
