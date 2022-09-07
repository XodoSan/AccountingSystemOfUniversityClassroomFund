using Application.Services;
using Domain.Constants;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddScoped<IAuditoriumFundService, AuditoriumFundService>();
        builder.Services.AddScoped<IAuditoriumFundRepository, AuditoriumFundRepository>();

        IConfiguration config = GetConfig();
        string connectionString = config.GetConnectionString(Constant.DatabaseName);
        builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString, 
            x => x.MigrationsAssembly("Infrastructure")));

        var app = builder.Build();
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