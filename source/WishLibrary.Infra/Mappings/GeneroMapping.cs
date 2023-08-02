using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WishLibrary.Core.Models;

namespace WishLibrary.Infra.Mappings
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("T_GENERO");
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Nome)
                .IsUnique();

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
        }
    }
}
