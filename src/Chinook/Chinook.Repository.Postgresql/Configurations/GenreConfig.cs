using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre")
                .HasKey(c => c.GenreId)
                .HasName("genre__genre_id__pkey");

            builder.Property(e => e.GenreId)
                .HasColumnName("genre_id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(120);
        }
    }
}
