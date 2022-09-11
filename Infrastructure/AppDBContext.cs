using Domain.Constants;
using Domain.Entities;
using Infrastructure.Cofigurations;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Purpose>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<RoomType>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().Ignore(item => item.Owner);
            modelBuilder.HasPostgresEnum<Purpose>();
            modelBuilder.HasPostgresEnum<RoomType>();
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
