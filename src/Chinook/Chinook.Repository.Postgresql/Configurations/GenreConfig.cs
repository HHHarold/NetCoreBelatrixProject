using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Repository.Postgresql.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre")
                .HasKey(c => c.GenreId)
                .HasName("genre_genre_id_pkey");

            builder.Property(e => e.GenreId)
                .HasColumnName("genre_id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(120);
        }
    }
}
