using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class UsageConfiguration : IEntityTypeConfiguration<Usage>
    {
        public void Configure(EntityTypeBuilder<Usage> builder)
        {
            builder.ToTable(nameof(Usage))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(item => item.Instruction).IsRequired();
            builder.Property(item => item.Purpose).IsRequired();
        }
    }
}