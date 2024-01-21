using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly IRepository<Shipper> _repository;

        public ShipperRepository(IRepository<Shipper> repository)
        {
            _repository = repository;
        }
        public async Task<string> Create(Shipper entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<string> Delete(Shipper entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<string> DestroyAllData(List<Shipper> entity)
        {
            return await _repository.DestroyAllData(entity);
        }

        public async Task<string> DestroyData(Shipper entity)
        {
            return await _repository.DestroyData(entity);
        }

        public async Task<IEnumerable<Shipper>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Shipper>> GetAllActive()
        {
            return await _repository.GetAllActive();
        }

        public async Task<IEnumerable<Shipper>> GetAllPassive()
        {
            return await _repository.GetAllPassive();
        }

        public async Task<Shipper> GetByCompanyName(string companyName)
        {
            var result = await _repository.GetAll();
            return result.FirstOrDefault(x=>x.CompanyName == companyName) ?? null;
        }

        public async Task<Shipper> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<string> IsActiveActive(Shipper entity)
        {
            return await _repository.IsActiveActive(entity);
        }

        public async Task<string> Update(Shipper entity)
        {
           return await _repository.Update(entity);
        }
    }
}
