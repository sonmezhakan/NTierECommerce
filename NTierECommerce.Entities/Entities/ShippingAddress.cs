using NTierECommerce.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Entities.Entities
{
	public class ShippingAddress:BaseEntity
	{
		[Required]
		[MaxLength(64)]
        public string AddressName { get; set; }
		[Required]
		[MaxLength(64)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(64)]
		public string LastName { get; set; }
		[Required]
		[MaxLength(64)]
		public string PhoneNumber { get; set; }
		[Required]
		[MaxLength(64)]
		public string Address { get; set; }

		
		public int AppUserId { get; set; }

		public AppUser AppUser { get; set; }

        public List<Order> Orders { get; set; }
    }
}
