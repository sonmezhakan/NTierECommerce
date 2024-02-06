using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
	public interface IOrderService
	{
        public Task<string> Create(Order entity);

        public Task<string> Update(Order entity);

        public Task<string> Delete(Order entity);

        public Task<string> DestroyAllData(List<Order> entity);

        public Task<string> DestroyData(Order entity);

        public Task<IEnumerable<Order>> GetAll();

        public Task<IEnumerable<Order>> GetAllActive();

        public Task<IEnumerable<Order>> GetAllPassive();

        public Task<Order> GetById(int id);

        public Task<string> IsActiveActive(Order entity);

        Task<int> GetByOrderIdSearch(Order order);

		Task<IEnumerable<Order>> GetByUserId(int userId);

		Task<Order> GetByUserAndOrderId(int userId, int orderId);

		Task<int> GetAllCount();
		Task<int> GetMonthlyCount();
		
	}
}
