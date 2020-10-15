using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess.Configurations
{
    /// <summary>
    /// Provides configuration of <see cref="Character"/> database.
    /// </summary>
    public static class CharacterConfiguration
    {
        /// <summary>
        /// Configure table settings in database context.
        /// </summary>
        /// <param name="entityBuilder"></param>
        public static void Configure(EntityTypeBuilder<Character> entityBuilder) 
        {
            entityBuilder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            entityBuilder.Property(x => x.Role)
                .HasMaxLength(35)
                .IsRequired();

            entityBuilder.Property(x => x.School)
                .HasMaxLength(100)
                .IsRequired();

            entityBuilder.Property(x => x.HouseId)
                .HasMaxLength(24)
                .IsRequired();

            entityBuilder.Property(x => x.HouseName)
                .HasMaxLength(30)
                .IsRequired();

            entityBuilder.Property(x => x.Patronus)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
