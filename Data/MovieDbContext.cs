using Microsoft.EntityFrameworkCore;
using MovieCrud.Models;

namespace MovieCrud.Data {
    public class MovieDbContext : DbContext {
        public MovieDbContext (DbContextOptions<MovieDbContext> options) : base (options) { }

        public DbSet<Movie> Movies { get; set; }

    }
}