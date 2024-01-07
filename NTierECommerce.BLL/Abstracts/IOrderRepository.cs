using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
	public interface IOrderRepository:IRepository<Order>
	{
		Task<int> GetByOrderIdSearch(Order order);

		Task<IEnumerable<Order>> GetByUserId(int userId);

		Task<Order> GetByUserAndOrderId(int userId, int orderId);
	}
}
