namespace ScoreYourPointAPI.Domain
{
    public class SportPosition
    {

        public long Id { get; set; }

        public long SportId { get; set; }

        public Sport Sport { get; set; }

        public long PositionId { get; set; }

        public Position Position { get; set; }

    }
}
