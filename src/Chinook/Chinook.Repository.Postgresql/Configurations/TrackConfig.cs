using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class TrackConfig : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("track")
                .HasKey(x => x.TrackId)
                .HasName("track__track_id__pkey");

            builder.Property(x => x.TrackId)
                .HasColumnName("track_id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(x => x.Composer)
                .HasColumnName("composer")
                .HasMaxLength(220);

            builder.Property(x => x.Milliseconds)
                .HasColumnName("milliseconds")
                .IsRequired();

            builder.Property(x => x.Bytes)
                .HasColumnName("bytes");

            builder.Property(x => x.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("numeric(10,2)")
                .HasDefaultValue("0")
                .IsRequired();

            builder.HasOne(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("track__reference_album_id__fkey");

            builder.HasIndex(e => e.AlbumId)
                .HasName("track__album_id__idx");

            builder.HasOne(x => x.MediaType)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.MediaTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("track__reference_media_type_id__fkey");

            builder.HasIndex(e => e.MediaTypeId)
                .HasName("track__media_type_id__idx");

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("track__reference_genre_id__fkey");

            builder.HasIndex(e => e.GenreId)
                .HasName("track__genre_id__idx");
        }
    }
}
