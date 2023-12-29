using NTierECommerce.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.Entities.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        //Mapping
        public virtual List<Product> Products { get; set; }
    }
}
