using NTierECommerce.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.Entities.Entities
{
	public class Shipper:BaseEntity
    {
		[Required]
		[MaxLength(255)]
		public string CompanyName { get; set; }
		[MaxLength(11)]
		public string? PhoneNumber { get; set; }

        public List<Order> Orders { get; set; }
    }
}
