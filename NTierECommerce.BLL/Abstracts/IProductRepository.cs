using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
    public interface IProductRepository:IRepository<Product>
    {
		IEnumerable<Product> GetAllCategoryById(int categoryId);
		IEnumerable<Product> GetRelatedProducts(int totalProduct);

	}
}
