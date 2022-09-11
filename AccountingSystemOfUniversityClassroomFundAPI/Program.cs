using Application.DTOs.Mapping;
using Application.Services.ClassroomFundService;
using Application.Services.EquipmentService;
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
        builder.Services.AddScoped<IClassroomFundService, ClassroomFundService>();
        builder.Services.AddScoped<IClassroomFundRepository, ClassroomFundRepository>();
        builder.Services.AddScoped<IEquipmentService, EquipmentService>();
        builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        IConfiguration config = GetConfig();
        string connectionString = config.GetConnectionString(Constant.DatabaseName);
        builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString, 
            x => x.MigrationsAssembly("Infrastructure")));

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var app = builder.Build();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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