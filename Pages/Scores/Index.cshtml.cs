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
    public class IndexModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.ApplicationDbContext _context;

        public IndexModel(Giercownia.NET_JS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Score> Score { get;set; }

        public async Task OnGetAsync()
        {
            Score = await _context.Score
                .Include(s => s.AppUser)
                .Include(s => s.Game).ToListAsync();
        }
    }
}
