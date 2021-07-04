using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Giercownia.NET_JS.Data;
using Giercownia.NET_JS.Models;

namespace Giercownia.NET_JS.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly Giercownia.NET_JS.Data.GameGroupContext _context;

        public IndexModel(Giercownia.NET_JS.Data.GameGroupContext context)
        {
            _context = context;
        }

        public IList<Group> Group { get;set; }

        public async Task OnGetAsync()
        {
            Group = await _context.Group.ToListAsync();
        }
    }
}
