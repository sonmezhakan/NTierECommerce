using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
	public class OrderDetailRepository : IOrderDetailRepository
	{
		private readonly IRepository<OrderDetail> _repository;

		public OrderDetailRepository(IRepository<OrderDetail> repository)
        {
			_repository = repository;
		}
        public Task<string> Create(OrderDetail entity)
		{
			return _repository.Create(entity);
		}

		public Task<string> Delete(OrderDetail entity)
		{
			return _repository.Delete(entity);
		}

		public Task<string> DestroyAllData(List<OrderDetail> entity)
		{
			return _repository.DestroyAllData(entity);
		}

		public Task<string> DestroyData(OrderDetail entity)
		{
			return _repository.DestroyData(entity);
		}

		public  async Task<IEnumerable<OrderDetail>> GetAll()
		{
			return await _repository.GetAll();
		}

		public async Task<IEnumerable<OrderDetail>> GetAllActive()
		{
			return await _repository.GetAllActive();
		}

		public async Task<IEnumerable<OrderDetail>> GetAllPassive()
		{
			return await _repository.GetAllPassive();
		}

		public Task<OrderDetail> GetById(int id)
		{
			return _repository.GetById(id);
		}

        public async Task<IEnumerable<OrderDetail>> GetByIdList(int orderId)
        {
			var orderList = await _repository.GetAll();
			return orderList.Where(x=>x.OrderId == orderId);
        }

        public Task<string> IsActiveActive(OrderDetail entity)
		{
			return _repository.IsActiveActive(entity);
		}

		public Task<string> Update(OrderDetail entity)
		{
			return _repository.Update(entity);
		}
	}
}
