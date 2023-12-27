using Microsoft.AspNetCore.Identity;
using NTierECommerce.Entities.Entities;

namespace NTierECommerce.MVC.Areas.Admin.Models.ViewModels
{
    public class UserListVM
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<AppUserRole> Roles { get; set; }
    }
}
