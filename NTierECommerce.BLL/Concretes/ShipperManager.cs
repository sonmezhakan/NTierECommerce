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
    public class ShipperManager : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperManager(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }
        public async Task<string> Create(Shipper entity)
        {
            return await _shipperRepository.Create(entity);
        }

        public async Task<string> Delete(Shipper entity)
        {
            return await _shipperRepository.Delete(entity);
        }

        public async Task<string> DestroyAllData(List<Shipper> entity)
        {
            return await _shipperRepository.DestroyAllData(entity);
        }

        public async Task<string> DestroyData(Shipper entity)
        {
            return await _shipperRepository.DestroyData(entity);
        }

        public async Task<IEnumerable<Shipper>> GetAll()
        {
            return await _shipperRepository.GetAll();
        }

        public async Task<IEnumerable<Shipper>> GetAllActive()
        {
            return await _shipperRepository.GetAllActive();
        }

        public async Task<IEnumerable<Shipper>> GetAllPassive()
        {
            return await _shipperRepository.GetAllPassive();
        }

        public async Task<Shipper> GetByCompanyName(string companyName)
        {
            var result = await _shipperRepository.GetAll();
            return result.FirstOrDefault(x=>x.CompanyName == companyName) ?? null;
        }

        public async Task<Shipper> GetById(int id)
        {
            return await _shipperRepository.GetById(id);
        }

        public async Task<string> IsActiveActive(Shipper entity)
        {
            return await _shipperRepository.IsActiveActive(entity);
        }

        public async Task<string> Update(Shipper entity)
        {
           return await _shipperRepository.Update(entity);
        }
    }
}
