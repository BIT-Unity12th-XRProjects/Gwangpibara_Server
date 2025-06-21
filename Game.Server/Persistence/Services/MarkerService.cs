using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Models;

namespace Persistence.Services
{
    public class MarkerService
    {
        private readonly GameDBContext _context;

        public MarkerService(GameDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Marker> GetAll()
        {
            return _context.Markers
                .AsNoTracking()
                .ToList();
        }

        public Marker? GetById(int id)
        {
            return _context.Markers
                .Include(p => p.Name)
                .Include(p => p.DropItemID)
                .Include(p => p.AcquireStep)
                .Include(p => p.RemoveStep)
                .Include(p => p.Position)
                .Include(p => p.Rotation)
                .Include(p => p.MarkerSpawnType)
                .Include(p => p.MarkerType)
                .AsNoTracking()
                .SingleOrDefault(p => p.ID == id);
        }

        public Marker Create(Marker newMarker)
        {
            _context.Markers.Add(newMarker);
            _context.SaveChanges();

            return newMarker;
        }

        public void DeleteById(int id)
        {
            Marker? markerToDelete = _context.Markers.Find(id);
            if (markerToDelete is not null)
            {
                _context.Markers.Remove(markerToDelete);
                _context.SaveChanges();
            }
        }
    }
}
