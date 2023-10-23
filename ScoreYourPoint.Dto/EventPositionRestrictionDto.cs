using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Dto
{
    public class EventPositionRestrictionDto
    {

        public EventPositionRestrictionDto() { }

        public EventPositionRestrictionDto(EventPositionRestriction eventPosRestrict)
        { 
            Id = eventPosRestrict.Id;
            Team = eventPosRestrict.Team;
            SportPositionId = eventPosRestrict.SportPositionId;
            EventId = eventPosRestrict.EventId;
        }

        public long Id { get; set; }

        public char Team { get; set; }

        public long SportPositionId { get; set; }

        public long EventId { get; set; }
    }
}
