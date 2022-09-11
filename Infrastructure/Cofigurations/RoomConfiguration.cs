using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Cofigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable(nameof(Room))
                .HasKey(item => item.Number);
            builder.Property(item => item.Number).IsRequired();
            builder.Property(item => item.Purpose).IsRequired();
            builder.Property(item => item.Area).IsRequired();
            builder.Property(item => item.RoomType).IsRequired();
            builder.Property(item => item.Name).IsRequired();
            builder.Property(item => item.Capacity).IsRequired();
            builder.Property(item => item.Floor).IsRequired();
            builder.Property(item => item.FloorPlan).IsRequired();
            builder.HasOne(item => item.Owner)
                .WithMany()
                .HasForeignKey(item => item.SubdivisionName)
                .IsRequired();
        }
    }
}
