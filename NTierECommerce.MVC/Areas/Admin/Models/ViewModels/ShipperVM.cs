using NTierECommerce.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class ShipperVM
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string CompanyName { get; set; }
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }

    }
}
