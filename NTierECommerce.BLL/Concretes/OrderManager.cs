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
	public class OrderManager : IOrderService
	{
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
           _orderRepository = orderRepository;
        }
        public async Task<string> Create(Order entity)
		{
			return await _orderRepository.Create(entity);
		}

		public async Task<string> Delete(Order entity)
		{
			return await _orderRepository.Delete(entity);
		}

		public async Task<string> DestroyAllData(List<Order> entity)
		{
			return await _orderRepository.DestroyAllData(entity);
		}

		public async Task<string> DestroyData(Order entity)
		{
			return await _orderRepository.DestroyData(entity);
		}

		public async Task<IEnumerable<Order>> GetAll()
		{
			return await _orderRepository.GetAll();
		}

		public async Task<IEnumerable<Order>> GetAllActive()
		{
			return await _orderRepository.GetAllActive();
		}

        public async Task<int> GetAllCount()
        {
			return _orderRepository.GetAll().Result.Count();
        }

        public async Task<IEnumerable<Order>> GetAllPassive()
		{
			return await _orderRepository.GetAllPassive();
		}

		public async Task<Order> GetById(int id)
		{
			var result = await _orderRepository.GetAll();
			return result.FirstOrDefault(x => x.OrderId == id);
		}

		public async Task<int> GetByOrderIdSearch(Order order)
		{
			var getOrderList =await _orderRepository.GetAll();
			return getOrderList.FirstOrDefault(x=>x.AppUserId == order.AppUserId && x.OrderDate == order.OrderDate && x.ShippingAddressId == order.ShippingAddressId).OrderId;
		}

        public async Task<Order> GetByUserAndOrderId(int userId, int orderId)
        {
			var result = await _orderRepository.GetAll();
			return result.FirstOrDefault(x=>x.AppUserId == userId && x.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetByUserId(int userId)
		{
			var orderList = await _orderRepository.GetAll();
			return orderList.Where(x=>x.AppUserId == userId);
		}

        public async Task<int> GetMonthlyCount()
        {
            var getList = await _orderRepository.GetAll();
			return getList.Where(x=>x.OrderDate.Year == DateTime.Now.Year && x.OrderDate.Month == DateTime.Now.Month).Count();
        }

        public Task<string> IsActiveActive(Order entity)
		{
			return _orderRepository.IsActiveActive(entity);
		}

		public Task<string> Update(Order entity)
		{
			return _orderRepository.Update(entity);
		}
	}
}
