﻿using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
    public interface IProductRepository:IRepository<Product>
    {
		Task<IEnumerable<Product>> GetAllCategoryById(int categoryId);
		Task<IEnumerable<Product>> GetRelatedProducts(int totalProduct);

	}
}
