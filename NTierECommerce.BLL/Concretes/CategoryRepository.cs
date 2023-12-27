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

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Category> GetAllActive()
        {
            return _repository.GetAllActive();
        }

        public IEnumerable<Category> GetAllPassive()
        {
            return _repository.GetAllPassive();
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
