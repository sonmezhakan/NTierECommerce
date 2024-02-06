using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
	public interface IShippingAddressService
	{
        public Task<string> Create(ShippingAddress entity);

        public Task<string> Update(ShippingAddress entity);

        public Task<string> Delete(ShippingAddress entity);

        public Task<string> DestroyAllData(List<ShippingAddress> entity);

        public Task<string> DestroyData(ShippingAddress entity);

        public Task<IEnumerable<ShippingAddress>> GetAll();

        public Task<IEnumerable<ShippingAddress>> GetAllActive();

        public Task<IEnumerable<ShippingAddress>> GetAllPassive();

        public Task<ShippingAddress> GetById(int id);

        public Task<string> IsActiveActive(ShippingAddress entity);

        Task<IEnumerable<ShippingAddress>> GetByUserIdAddressList(int id);
		Task<ShippingAddress> GetByUserIdAndAddressId(int userId, int addressId);
	}
}
