using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
	public interface IOrderDetailRepository:IRepository<OrderDetail>
	{
		Task<IEnumerable<OrderDetail>> GetByIdList(int orderId);
	}
}
