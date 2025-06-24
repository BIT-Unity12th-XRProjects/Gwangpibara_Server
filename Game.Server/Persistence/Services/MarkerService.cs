using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Models;

namespace Persistence.Services
{
    public class MarkerService : IMarkerService
    {
        private readonly GameDBContext _context;

        public MarkerService(GameDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 모든 마커 단순 조회용, 추적은 안 함
        /// </summary>
        public async Task<List<Marker>> GetAllAsync()
        {
            return await _context.Markers
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        /// <summary>
        /// ID로 마커 단순 조회, 추적은 안 함
        /// </summary>
        public async Task<Marker?> GetByIdAsync(int id)
        {
            return await _context.Markers
                                 .AsNoTracking()
                                 .SingleOrDefaultAsync(p => p.ID == id);
        }

        /// <summary>
        /// 마커 생성 후 DB에 저장
        /// </summary>
        public async Task<Marker> CreateAsync(Marker newMarker)
        {
            newMarker.ID = 0;
            var m = await _context.Markers.AddAsync(newMarker);
            await _context.SaveChangesAsync();
            return m.Entity;
        }

        /// <summary>
        /// ID로 마커 삭제
        /// </summary>
        public async Task DeleteByIdAsync(int id)
        {
            Marker? markerToDelete = await _context.Markers.FindAsync(id);
            if (markerToDelete != null)
            {
                _context.Markers.Remove(markerToDelete);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 마커 위치 업데이트
        /// </summary>
        /// <param name="markerId">업데이트 할 마커 id</param>
        /// <param name="newPosition">변경된 위치</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task UpdatePositionAsync(int markerId, Vector3Value newPosition)
        {
            Marker? marker = await _context.Markers.FindAsync(markerId);
            if (marker == null)
                throw new KeyNotFoundException("찾을 수 없습니다.");

            marker.Position = newPosition;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="markers"></param>
        /// <returns></returns>
        public async Task UpdateBulkAsync(List<Marker> markers)
        {
            foreach (Marker m in markers)
            {
                Marker? existing = await _context.Markers.FindAsync(m.ID);
                if (existing != null)
                {
                    existing.PrefabID = m.PrefabID;
                    existing.DropItemID = m.DropItemID;
                    existing.AcquireStep = m.AcquireStep;
                    existing.RemoveStep = m.RemoveStep;
                    existing.Position = m.Position;
                    existing.Rotation = m.Rotation;
                    existing.Scale = m.Scale;
                    existing.MarkerSpawnType = m.MarkerSpawnType;
                    existing.MarkerType = m.MarkerType;
                }
                else
                {
                    var created = await CreateAsync(m);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
