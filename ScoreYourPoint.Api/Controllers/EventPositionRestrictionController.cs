using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Infra.Data;
using ScoreYourPointAPI.Domain;
using System.Data.Entity;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]

    public class EventPositionRestrictionController : Controller
    {
        
        public EventPositionRestrictionController(DataContext dataContext)
        { 
            _dataContext = dataContext;
        }

        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPositionRestrictionDto>>> Get() 
        {
            var EventPosRestrict = await _dataContext.EventPositionRestrictions.ToListAsync();
            return EventPosRestrict.Select(w => new EventPositionRestrictionDto(w)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventPositionRestrictionDto>> getByID(int id) 
        {
            var EventPosRestrict = await _dataContext.EventPositionRestrictions.FirstOrDefaultAsync(w => w.Id == id);

            if (EventPosRestrict == null) 
            {
                return NotFound();
            }

            return new EventPositionRestrictionDto(EventPosRestrict);
        }

        [HttpPost]
        public async Task<ActionResult> Store([FromBody] EventPositionRestrictionDto eventPosRestriction_) 
        {
            await _dataContext.EventPositionRestrictions.AddAsync(new EventPositionRestriction
            {
                Team = eventPosRestriction_.Team,
                SportPositionId = eventPosRestriction_.SportPositionId,
                EventId = eventPosRestriction_.Id,
                
            });

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, [FromBody] EventPositionRestrictionDto eventPosRestriction_) 
        {
            var EventPosRestrict = await _dataContext.EventPositionRestrictions.FirstOrDefaultAsync(w => w.Id == id);

            if (EventPosRestrict == null) 
            {
                return NotFound();
            }

            EventPosRestrict.Team = eventPosRestriction_.Team;
            EventPosRestrict.SportPositionId = eventPosRestriction_.SportPositionId;
            EventPosRestrict.EventId = eventPosRestriction_.EventId;

            _dataContext.Entry(EventPosRestrict).CurrentValues.SetValues(eventPosRestriction_);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) 
        {
            var EventPosRestrict = await _dataContext.EventPositionRestrictions.FirstOrDefaultAsync(w => w.Id == id);

            if (EventPosRestrict == null) 
            {
                return NotFound();
            }

            _dataContext.Remove(EventPosRestrict);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
