using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WishLibrary.Core.Models;

namespace WishLibrary.Infra.Context
{
    public partial class WishLibraryContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public WishLibraryContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
            }
        }

        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WishLibraryContext).Assembly);
        }
    }
}
