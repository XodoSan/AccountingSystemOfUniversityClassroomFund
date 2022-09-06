using Domain.Constants;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        var app = builder.Build();
        app.UseStaticFiles();
        app.UseRouting();

        var configBuilder = new ConfigurationBuilder();
        IConfiguration config = configBuilder.Build();
        string connectionString = config.GetConnectionString(Constant.DatabaseName);

        IServiceCollection services = new ServiceCollection();
        services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString));

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}