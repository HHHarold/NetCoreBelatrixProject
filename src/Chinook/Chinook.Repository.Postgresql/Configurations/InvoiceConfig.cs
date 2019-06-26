using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice")
                .HasKey(x => x.InvoiceId)
                .HasName("invoice_id_pkey");

            builder.Property(x => x.InvoiceId)
                .HasColumnName("invoice_id")
                .UseNpgsqlIdentityColumn();
            
            builder.Property(x => x.InvoiceDate)
                .HasColumnName("invoice_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.BillingAddress)
                .HasColumnName("billing_address")
                .HasMaxLength(70);

            builder.Property(x => x.BillingCity)
                .HasColumnName("billing_city")
                .HasMaxLength(40);

            builder.Property(x => x.BillingState)
                .HasColumnName("billing_state")
                .HasMaxLength(40);

            builder.Property(x => x.BillingCountry)
                .HasColumnName("billing_country")
                .HasMaxLength(40);

            builder.Property(x => x.BillingPostalCode)
                .HasColumnName("billing_postal_code")
                .HasMaxLength(10);

            builder.Property(x => x.Total)
                .HasColumnName("total")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0")
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("invoice__reference_customer_id__fkey");

            builder.HasIndex(e => e.CustomerId)
                .HasName("invoice__customer_id__idx");
        }
    }
}
