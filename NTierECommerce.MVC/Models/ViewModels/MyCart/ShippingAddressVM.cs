using System.ComponentModel.DataAnnotations;

namespace NTierECommerce.MVC.Models.ViewModels.MyCart
{
    public class ShippingAddressVM
    {
        public int ShippingAddressId { get; set; }

		[Required(ErrorMessage = "(Adres Adı boş olamaz!)")]
		[Display(Name = "Adres Adı")]
		[MaxLength(64)]
        public string AddressName { get; set; }

        [Required(ErrorMessage = "(Ad boş olamaz!)")]
        [Display( Name = "Ad")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "(Soyad boş olamaz!)")]
        [Display(Name = "Soyad")]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "(Telefon Numarası boş olamaz!)")]
        [Display(Name = "Telefon Numarası")]
        [MaxLength(64)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "(Adres boş olamaz!)")]
        [Display(Name = "Adres")]
        [MaxLength(255)]
        public string Address { get; set; }
    }
}
