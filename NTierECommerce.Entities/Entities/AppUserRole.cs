using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Entities.Entities
{
    public class AppUserRole:IdentityRole<int>
    {
        public string? Description { get; set; }
       
    }
}
