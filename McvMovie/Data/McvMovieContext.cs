

using Microsoft.EntityFrameworkCore;
using McvMovie.Models;

namespace McvMovie.Data
{
    public class McvMovieContext : DbContext
    {
        public McvMovieContext(DbContextOptions<McvMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(m => m.Price)
                .HasPrecision(18, 2);
        }
    }
}