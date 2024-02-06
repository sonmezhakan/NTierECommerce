using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
	public interface IOrderDetailService
	{
        public Task<string> Create(OrderDetail entity);

        public Task<string> Update(OrderDetail entity);

        public Task<string> Delete(OrderDetail entity);

        public Task<string> DestroyAllData(List<OrderDetail> entity);

        public Task<string> DestroyData(OrderDetail entity);

        public Task<IEnumerable<OrderDetail>> GetAll();

        public Task<IEnumerable<OrderDetail>> GetAllActive();

        public Task<IEnumerable<OrderDetail>> GetAllPassive();

        public Task<OrderDetail> GetById(int id);

        public Task<string> IsActiveActive(OrderDetail entity);

        Task<IEnumerable<OrderDetail>> GetByIdList(int orderId);

		Task<decimal> GetTotalEarning();
		Task<decimal> GetByOrderIDTotalPrice(int orderId);
	}
}
