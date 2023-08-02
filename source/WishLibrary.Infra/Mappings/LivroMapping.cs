using Microsoft.EntityFrameworkCore;
using WishLibrary.Core.Models;

namespace WishLibrary.Infra.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("T_LIVRO");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.DataLancamento).
                HasColumnType("DATE")
                .IsRequired();

            builder.HasIndex(p => p.GeneroId);
            builder.HasOne(p => p.Genero)
                   .WithMany(p => p.Livros)
                   .HasForeignKey(p => p.GeneroId);
        }
    }
}
