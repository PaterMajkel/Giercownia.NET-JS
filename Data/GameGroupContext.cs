using Giercownia.NET_JS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giercownia.NET_JS.Data
{
    public class GameGroupContext : DbContext
    {
        public GameGroupContext(DbContextOptions options) : base(options) { }

        public DbSet<Group> Group { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
