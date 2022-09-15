using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class EquipmentCategoryConfiguration : IEntityTypeConfiguration<EquipmentCategory>
    {
        public void Configure(EntityTypeBuilder<EquipmentCategory> builder)
        {
            builder.ToTable(nameof(EquipmentCategory))
                .HasKey(item => item.Name);
            builder.Property(item => item.Name).IsRequired();
            builder.HasMany(item => item.CurrentCategoryEquipments)
                .WithOne()
                .HasForeignKey(item => item.EquipmentCategoryName);
        }
    }
}