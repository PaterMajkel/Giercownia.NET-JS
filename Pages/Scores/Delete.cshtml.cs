using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Giercownia.NET_JS.Data;
using Giercownia.NET_JS.Models;

namespace Giercownia.NET_JS.Pages.Scores
{
    public class DeleteModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;

        public DeleteModel(Giercownia.NET_JS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Score Score { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Score = await _context.Score
                .Include(s => s.AppUser)
                .Include(s => s.Game).FirstOrDefaultAsync(m => m.Id == id);

            if (Score == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Score = await _context.Score.FindAsync(id);

            if (Score != null)
            {
                _context.Score.Remove(Score);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
