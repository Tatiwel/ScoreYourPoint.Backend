using Microsoft.AspNetCore.Mvc;
using ScoreYourPoint.Dto;
using ScoreYourPointAPI.Domain;
using ScoreYourPointApi.Infra.Data;
using Microsoft.EntityFrameworkCore;
using ScoreYourPointApi.Domain;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PositionController : Controller
    {
        public PositionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> Get()
        {
            var position = await _dataContext.Positions.ToListAsync();
            return position.Select(w => new PositionDto(w)).ToList();
             
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PositionDto>> GetByID(int id)
        {
            var position = await _dataContext.Positions.FirstOrDefaultAsync(pos => pos.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            return new PositionDto(position);
        }

        [HttpPost]
        public async Task<ActionResult> Store([FromBody] PositionRequestDto position)
        {
            await _dataContext.Positions.AddAsync(new Position
            {
                Name = position.Name,
            });
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PositionDto position)
        {
            var Pos = await _dataContext.Positions.FirstOrDefaultAsync(pos => pos.Id == id);
            if (Pos == null)
            {
                return NotFound();
            }
            Pos.Name = position.Name;
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Pos = await _dataContext.Positions.FirstOrDefaultAsync(pos => pos.Id == id);
            if (Pos == null)
            {
                return NotFound();
            }
            _dataContext.Positions.Remove(Pos);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
