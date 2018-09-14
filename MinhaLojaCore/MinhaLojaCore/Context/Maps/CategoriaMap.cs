using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaLojaCore.Models;

namespace MinhaLojaCore.Context.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria", "dbo");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("cd_categoria");

            builder.Property(f => f.Descricao)
                .HasColumnName("dc_categoria");

            //Map HasMany Produtos
            builder.HasMany(s => s.Produtos)
                .WithOne(x => x.Categoria);
        }
    }
}