using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Giercownia.NET_JS.Data;
using Giercownia.NET_JS.Models;
using Microsoft.AspNetCore.Identity;

namespace Giercownia.NET_JS.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public IndexModel(Giercownia.NET_JS.Data.ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Group> Group { get;set; }
        public AppUser AppUser { get; set; }

        public async Task OnGetAsync()
        {
            AppUser = await _userManager.GetUserAsync(HttpContext.User);
            Group = await _context.Group.ToListAsync();
        }
    }
}
