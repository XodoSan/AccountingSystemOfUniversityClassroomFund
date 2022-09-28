using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class EquipmentMovementHistoryConfiguration : IEntityTypeConfiguration<EquipmentMovementHistoryItem>
    {
        public void Configure(EntityTypeBuilder<EquipmentMovementHistoryItem> builder)
        {
            builder.ToTable(nameof(EquipmentMovementHistoryItem))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired();
            builder.Property(item => item.MovementTime).IsRequired();
            builder.Property(item => item.CurrentRoomNumber).IsRequired();
            builder.Property(item => item.EquipmentInventoryNumber).IsRequired();
            builder.Property(item => item.PreviousRoomNumber);
        }
    }
}
