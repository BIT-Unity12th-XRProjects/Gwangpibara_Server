using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    class DesignTimeFactory : IDesignTimeDbContextFactory<GameDBContext>
    {
        public GameDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GameDBContext>()
                // Oracle provider 8.4.0
                .UseMySql(ConnectionSettings.CONNECTION, MySqlServerVersion.AutoDetect(ConnectionSettings.CONNECTION))
                .EnableDetailedErrors();

            return new GameDBContext(builder.Options);
        }

    }
}
