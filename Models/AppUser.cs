using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giercownia.NET_JS.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Score> Scores { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }

    }
}
