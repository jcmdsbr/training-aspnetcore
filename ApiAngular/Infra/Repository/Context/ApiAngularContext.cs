using ApiAngular.Infra.Repository.Context.Maps;
using ApiAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAngular.Infra.Repository.Context
{
    public class ApiAngularContext : DbContext
    {
        public ApiAngularContext(DbContextOptions<ApiAngularContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}