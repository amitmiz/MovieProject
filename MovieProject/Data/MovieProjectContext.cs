using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;

namespace MovieProject.Models
{
    public class MovieProjectContext : IdentityDbContext<ApplicationUser>
    {
        public MovieProjectContext (DbContextOptions<MovieProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MovieProject.Models.Movie> Movie { get; set; }

        public DbSet<MovieProject.Models.StoreBranch> StoreBranch { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MovieProject.Models.Customer> Customer { get; set; }

        public DbSet<MovieProject.Models.Supplier> Supplier { get; set; }
    }
}
