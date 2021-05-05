using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whirlpool.IdentityData
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? CreatedDate { get; set; }
        public int TotalPosts { get; set; }

    }
}
