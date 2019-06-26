using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.WebApi.Repository.Postgresql.Configurations
{
    internal class MediaTypeConfig : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.ToTable("media_type")
                .HasKey(x => x.MediaTypeId)
                .HasName("media_type__media_type_id__pkey");

            builder.Property(x => x.MediaTypeId)
                .HasColumnName("media_type_id")
                .UseNpgsqlIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(120);
        }
    }
}
