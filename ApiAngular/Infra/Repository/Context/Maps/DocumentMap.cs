using ApiAngular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAngular.Infra.Repository.Context.Maps
{
    public class DocumentMap : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("document", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_document");

            builder.HasIndex(x => x.Initials)
                .IsUnique();

            builder.Property(x => x.Initials)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("init_document");

            builder.Property(x => x.Description)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("dc_document");

            builder.Property(x => x.Status)
                .HasColumnName("id_status");

            builder.Property(x => x.IdCustomer)
                .HasColumnName("id_customer");

            builder.HasOne(x => x.Customer)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.IdCustomer);
        }
    }
}