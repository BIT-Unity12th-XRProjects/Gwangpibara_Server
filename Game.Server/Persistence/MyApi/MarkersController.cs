using Microsoft.AspNetCore.Mvc;
using Persistence.Models;
using Persistence.Services;

namespace Persistence.MyApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarkersController : ControllerBase
    {
        private readonly IMarkerService _markerService;

        public MarkersController(IMarkerService markerService)
        {
            _markerService = markerService;
        }

        /// <summary>
        /// 모든 마커 조회
        /// GET /api/markers
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Marker>>> GetAllAsync()
        {
            var markers = await _markerService.GetAllAsync();
            return Ok(markers);
        }

        /// <summary>
        /// ID로 마커 조회
        /// GET /api/markers/{id}
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var marker = await _markerService.GetByIdAsync(id);
            if (marker == null)
                return NotFound();

            return Ok(marker);
        }

        /// <summary>
        /// 새 마커 생성
        /// POST /api/markers
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Marker>> CreateAsync([FromBody] Marker newMarker)
        {
            var created = await _markerService.CreateAsync(newMarker);
            return CreatedAtAction(nameof(GetByIdAsync), "markers",new { id = newMarker.ID }, newMarker);
        }

        /// <summary>
        /// ID로 마커 삭제
        /// DELETE /api/markers/{id}
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _markerService.DeleteByIdAsync(id);
            return NoContent();
        }

        /// <summary>
        /// 마커 위치 업데이트
        /// PUT /api/markers/{id}/position
        /// </summary>
        [HttpPut("{id}/position")]
        public async Task<IActionResult> UpdatePositionAsync(int id, [FromBody] Vector3Value newPosition)
        {
            try
            {
                await _markerService.UpdatePositionAsync(id, newPosition);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("bulk")]
        public async Task<IActionResult> UpdateBulkAsync([FromBody] List<Marker> markers)
        {
            await _markerService.UpdateBulkAsync(markers);
            return NoContent();
        }
    }
}
