using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class InvoiceLineConfig : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("invoice_line")
                .HasKey(x => x.InvoiceLineId)
                .HasName("invoice_line__invoice_line_id__pkey");

            builder.Property(x => x.InvoiceLineId)
                .HasColumnName("invoice_line_id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValueSql("0")
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("invoice_line__reference_invoice_id__fkey");

            builder.HasIndex(e => e.InvoiceId)
                .HasName("invoice_line__invoice_id__idx");

            builder.HasOne(x => x.Track)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("invoice_line__reference_track_id__fkey");

            builder.HasIndex(e => e.TrackId)
                .HasName("invoice_line__track_id__idx");
        }
    }
}
