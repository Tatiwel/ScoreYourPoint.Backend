using ScoreYourPointApi.Domain;

namespace ScoreYourPointAPI.Domain
{
    public class EventPositionRestriction
    {

        public long Id { get; set; }

        public int PositionLimitAmount { get; set; }

        public char Team { get; set; }

        public long SportPositionId { get; set; }

        public SportPosition SportPosition { get; set; }

        public long EventId { get; set; }

        public Event Event { get; set; }

    }
}
