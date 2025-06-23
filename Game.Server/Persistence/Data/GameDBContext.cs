using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Data
{
    public class GameDBContext : DbContext
    {
        public GameDBContext(DbContextOptions<GameDBContext> options) : base(options){}

        public DbSet<Marker> Markers => Set<Marker>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Marker>(eb =>
            {
                eb.OwnsOne(m => m.Position, nav =>
                {
                    nav.Property(p => p.X).HasColumnName("PositionX");
                    nav.Property(p => p.Y).HasColumnName("PositionY");
                    nav.Property(p => p.Z).HasColumnName("PositionZ");
                });
                eb.OwnsOne(m => m.Rotation, nav =>
                {
                    nav.Property(q => q.X).HasColumnName("RotationX");
                    nav.Property(q => q.Y).HasColumnName("RotationY");
                    nav.Property(q => q.Z).HasColumnName("RotationZ");
                    nav.Property(q => q.W).HasColumnName("RotationW");
                });
                eb.OwnsOne(m => m.Scale, nav =>
                {
                    nav.Property(p => p.X).HasColumnName("ScaleX");
                    nav.Property(p => p.Y).HasColumnName("ScaleY");
                    nav.Property(p => p.Z).HasColumnName("ScaleZ");
                });
            });
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDBContext).Assembly);
        }
    }
}
