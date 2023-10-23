using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Dto
{
    public class SportPositionRequestDto
    {
        public long SportId { get; set; }

        public long PositionId { get; set; }

        public Position Position { get; set; }
    }
}
