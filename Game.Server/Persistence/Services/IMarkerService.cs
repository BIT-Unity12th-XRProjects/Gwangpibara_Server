using Persistence.Models;

namespace Persistence.Services
{
    public interface IMarkerService
    {
        Task<List<Marker>> GetAllAsync();
        Task<Marker?> GetByIdAsync(int id);
        Task<Marker> CreateAsync(Marker newMarker);
        Task DeleteByIdAsync(int id);
        Task UpdatePositionAsync(int markerId, Vector3Value newPosition);
    }
}
