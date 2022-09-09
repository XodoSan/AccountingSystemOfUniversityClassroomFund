using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cofigurations
{
    public class UniversityBuildingConfiguration : IEntityTypeConfiguration<UniversityBuilding>
    {
        public void Configure(EntityTypeBuilder<UniversityBuilding> builder)
        {
            builder.ToTable(nameof(UniversityBuilding))
                .HasKey(item => item.Name);
            builder.Property(item => item.Name).IsRequired();
            builder.Property(item => item.Adress).IsRequired();
            builder.Property(item => item.StoreysNumber).IsRequired();
            builder.Property(item => item.FoundationYear).IsRequired();
            builder.HasMany(item => item.IncomingRooms)
                .WithOne()
                .HasForeignKey(item => item.UniversityName)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
