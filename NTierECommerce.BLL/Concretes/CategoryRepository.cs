using Microsoft.EntityFrameworkCore;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Category> _repository;

        public CategoryRepository(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<string> Create(Category category)
        {
            return await _repository.Create(category);
        }

        public async Task<string> Delete(Category category)
        {
            return await _repository.Delete(category);
        }

        public async Task<string> DestroyAllData(List<Category> category)
        {
            return await _repository.DestroyAllData(category);
        }

        public async Task<string> DestroyData(Category category)
        {
            return await _repository.DestroyData(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Category>> GetAllActive()
        {
            return await _repository.GetAllActive();
        }

        public async Task<IEnumerable<Category>> GetAllPassive()
        {
            return await _repository.GetAllPassive();
        }

		public async Task<bool> GetByActive(int id)
		{
            var result = await _repository.GetAll();

            return result.Any(x => x.Id == id && x.IsActive == true);
		}

		public async Task<Category> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<string> IsActiveActive(Category category)
        {
            return await _repository.IsActiveActive(category);
        }

        public async Task<string> Update(Category category)
        {
            return await _repository.Update(category);
        }
    }
}
