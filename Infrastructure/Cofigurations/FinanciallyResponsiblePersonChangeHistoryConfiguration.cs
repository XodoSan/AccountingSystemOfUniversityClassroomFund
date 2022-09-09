using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class FinanciallyResponsiblePersonChangeHistoryConfiguration : IEntityTypeConfiguration<FinanciallyResponsiblePersonChangeHistory>
    {
        public void Configure(EntityTypeBuilder<FinanciallyResponsiblePersonChangeHistory> builder)
        {
            builder.ToTable(nameof(FinanciallyResponsiblePersonChangeHistory))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired();
            builder.Property(item => item.ChangeTime).IsRequired();
            builder.Property(item => item.CurrentFinanciallyResponsiblePersonId).IsRequired();
            builder.Property(item => item.PreviousFinanciallyResponsiblePersonId);
        }
    }
}
