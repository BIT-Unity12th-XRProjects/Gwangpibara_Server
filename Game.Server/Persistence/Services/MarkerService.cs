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
        /// ThemeID로 Marker 배열 조회, 추적은 안 함
        /// </summary>
        public async Task<List<Marker>> GetAllThemeAsync(int id)
        {
            var theme = await _context.Theme.FirstOrDefaultAsync(t => t.ID == id);
            if(theme != null)
            {
                await _context.Entry(theme)
                    .Collection(t => t.Markers)
                    .LoadAsync();
                return theme.Markers.ToList();
            }
            return new List<Marker>();
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
        /// <param name="inMarkers"></param>
        /// <returns></returns>
        public async Task UpdateBulkAsync(List<Marker> inMarkers)
        {
            List<Marker> existingList = await _context.Markers.AsNoTracking().ToListAsync();

            var incomingIds = inMarkers.Select(m => m.ID).ToHashSet();
            var toDeleteMarks = existingList.Where(db => !incomingIds.Contains(db.ID)).ToList();
            if(toDeleteMarks.Any())
            {
                _context.Markers.RemoveRange(toDeleteMarks);
            }

            foreach (Marker m in inMarkers)
            {
                Marker? dbEntity = existingList.FirstOrDefault(db => db.ID == m.ID);

                if (dbEntity != null) // 삭제 안되고 갱신 
                {
                    dbEntity.PrefabID = m.PrefabID;
                    dbEntity.NeedItemID = m.NeedItemID;
                    dbEntity.DropItemID = m.DropItemID;
                    dbEntity.AcquireStep = m.AcquireStep;
                    dbEntity.RemoveStep = m.RemoveStep;
                    dbEntity.Position = m.Position;
                    dbEntity.Rotation = m.Rotation;
                    dbEntity.Scale = m.Scale;
                    dbEntity.MarkerSpawnType = m.MarkerSpawnType;
                    dbEntity.MarkerType = m.MarkerType;
                    dbEntity.Theme = m.Theme;
                    dbEntity.ThemeID = m.ThemeID;

                    _context.Markers.Update(dbEntity);
                }
                else if (dbEntity == null) //없던 거 
                {
                    var created = await CreateAsync(m);
                }
                
            }
            await _context.SaveChangesAsync();
        }
    }
}
