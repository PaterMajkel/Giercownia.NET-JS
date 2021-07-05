using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Giercownia.NET_JS.Data;
using Giercownia.NET_JS.Models;
using Microsoft.AspNetCore.Identity;

namespace Giercownia.NET_JS.Pages.Groups
{
    public class CreateModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(Giercownia.NET_JS.Data.ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Group Group { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Group.OwnerId = _userManager.GetUserId(HttpContext.User);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Group.Add(Group);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
