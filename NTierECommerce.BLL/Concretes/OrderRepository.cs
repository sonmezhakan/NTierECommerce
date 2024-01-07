using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
	public class OrderRepository : IOrderRepository
	{
		private readonly IRepository<Order> _repository;

		public OrderRepository(IRepository<Order> repository)
        {
			_repository = repository;
		}
        public async Task<string> Create(Order entity)
		{
			return await _repository.Create(entity);
		}

		public async Task<string> Delete(Order entity)
		{
			return await _repository.Delete(entity);
		}

		public async Task<string> DestroyAllData(List<Order> entity)
		{
			return await _repository.DestroyAllData(entity);
		}

		public async Task<string> DestroyData(Order entity)
		{
			return await _repository.DestroyData(entity);
		}

		public async Task<IEnumerable<Order>> GetAll()
		{
			return await _repository.GetAll();
		}

		public async Task<IEnumerable<Order>> GetAllActive()
		{
			return await _repository.GetAllActive();
		}

		public async Task<IEnumerable<Order>> GetAllPassive()
		{
			return await _repository.GetAllPassive();
		}

		public async Task<Order> GetById(int id)
		{
			var result = await _repository.GetAll();
			return result.FirstOrDefault(x => x.OrderId == id);
		}

		public async Task<int> GetByOrderIdSearch(Order order)
		{
			var getOrderList =await _repository.GetAll();
			return getOrderList.FirstOrDefault(x=>x.AppUserId == order.AppUserId && x.OrderDate == order.OrderDate && x.ShippingAddressId == order.ShippingAddressId).OrderId;
		}

        public async Task<Order> GetByUserAndOrderId(int userId, int orderId)
        {
			var result = await _repository.GetAll();
			return result.FirstOrDefault(x=>x.AppUserId == userId && x.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetByUserId(int userId)
		{
			var orderList = await _repository.GetAll();
			return orderList.Where(x=>x.AppUserId == userId);
		}

		public Task<string> IsActiveActive(Order entity)
		{
			return _repository.IsActiveActive(entity);
		}

		public Task<string> Update(Order entity)
		{
			return _repository.Update(entity);
		}
	}
}
