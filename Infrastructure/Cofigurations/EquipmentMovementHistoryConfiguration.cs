using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class EquipmentMovementHistoryConfiguration : IEntityTypeConfiguration<EquipmentMovementHistory>
    {
        public void Configure(EntityTypeBuilder<EquipmentMovementHistory> builder)
        {
            builder.ToTable(nameof(EquipmentMovementHistory))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired();
            builder.Property(item => item.MovementTime).IsRequired();
            builder.Property(item => item.RoomNumber).IsRequired();
            builder.Property(item => item.EquipmentInventoryNumber).IsRequired();
            builder.Property(item => item.PreviousRoomNumber);
        }
    }
}
