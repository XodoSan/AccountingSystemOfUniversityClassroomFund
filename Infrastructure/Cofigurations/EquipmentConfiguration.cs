using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable(nameof(Equipment))
                .HasKey(item => item.InventoryNumber);
            builder.Property(item => item.InventoryNumber).IsRequired();
            builder.Property(item => item.Name).IsRequired();
            builder.Property(item => item.Price).IsRequired();
            builder.Property(item => item.PurchaseDate).IsRequired();
            builder.Property(item => item.CommissioningDate).IsRequired();
            builder.Property(item => item.SerialNumber).IsRequired();
            builder.HasOne(item => item.WhereUsed)
                .WithOne()
                .HasForeignKey<Usage>(item => item.EquipmentInventoryNumber)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}