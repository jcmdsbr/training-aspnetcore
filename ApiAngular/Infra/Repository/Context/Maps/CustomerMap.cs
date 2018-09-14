using ApiAngular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAngular.Infra.Repository.Context.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_customer");


            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nm_customer");
        }
    }
}