using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
	public interface IShippingAddressRepository:IRepository<ShippingAddress>
	{
		Task<IEnumerable<ShippingAddress>> GetByUserIdAddressList(int id);
		Task<ShippingAddress> GetByUserIdAndAddressId(int userId, int addressId);
	}
}
