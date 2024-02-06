using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
    public interface IProductService
    {
        public Task<string> Create(Product entity);

        public Task<string> Update(Product entity);

        public Task<string> Delete(Product entity);

        public Task<string> DestroyAllData(List<Product> entity);

        public Task<string> DestroyData(Product entity);

        public Task<IEnumerable<Product>> GetAll();

        public Task<IEnumerable<Product>> GetAllActive();

        public Task<IEnumerable<Product>> GetAllPassive();

        public Task<Product> GetById(int id);

        public Task<string> IsActiveActive(Product entity);

        Task<IEnumerable<Product>> GetAllCategoryById(int categoryId);
		Task<IEnumerable<Product>> GetRelatedProducts(int totalProduct);

	}
}
