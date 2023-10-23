using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPoint.Services.Sports;
using ScoreYourPointApi.Infra.Data;
using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class SportController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISportsService _sportsService;

        public SportController(DataContext dataContext, ISportsService sportsService)
        {
            _dataContext = dataContext;
            _sportsService = sportsService;
        }

        // GET: SportController
        [HttpGet("{id}")]
        public async Task<ActionResult<SportDto>> GetByID(int id)
        {
            return await _sportsService.GetSportByIdAsync(id);
        }

        // POST: SportController
        [HttpPost]
        public async Task<ActionResult> Store([FromBody] SportRequestDto sport)
        {
            await _sportsService.CreateSportAsync(sport);

            return NoContent();
        }

        // PUT: SportController
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] SportRequestDto sport)
        {
            await _sportsService.UpdateSportAsync(id, sport);

            return NoContent();
        }

        // DELETE: SportController
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _sportsService.DeleteSportAsync(id);

            return NoContent();
        }
    }
}
