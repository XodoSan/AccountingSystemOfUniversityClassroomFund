using Application.DTOs.Mapping;
using Application.Services;
using Application.Services.ClassroomFundService;
using Application.Services.EquipmentService;
using Application.Services.HistoryService;
using Application.Services.WorkerService;
using Application.Tools;
using Domain.Constants;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Tools;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddTransient<ClassroomFundService>();
        builder.Services.AddTransient<IClassroomFundService>(item => item.GetRequiredService<ClassroomFundService>());
        builder.Services.AddTransient<IFileService>(item => item.GetRequiredService<ClassroomFundService>());
        builder.Services.AddScoped<IClassroomFundRepository, ClassroomFundRepository>();
        builder.Services.AddTransient<EquipmentService>();
        builder.Services.AddTransient<IEquipmentService>(item => item.GetRequiredService<EquipmentService>());
        builder.Services.AddTransient<IHistoryService>(item => item.GetRequiredService<EquipmentService>());
        builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        builder.Services.AddScoped<IWorkerService, WorkerService>();
        builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
        builder.Services.AddScoped<IEquipmentCategoryRepository, EquipmentCategoryRepository>();
        builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        IConfiguration config = GetConfig();
        string connectionString = config.GetConnectionString(Constant.DatabaseName);
        builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString,
            x => x.MigrationsAssembly("Infrastructure")));

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var app = builder.Build();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
        app.Run();
    }

    private static IConfiguration GetConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        return builder.Build();
    }
}