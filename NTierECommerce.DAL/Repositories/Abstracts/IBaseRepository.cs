using NTierECommerce.Entities.Base;
using NTierECommerce.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.DAL.Repositories.Abstracts
{
    public interface IBaseRepository<T> where T : class,IEntity<Guid>
    {
        //List
        Task<IEnumerable<T>> GetAll(); //Ienumerable bir koleksiyon içinde farklı bir koleksiyonu teslim alı ve içerde kalan koleksiyonun değerlerini döngüye ihtiyaç duymadan teslim eder.

        //List Active
        Task<IEnumerable<T>> GetAllActive();

        //List Passive
        Task<IEnumerable<T>> GetAllPassive();

        //Destroy: Veritabanında veriyi doğrudan siler.
        Task<string> DestroyData(T entity);

        Task<string> DestroyAllData(List<T> entity);

        //Create
        Task<string> Create(T entity);

        //Read
        Task<T> GetById(int id);

        //Update
        Task<string> Update(T entity);

        //Delete: Veri silinmeyecek, verinin durumu "Deleted" olarak güncellenecek.
        Task<string> Delete(T entity);

        //IsActiveActive: Pasif yapılan nesneyi tekrardan aktifleştirme
        Task<string> IsActiveActive(T entity);
    }
}
