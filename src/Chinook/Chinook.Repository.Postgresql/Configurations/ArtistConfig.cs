using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("artist")
                .HasKey(c => c.ArtistId)
                .HasName("artist__artist_id__pkey");

            builder.Property(e => e.ArtistId)
                .HasColumnName("artist_id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(120);
        }
    }
}
