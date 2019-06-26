using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class PlaylistConfig : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("playlist")
                .HasKey(x => x.PlaylistId)
                .HasName("playlist__playlist_id__pkey");

            builder.Property(x => x.PlaylistId)
                .HasColumnName("playlist_id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(120);
        }
    }
}
