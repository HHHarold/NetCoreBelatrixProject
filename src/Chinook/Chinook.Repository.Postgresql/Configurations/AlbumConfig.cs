using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("album")
                .HasKey(c => c.AlbumId)
                .HasName("album__album_id__pkey");

            builder.Property(e => e.AlbumId)
                .HasColumnName("album_id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(160)
                .IsRequired();

            builder.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.AlbumId)                
                .OnDelete(DeleteBehavior.NoAction)                
                .HasConstraintName("Album__reference_artist__fkey");

            builder.HasIndex(e => e.ArtistId)
                .HasName("album__artist_id__idx");            
        }
    }
}
