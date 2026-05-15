using Microsoft.Extensions.Hosting;
using CustomerLookup.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CustomerLookup.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        //Application.Run(new CustomerSearch());

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var connectionString =
                    "Server=DESKTOP-BS19N7I;Database=LegacyCustomerLookupDb;Trusted_Connection=True;TrustServerCertificate=True";

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddScoped<CustomerService>();
                services.AddTransient<CustomerSearch>();
            })
            .Build();

        using var scope = host.Services.CreateScope();
        var form = scope.ServiceProvider.GetRequiredService<CustomerSearch>();

        Application.Run(form);
    }
}