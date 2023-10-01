using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Domain;
using ScoreYourPointApi.Infra.Data;
using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Api.Controllers
{

    [ApiController, Route("api/[controller]")]
    public class UserEventParticipationController : Controller
    {
        public UserEventParticipationController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEventParticipationDto>>> Get()
        {
            var userEventParticipation = await _dataContext.UserEventParticipations.ToListAsync();
            return userEventParticipation.Select(w => new UserEventParticipationDto(w)).ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEventParticipationDto>> GetByID(int id)
        {
            var userEventParticipation = await _dataContext.UserEventParticipations.FirstOrDefaultAsync(uep => uep.Id == id);
            if (userEventParticipation == null)
            {
                return NotFound();
            }
            return new UserEventParticipationDto(userEventParticipation);
        }
        [HttpPost]
        public async Task<ActionResult> Store([FromBody] UserEventParticipationRequestDto userEventParticipation)
        {
            await _dataContext.UserEventParticipations.AddAsync(new UserEventParticipation
            {
                Team = userEventParticipation.Team,
                UserId = userEventParticipation.UserId,
                SportPositionId = userEventParticipation.SportPositionId,
                EventId = userEventParticipation.EventId
            });
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserEventParticipationDto userEventParticipation)
        {
            var Uep = await _dataContext.UserEventParticipations.FirstOrDefaultAsync(uep => uep.Id == id);
            if (Uep == null)
            {
                return NotFound();
            }
            Uep.Team = userEventParticipation.Team;
            Uep.UserId = userEventParticipation.UserId;
            Uep.SportPositionId = userEventParticipation.SportPositionId;
            Uep.EventId = userEventParticipation.EventId;
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Uep = await _dataContext.UserEventParticipations.FirstOrDefaultAsync(uep => uep.Id == id);
            if (Uep == null)
            {
                return NotFound();
            }
            _dataContext.UserEventParticipations.Remove(Uep);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
