using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
	public class ShippingAddressRepository : IShippingAddressRepository
	{
		private readonly IRepository<ShippingAddress> _repository;

		public ShippingAddressRepository(IRepository<ShippingAddress> repository)
        {
			_repository = repository;
		}
        public async Task<string> Create(ShippingAddress entity)
		{
			return await _repository.Create(entity);
		}

		public async Task<string> Delete(ShippingAddress entity)
		{
			return await _repository.Delete(entity);
		}

		public async Task<string> DestroyAllData(List<ShippingAddress> entity)
		{
			return await _repository.DestroyAllData(entity);
		}

		public async Task<string> DestroyData(ShippingAddress entity)
		{
			return await _repository.DestroyData(entity);
		}

		public async Task<IEnumerable<ShippingAddress>> GetAll()
		{
			return await _repository.GetAll();
		}

		public async Task<IEnumerable<ShippingAddress>> GetAllActive()
		{
			return await _repository.GetAllActive();
		}

		public async Task<IEnumerable<ShippingAddress>> GetAllPassive()
		{
			return await _repository.GetAllPassive();
		}

		public async Task<ShippingAddress> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task<IEnumerable<ShippingAddress>> GetByUserIdAddressList(int id)
		{
            var result = await _repository.GetAllActive();
            if (result != null)
			{
                return result.Where(x => x.AppUserId == id);
            }
			return null;
			
		}

        public async Task<ShippingAddress> GetByUserIdAndAddressId(int userId, int addressId)
        {
			var result = await _repository.GetAllActive();
			if (result != null)
			{
				return result.FirstOrDefault(x => x.AppUserId == userId && x.Id == addressId);
			}
			return null;
        }

        public async Task<string> IsActiveActive(ShippingAddress entity)
		{
			return await _repository.IsActiveActive(entity);
		}

		public async Task<string> Update(ShippingAddress entity)
		{
			return await _repository.Update(entity);
		}
	}
}
