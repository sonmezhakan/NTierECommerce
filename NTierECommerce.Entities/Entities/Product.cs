using NTierECommerce.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Entities.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public string ImagePath { get; set; }

        //todo: birden fazla görsel eklemek için "ProductImage" isimli bir class oluşturularak ilişkilendirme gerçekleştirilecek.

        

        //Mapping
        public  int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
