using System;
using System.Collections.Generic;
using System.Text;
using Giercownia.NET_JS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Giercownia.NET_JS.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Group> Group { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
