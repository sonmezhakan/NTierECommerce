using NTierECommerce.BLL.Abstracts;
using NTierECommerce.DAL.Repositories.Abstracts;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
	public class ShippingAddressManager : IShippingAddressService
	{
        private readonly IShippingAddressRepository _shippingAddressRepository;

        public ShippingAddressManager(IShippingAddressRepository shippingAddressRepository)
        {
            _shippingAddressRepository = shippingAddressRepository;
        }
        public async Task<string> Create(ShippingAddress entity)
		{
			return await _shippingAddressRepository.Create(entity);
		}

		public async Task<string> Delete(ShippingAddress entity)
		{
			return await _shippingAddressRepository.Delete(entity);
		}

		public async Task<string> DestroyAllData(List<ShippingAddress> entity)
		{
			return await _shippingAddressRepository.DestroyAllData(entity);
		}

		public async Task<string> DestroyData(ShippingAddress entity)
		{
			return await _shippingAddressRepository.DestroyData(entity);
		}

		public async Task<IEnumerable<ShippingAddress>> GetAll()
		{
			return await _shippingAddressRepository.GetAll();
		}

		public async Task<IEnumerable<ShippingAddress>> GetAllActive()
		{
			return await _shippingAddressRepository.GetAllActive();
		}

		public async Task<IEnumerable<ShippingAddress>> GetAllPassive()
		{
			return await _shippingAddressRepository.GetAllPassive();
		}

		public async Task<ShippingAddress> GetById(int id)
		{
			return await _shippingAddressRepository.GetById(id);
		}

		public async Task<IEnumerable<ShippingAddress>> GetByUserIdAddressList(int id)
		{
            var result = await _shippingAddressRepository.GetAllActive();
            if (result != null)
			{
                return result.Where(x => x.AppUserId == id);
            }
			return null;
			
		}

        public async Task<ShippingAddress> GetByUserIdAndAddressId(int userId, int addressId)
        {
			var result = await _shippingAddressRepository.GetAllActive();
			if (result != null)
			{
				return result.FirstOrDefault(x => x.AppUserId == userId && x.Id == addressId);
			}
			return null;
        }

        public async Task<string> IsActiveActive(ShippingAddress entity)
		{
			return await _shippingAddressRepository.IsActiveActive(entity);
		}

		public async Task<string> Update(ShippingAddress entity)
		{
			return await _shippingAddressRepository.Update(entity);
		}
	}
}
