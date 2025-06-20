using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Data
{
    class MarkerContext : DbContext
    {
        public MarkerContext(DbContextOptions<MarkerContext> options) : base(options)
        {

        }
        public DbSet<Marker> Markers => Set<Marker>();
    }
}
