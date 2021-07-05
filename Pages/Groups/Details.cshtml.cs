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
    public class DetailsModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DetailsModel(Giercownia.NET_JS.Data.ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Group Group { get; set; }
        public AppUser Current { get; set; }
        public  AppUser  Owner { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Current = await _userManager.GetUserAsync(HttpContext.User);

            Group = await _context.Group.FirstOrDefaultAsync(m => m.Id == id);
            Owner = await _context.AppUser.FirstOrDefaultAsync(e => e.Id == Group.OwnerId);

            if (Group == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
