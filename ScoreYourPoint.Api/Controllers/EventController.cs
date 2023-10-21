using Microsoft.AspNetCore.Mvc;
using ScoreYourPoint.Dto;
using ScoreYourPointAPI.Domain;
using ScoreYourPointApi.Infra.Data;
using Microsoft.EntityFrameworkCore;
using ScoreYourPointApi.Domain;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]

    public class EventController : Controller
    {
        public EventController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> Get()
        {
            var Event = await _dataContext.Events.ToListAsync();
            return Event.Select(w => new EventDto(w)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetByID(int id)
        {
            var Event = await _dataContext.Events.FirstOrDefaultAsync(ev => ev.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            return new EventDto(Event);
        }

        [HttpPost]
        public async Task<ActionResult> Store([FromBody] EventDto event_)
        {
            await _dataContext.Events.AddAsync(new Event
            {
                UserId = event_.UserId,
                Title = event_.Title,
                Description = event_.Description,
                ParticipantsAmount = event_.ParticipantsAmount,
                IsPublic = event_.IsPublic,
                Photo = event_.Photo,
                StartDateTime = event_.StartDateTime,
                EndDateTime = event_.EndDateTime,
                Status = event_.Status,
                Type = event_.Type,
                Street = event_.Street,
                ZipCode = event_.ZipCode,
                Neighbor = event_.Neighbor,
                Complement = event_.Complement,
            });

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EventDto event_)
        {
            var Evn = await _dataContext.Events.FirstOrDefaultAsync(ev => ev.Id == id);

            if (Evn == null)
            {
                return NotFound();
            }

            Evn.UserId = event_.UserId;
            Evn.Title = event_.Title;
            Evn.Description = event_.Description;
            Evn.ParticipantsAmount = event_.ParticipantsAmount;
            Evn.IsPublic = event_.IsPublic;
            Evn.Photo = event_.Photo;
            Evn.StartDateTime = event_.StartDateTime;
            Evn.EndDateTime = event_.EndDateTime;
            Evn.Status = event_.Status;
            Evn.Type = event_.Type;
            Evn.Street = event_.Street;
            Evn.ZipCode = event_.ZipCode;
            Evn.Neighbor = event_.Neighbor;
            Evn.Complement = event_.Complement;

            _dataContext.Entry(Evn).CurrentValues.SetValues(event_);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Evn = await _dataContext.Events.FirstOrDefaultAsync(ev => ev.Id == id);

            if (Evn == null)
            {
                return NotFound();
            }

            _dataContext.Remove(Evn);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
