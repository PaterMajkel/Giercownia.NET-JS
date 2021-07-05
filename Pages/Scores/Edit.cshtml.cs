using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Giercownia.NET_JS.Data;
using Giercownia.NET_JS.Models;

namespace Giercownia.NET_JS.Pages.Scores
{
    public class EditModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;

        public EditModel(Giercownia.NET_JS.Data.ApplicationDbContext context)
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
           ViewData["AppUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id");
           ViewData["GameId"] = new SelectList(_context.Game, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(Score.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScoreExists(int id)
        {
            return _context.Score.Any(e => e.Id == id);
        }
    }
}
