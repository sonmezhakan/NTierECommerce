using Microsoft.EntityFrameworkCore;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<T> GetAllActive()
        {
            //return _entities.AsEnumerable();
            return _entities.Where(x => x.IsActive == true).ToList();

        }

        public IEnumerable<T> GetAllPassive()
        {
            return _entities.Where(x => x.IsActive == false).ToList();
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
                updated.UpdatedIpAddress = "update";
                updated.UpdatedComputerName = "update";

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
