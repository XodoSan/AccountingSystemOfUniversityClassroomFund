using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class FinanciallyResponsiblePersonChangeHistoryConfiguration 
        : IEntityTypeConfiguration<EquipmentFinanciallyResponsiblePersonChangeHistoryItem>
    {
        public void Configure(EntityTypeBuilder<EquipmentFinanciallyResponsiblePersonChangeHistoryItem> builder)
        {
            builder.ToTable(nameof(EquipmentFinanciallyResponsiblePersonChangeHistoryItem))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired();
            builder.Property(item => item.ChangeTime).IsRequired();
            builder.Property(item => item.CurrentFinanciallyResponsiblePersonId).IsRequired();
            builder.Property(item => item.EquipmentInventoryNumber).IsRequired();
            builder.Property(item => item.PreviousFinanciallyResponsiblePersonId);
        }
    }
}