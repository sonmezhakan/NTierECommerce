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
    public class ProductManager:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<string> Create(Product product)
        {
            return await _productRepository.Create(product);
        }

        public async Task<string> Delete(Product product)
        {
            return await _productRepository.Delete(product);
        }

        public async Task<string> DestroyAllData(List<Product> product)
        {
            return await _productRepository.DestroyAllData(product);
        }

        public async Task<string> DestroyData(Product product)
        {
            return await _productRepository.DestroyData(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAllActive()
        {
            return await _productRepository.GetAllActive();
        }

		public async Task<IEnumerable<Product>> GetAllCategoryById(int categoryId)
		{
            var result = await _productRepository.GetAllActive();

            return result.Where(x=>x.CategoryId == categoryId);
		}

		public async Task<IEnumerable<Product>> GetAllPassive()
        {
            return await _productRepository.GetAllPassive();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

		public async Task<string> IsActiveActive(Product product)
        {
            return await _productRepository.IsActiveActive(product);
        }

        public async Task<string> Update(Product product)
        {
            return await _productRepository.Update(product);
        }

        public async Task<IEnumerable<Product>> GetRelatedProducts(int totalProduct)
        {
            var result = await _productRepository.GetAllActive();
            return result.OrderBy(x=> Guid.NewGuid()).Take(totalProduct).ToList();
        }
    }
}
