using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer")
                .HasKey(c => c.CustomerId)
                .HasName("customer__customer_id__pkey");

            builder.Property(e => e.CustomerId)
                .HasColumnName("customer_id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Company)
                .HasColumnName("company")
                .HasMaxLength(80);

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(70);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(40);

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasMaxLength(40);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(40);

            builder.Property(e => e.PostalCode)
                .HasColumnName("postal_code")
                .HasMaxLength(10);

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(24);

            builder.Property(e => e.Fax)
                .HasColumnName("fax")
                .HasMaxLength(24);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(60)
                .IsRequired();

            builder.HasOne(d => d.SupportRep)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.SupportRepId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("customer__reference_employee__fkey");

            builder.HasIndex(e => e.SupportRepId)
                .HasName("customer__support_rep_id__idx");
        }
    }
}
