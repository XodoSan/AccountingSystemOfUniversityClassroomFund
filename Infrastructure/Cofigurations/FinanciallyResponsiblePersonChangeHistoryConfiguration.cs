using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class FinanciallyResponsiblePersonChangeHistoryConfiguration 
        : IEntityTypeConfiguration<EquipmentFinanciallyResponsiblePersonChangeHistory>
    {
        public void Configure(EntityTypeBuilder<EquipmentFinanciallyResponsiblePersonChangeHistory> builder)
        {
            builder.ToTable(nameof(EquipmentFinanciallyResponsiblePersonChangeHistory))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired();
            builder.Property(item => item.ChangeTime).IsRequired();
            builder.Property(item => item.CurrentFinanciallyResponsiblePersonId).IsRequired();
            builder.Property(item => item.EquipmentInventoryNumber).IsRequired();
            builder.Property(item => item.PreviousFinanciallyResponsiblePersonId);
        }
    }
}