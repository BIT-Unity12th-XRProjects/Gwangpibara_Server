using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using Persistence.Data;

namespace Persistence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices((context, services) =>
                {
                   var serverVersion = ServerVersion.AutoDetect(ConnectionSettings.CONNECTION);

                    services.AddDbContext<GameDBContext>(opt =>
                        opt.UseMySql(ConnectionSettings.CONNECTION, serverVersion));

                    Console.WriteLine(serverVersion);
                });

            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<GameDBContext>();
                context.Database.EnsureCreated();
                DBInitializeTest.Initialize(context);
            }
            app.Run();
        }
    }
}
