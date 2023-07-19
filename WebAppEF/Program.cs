using Microsoft.EntityFrameworkCore;
using WebAppEF.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // �������� ������ ����������� �� ����� ������������
        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

        // ��������� �������� ApplicationContext � �������� ������� � ����������
        builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(connection));

        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}