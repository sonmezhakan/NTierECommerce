using NTierECommerce.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Entities.Entities
{
    public class Product:BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImagePath { get; set; }

        //todo: birden fazla görsel eklemek için "ProductImage" isimli bir class oluşturularak ilişkilendirme gerçekleştirilecek.


        //Mapping
        [Required]
        public  int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
