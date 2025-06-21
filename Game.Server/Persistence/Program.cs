using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Data;

namespace Persistence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
                options.AddPolicy("AllowAll",
                    policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                ));

            builder.Services.AddDbContext<GameDBContext>(opt =>
                opt.UseMySql(ConnectionSettings.CONNECTION, ServerVersion.AutoDetect(ConnectionSettings.CONNECTION)));

            var app = builder.Build();

            app.CreateDbIfNotExists();

            app.UseCors("AllowAll");

            app.Run();
        }
    }
}
