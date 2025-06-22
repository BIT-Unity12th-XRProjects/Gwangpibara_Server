using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Services;

namespace Persistence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IMarkerService, MarkerService>();

            builder.Services.AddControllers();

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
            app.UseAuthorization();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();
        }
    }
}
