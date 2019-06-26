using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class PlaylistTrackConfig : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.ToTable("playlist_track")
                .HasKey(x => new { x.PlaylistId, x.TrackId })
                .HasName("playlist_track__playlist_track_id__pkey");

            builder.Property(x => x.PlaylistId)
                .HasColumnName("PlaylistId")
                .IsRequired();

            builder.Property(x => x.TrackId)
                .HasColumnName("TrackId")
                .IsRequired();

            builder.HasOne(x => x.Playlist)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("playlist_track__reference_playlist__fkey");

            builder.HasOne(x => x.Track)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("playlist_track__reference_track__fkey");

            builder.HasIndex(e => e.TrackId)
                .HasName("playlist_track__track_id__idx");
        }
    }
}
