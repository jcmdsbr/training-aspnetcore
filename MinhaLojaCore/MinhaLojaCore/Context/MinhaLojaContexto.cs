using Microsoft.EntityFrameworkCore;
using MinhaLojaCore.Context.Maps;
using MinhaLojaCore.Models;

namespace MinhaLojaCore.Context
{
    public class MinhaLojaContexto : DbContext
    {
        public MinhaLojaContexto(DbContextOptions<MinhaLojaContexto> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new FabricanteMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}