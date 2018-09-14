using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaLojaCore.Models;

namespace MinhaLojaCore.Context.Maps
{
    public class FabricanteMap : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.ToTable("fabricante", "dbo");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
               .HasColumnName("cd_fabricante");

            builder.Property(f => f.Cnpj)
             .HasColumnName("cnpj");

        }
    }
}
