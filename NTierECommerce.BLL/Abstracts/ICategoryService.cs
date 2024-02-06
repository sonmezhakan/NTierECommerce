using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
    public interface ICategoryService
    {
        public Task<string> Create(Category entity);

        public Task<string> Update(Category entity);

        public Task<string> Delete(Category entity);

        public Task<string> DestroyAllData(List<Category> entity);

        public Task<string> DestroyData(Category entity);

        public Task<IEnumerable<Category>> GetAll();

        public Task<IEnumerable<Category>> GetAllActive();

        public Task<IEnumerable<Category>> GetAllPassive();

        public Task<Category> GetById(int id);

        public Task<string> IsActiveActive(Category entity);

        Task<bool> GetByActive(int id);
	}
}
