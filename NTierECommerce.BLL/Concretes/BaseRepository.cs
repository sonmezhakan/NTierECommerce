using Microsoft.EntityFrameworkCore;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Common;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace NTierECommerce.BLL.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ECommerceContext _context;
        private DbSet<T> _entities;

        public BaseRepository(ECommerceContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<string> Create(T entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedComputerName = Environment.MachineName;
                entity.CreatedIpAddress = IPAddressFinder.GetHostName();

                await _entities.AddAsync(entity);
                _context.SaveChanges();

                return "Kayıt başarılı!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> Delete(T entity)
        {
            try
            {
                var original = await _entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

                original.Status = Entities.Enums.DataStatus.Deleted;
				original.UpdatedDate = DateTime.Now;
				original.UpdatedIpAddress = IPAddressFinder.GetHostName();
				original.UpdatedComputerName = Environment.MachineName;

				original.IsActive = false;
                _context.Entry(original).CurrentValues.SetValues(entity);

                _context.SaveChanges();

                return "Pasife çekildi!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> DestroyAllData(List<T> entity)
        {
            try
            {
                _entities.RemoveRange(entity);
                _context.SaveChanges();

                return "Silme İşlemi Başarılı!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DestroyData(T entity)
        {
            try
            {
                _entities.Remove(entity);
                _context.SaveChanges();

                return "Silme İşlemi Başarılı!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllActive()
        {
            var result = await _entities.ToListAsync();
            return result.Where(x => x.IsActive == true);

        }

        public async Task<IEnumerable<T>> GetAllPassive()
        {
            var result = await _entities.ToListAsync();
            return result.Where(x => x.IsActive == false);
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> IsActiveActive(T entity)
        {
            try
            {
                var original = await _entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

				original.Status = Entities.Enums.DataStatus.Updated;
				original.UpdatedDate = DateTime.Now;
				original.UpdatedIpAddress = IPAddressFinder.GetHostName();
				original.UpdatedComputerName = Environment.MachineName;
				original.IsActive = true;
                _context.Entry(original).CurrentValues.SetValues(entity);

                _context.SaveChanges();

                return "Pasife çekildi!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> Update(T entity)//Adidas
        {
            try
            {
                var updated = await _entities.FirstOrDefaultAsync(x => x.Id == entity.Id);


                updated.Status = Entities.Enums.DataStatus.Updated;
                updated.UpdatedDate = DateTime.Now;
                updated.UpdatedIpAddress = IPAddressFinder.GetHostName();
                updated.UpdatedComputerName = Environment.MachineName;

                _context.Entry(updated).CurrentValues.SetValues(entity);

                //_context.Entry(entity).State = EntityState.Modified;

                _context.SaveChanges();

                return "Güncelleme Başarılı!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
