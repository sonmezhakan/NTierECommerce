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
    public class ProductRepository:IProductRepository
    {
        private readonly IRepository<Product> _repository;

        public ProductRepository(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<string> Create(Product product)
        {
            return await _repository.Create(product);
        }

        public async Task<string> Delete(Product product)
        {
            return await _repository.Delete(product);
        }

        public async Task<string> DestroyAllData(List<Product> product)
        {
            return await _repository.DestroyAllData(product);
        }

        public async Task<string> DestroyData(Product product)
        {
            return await _repository.DestroyData(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAllActive()
        {
            return await _repository.GetAllActive();
        }

		public async Task<IEnumerable<Product>> GetAllCategoryById(int categoryId)
		{
            var result = await _repository.GetAllActive();

            return result.Where(x=>x.CategoryId == categoryId);
		}

		public async Task<IEnumerable<Product>> GetAllPassive()
        {
            return await _repository.GetAllPassive();
        }

        public async Task<Product> GetById(int id)
        {
            return await _repository.GetById(id);
        }

		public async Task<string> IsActiveActive(Product product)
        {
            return await _repository.IsActiveActive(product);
        }

        public async Task<string> Update(Product product)
        {
            return await _repository.Update(product);
        }

        public async Task<IEnumerable<Product>> GetRelatedProducts(int totalProduct)
        {
            var result = await _repository.GetAllActive();
            return result.OrderBy(x=> Guid.NewGuid()).Take(totalProduct).ToList();
        }
    }
}
