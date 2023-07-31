using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
