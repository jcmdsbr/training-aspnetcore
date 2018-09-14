using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaLojaCore.Models;

namespace MinhaLojaCore.Context.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto", "dbo");

            builder.HasKey(f => f.Id);

            // Map propriedades do produto
            builder.Property(f => f.Id)
               .HasColumnName("cd_produto");

            builder.Property(f => f.Descricao)
               .HasColumnName("dc_produto");

            builder.Property(f => f.Nome)
             .HasColumnName("nm_produto");

            builder.Property(f => f.DataDeFabricacao)
              .HasColumnName("dt_fabricacao");


            //Map FK Fabricante
            builder.Property(c => c.FabricanteId)
                .HasColumnName("cd_fabricante");


            builder.HasOne(s => s.Fabricante)
                .WithMany()
                .HasForeignKey(e => e.FabricanteId)
                .IsRequired();

            // Map FK Categoria
            builder.Property(c => c.CategoriaId)
                .HasColumnName("cd_categoria");


            builder.HasOne(s => s.Categoria)
                .WithMany()
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired();
        }
    }
}
