using Microsoft.EntityFrameworkCore;
using WebAppEF.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // get connection string from config file
        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

        // add context 'ApplicationContext' as a service to the application
        builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(connection));

        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}