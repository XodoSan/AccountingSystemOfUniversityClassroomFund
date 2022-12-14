using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable(nameof(Worker))
                .HasKey(item => item.Id);
            builder.Property(item => item.Id).IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(item => item.Age).IsRequired();
            builder.Property(item => item.FullName).IsRequired();
            builder.Property(item => item.SubdivisionName).IsRequired();
            builder.HasMany(item => item.CurrentWorkerEquipments)
                .WithOne()
                .HasForeignKey(item => item.EquipmentWorkerId)
                .IsRequired();
        }
    }
}