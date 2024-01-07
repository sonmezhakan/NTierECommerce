using NTierECommerce.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Entities.Entities
{
	public class Order:BaseEntity
	{
        public Order()
        {
			OrderDetails = new List<OrderDetail>();
        }
        [Required]
		public int OrderId { get; set; }
		[Required]
		public DateTime OrderDate { get; set; }

		public decimal? Freight { get; set; }
        public string? ShipNumber { get; set; }

		public int? ShipperId { get; set; }
        public int ShippingAddressId { get; set; }

        [Required]
		public int AppUserId { get; set; }

		public virtual AppUser AppUser { get; set; }
        public virtual Shipper Shipper { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
		public ShippingAddress ShippingAddress { get; set; }


	}
}
