using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Infra.Data;
using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class SportController : Controller
    {
        public SportController(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        // GET: SportController
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet("{id}")]
        public async Task<ActionResult<SportDto>> GetByID(int id)
        {
            var Sport = await _dataContext.Sports.FirstOrDefaultAsync(sp => sp.Id == id);

            if (Sport == null)
            {
                return NotFound();
            }

            return new SportDto(Sport);
        }

        // POST: SportController
        [HttpPost]
        public async Task<ActionResult> Store([FromBody] SportDto sport)
        {
            await _dataContext.Sports.AddAsync(new Sport
            {
                Name = sport.Name,
            });

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT: SportController
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] SportDto sport)
        {
            var Spt = await _dataContext.Sports.FirstOrDefaultAsync(sp => sp.Id == id);

            if (Spt == null)
            {
                return NotFound();
            }

            Spt.Id = sport.Id;
            Spt.Name = sport.Name;

            _dataContext.Entry(Spt).CurrentValues.SetValues(sport);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: SportController
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Spt = await _dataContext.Sports.FirstOrDefaultAsync(sp => sp.Id == id);

            if (Spt == null)
            {
                return NotFound();
            }

            _dataContext.Remove(Spt);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
