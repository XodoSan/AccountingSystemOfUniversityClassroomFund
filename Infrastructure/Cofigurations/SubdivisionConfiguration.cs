using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class SubdivisionConfiguration : IEntityTypeConfiguration<Subdivision>
    {
        public void Configure(EntityTypeBuilder<Subdivision> builder)
        {
            builder.ToTable(nameof(Subdivision))
                .HasKey(item => item.Name);
            builder.Property(item => item.Name).IsRequired();
            builder.HasMany(item => item.IncomingRooms)
                .WithOne()
                .HasForeignKey(item => item.SubdivisionName);
            builder.HasMany(item => item.IncomingWorkers)
                .WithOne()
                .HasForeignKey(item => item.SubdivisionName);
        }
    }
}
