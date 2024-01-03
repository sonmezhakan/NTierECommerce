using NTierECommerce.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.Entities.Entities
{
	public class OrderDetail:BaseEntity
    {
		[Required]
		public int OrderId { get; set; }
		[Required]
		public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
		[Required]
		public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public Order Order { get; set; }
    }
}
