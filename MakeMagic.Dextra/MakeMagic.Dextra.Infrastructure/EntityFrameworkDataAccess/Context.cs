using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Configurations;
using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess
{
    /// <inheritdoc />
    public class Context : DbContext, IContext
    {
        /// <inheritdoc />
        public DbSet<Character> Characters { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MakeMagicRepository");
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CharacterConfiguration.Configure(modelBuilder.Entity<Character>());
        }
    }
}
