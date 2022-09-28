using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class RoomFileConfiguration : IEntityTypeConfiguration<RoomFile>
    {
        public void Configure(EntityTypeBuilder<RoomFile> builder)
        {
            builder.ToTable(nameof(RoomFile))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(item => item.FileName).IsRequired();
            builder.Property(item => item.Content).IsRequired();
        }
    }
}
