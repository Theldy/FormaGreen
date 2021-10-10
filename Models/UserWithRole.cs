using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormaGreen.Models
{
    public class UserWithRole
    {
        public IdentityUser User { get; set; }
        public string Role { get; set; }
    }
}
