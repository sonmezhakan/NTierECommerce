using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
    public interface IShipperService
    {
        public Task<string> Create(Shipper entity);

        public Task<string> Update(Shipper entity);

        public Task<string> Delete(Shipper entity);

        public Task<string> DestroyAllData(List<Shipper> entity);

        public Task<string> DestroyData(Shipper entity);

        public Task<IEnumerable<Shipper>> GetAll();

        public Task<IEnumerable<Shipper>> GetAllActive();

        public Task<IEnumerable<Shipper>> GetAllPassive();

        public Task<Shipper> GetById(int id);

        public Task<string> IsActiveActive(Shipper entity);

        Task<Shipper> GetByCompanyName(string companyName);
    }
}
