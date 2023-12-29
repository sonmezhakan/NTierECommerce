using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Entities.Entities
{
    public class AppUserRole:IdentityRole<int>
    {
        [Display(Name = "Description :")]
        [MaxLength(255)]
        public string? Description { get; set; }
       
    }
}
