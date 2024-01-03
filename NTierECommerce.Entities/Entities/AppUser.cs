using Microsoft.AspNetCore.Identity;

namespace NTierECommerce.Entities.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public DateTime? Birthdate { get; set; }
        public string? Address { get; set; }

        //Todo: Kullanıcı Detayları için AppUserProfile oluşturulacak.

        public virtual List<Order> Orders { get; set; }
    }
}
