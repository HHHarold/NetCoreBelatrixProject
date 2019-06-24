using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Repository.Postgresql.Configurations
{
    public class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("artist")
                .HasKey(c => c.ArtistId)
                .HasName("artist_artist_id_pkey");

            builder.Property(e => e.ArtistId)
                .HasColumnName("artist_id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(120);
        }
    }
}
