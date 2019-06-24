using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Repository.Postgresql.Configurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice")
                .HasKey(c => c.InvoiceId)
                .HasName("invoice_invoice_id_pkey");

            builder.Property(e => e.InvoiceId)
                .HasColumnName("invoice_id")
                .UseNpgsqlIdentityColumn();
        }
    }
}
