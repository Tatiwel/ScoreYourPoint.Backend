using Microsoft.AspNetCore.Mvc;
using ScoreYourPoint.Dto;
using ScoreYourPoint.Services.Positions;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> Get()
        {
            var positions = await _positionService.GetPositionsAsync();
            return Ok(positions);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PositionDto>> GetByID(int id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return position;
            
        }

        [HttpPost]
        public async Task<ActionResult> Store([FromBody] PositionRequestDto position)
        {
            await _positionService.CreatePositionAsync(position);
            return NoContent();    
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PositionDto position)
        {
            await _positionService.UpdatePositionAsync(id, position);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}
