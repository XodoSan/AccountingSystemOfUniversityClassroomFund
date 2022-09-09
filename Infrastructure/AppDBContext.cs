using Infrastructure.Cofigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentMovementHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new FinanciallyResponsiblePersonChangeHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new SubdivisionConfiguration());
            modelBuilder.ApplyConfiguration(new UniversityBuildingConfiguration());
            modelBuilder.ApplyConfiguration(new UsageConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
        }
    }
}
