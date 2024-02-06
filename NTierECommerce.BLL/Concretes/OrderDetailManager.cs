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
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailManager(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public Task<string> Create(OrderDetail entity)
        {
            return _orderDetailRepository.Create(entity);
        }

        public Task<string> Delete(OrderDetail entity)
        {
            return _orderDetailRepository.Delete(entity);
        }

        public Task<string> DestroyAllData(List<OrderDetail> entity)
        {
            return _orderDetailRepository.DestroyAllData(entity);
        }

        public Task<string> DestroyData(OrderDetail entity)
        {
            return _orderDetailRepository.DestroyData(entity);
        }

        public async Task<IEnumerable<OrderDetail>> GetAll()
        {
            return await _orderDetailRepository.GetAll();
        }

        public async Task<IEnumerable<OrderDetail>> GetAllActive()
        {
            return await _orderDetailRepository.GetAllActive();
        }

        public async Task<IEnumerable<OrderDetail>> GetAllPassive()
        {
            return await _orderDetailRepository.GetAllPassive();
        }

        public Task<OrderDetail> GetById(int id)
        {
            return _orderDetailRepository.GetById(id);
        }

        public async Task<IEnumerable<OrderDetail>> GetByIdList(int orderId)
        {
            var orderList = await _orderDetailRepository.GetAll();
            return orderList.Where(x => x.OrderId == orderId);
        }

        public async Task<decimal> GetByOrderIDTotalPrice(int orderId)
        {
            var getOrderList = _orderDetailRepository.GetAll().Result;
            var getOrder = getOrderList.Where(x=>x.OrderId == orderId);

            decimal totalPrice = 0;

            foreach (var item in getOrder)
            {
                totalPrice += item.Quantity + item.UnitPrice;
            }

            return totalPrice;
        }

        public async Task<decimal> GetTotalEarning()
        {
            var getList = await _orderDetailRepository.GetAll();

            decimal totalEarning = 0;
            foreach (var item in getList)
            {
                totalEarning += item.Quantity * item.UnitPrice;
            }

            return totalEarning;
        }

        public Task<string> IsActiveActive(OrderDetail entity)
        {
            return _orderDetailRepository.IsActiveActive(entity);
        }

        public Task<string> Update(OrderDetail entity)
        {
            return _orderDetailRepository.Update(entity);
        }
    }
}
