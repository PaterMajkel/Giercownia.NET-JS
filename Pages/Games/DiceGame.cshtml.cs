using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Giercownia.NET_JS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Giercownia.NET_JS.Pages.Games
{
    public class DiceGameModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public DiceGameModel(Giercownia.NET_JS.Data.ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            Game = await _context.Game.FirstOrDefaultAsync(e => e.Name == "Dice Game");
            return Page();
        }
        [BindProperty]
        public Score Score { get; set; }
        public Game Game { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Game = await _context.Game.FirstOrDefaultAsync(e => e.Name == "Dice Game");
            Score.GameId = Game.Id;
            Score.AppUserId = _userManager.GetUserId(HttpContext.User);

            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(JsonSerializer.Serialize(ModelState));

                return Page();
            }

            _context.Score.Add(Score);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index"); ;
        }
    }
}
