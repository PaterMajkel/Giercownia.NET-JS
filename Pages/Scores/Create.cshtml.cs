using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Giercownia.NET_JS.Data;
using Giercownia.NET_JS.Models;

namespace Giercownia.NET_JS.Pages.Scores
{
    public class CreateModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;

        public CreateModel(Giercownia.NET_JS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AppUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id");
        ViewData["GameId"] = new SelectList(_context.Game, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Score Score { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Score.Add(Score);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
