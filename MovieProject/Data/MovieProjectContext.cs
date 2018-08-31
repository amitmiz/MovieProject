using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;

namespace MovieProject.Models
{
    public class MovieProjectContext : DbContext
    {
        public MovieProjectContext (DbContextOptions<MovieProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MovieProject.Models.Movie> Movie { get; set; }

        public DbSet<MovieProject.Models.StoreBranch> StoreBranch { get; set; }
    }
}
